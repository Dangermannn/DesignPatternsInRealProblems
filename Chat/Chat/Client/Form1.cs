using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.Interfaces;
using NAudio;
using NAudio.Wave;

namespace Client
{
    public partial class Form1 : Form
    {
        private static readonly Socket _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private const int BUFFER_SIZE = 2048 * 10000;
        private const int PORT = 100;
        private Image _defaultImage;
        private Image _defaultImage2;
        private byte[] _defaultAudio;

        private Handler _handler = new TextHandler();

        private List<Models.Message> _messages = new List<Models.Message>();
   

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _defaultImage = Image.FromFile("../../../../mario.jpg");
            _defaultImage2 = Image.FromFile("../../../../dark-souls-III.jpg");

            using(WaveFileReader reader = new WaveFileReader("../../../../pop-sound-effect.wav"))
            {
                _defaultAudio = new byte[reader.Length];
                int read = reader.Read(_defaultAudio, 0, _defaultAudio.Length);
                short[] sampleBuffer = new short[read / 2];
                Buffer.BlockCopy(_defaultAudio, 0, sampleBuffer, 0, read);
            }

            _handler.SetNext(new ImageHandler()).SetNext(new AudioHandler());
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            Connect();
            while (true)
                await Loop();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {

            if (textBoxInput.Text == String.Empty)
            {
                MessageBox.Show("Message cannot be empty");
                return;
            }
            else if(textBoxInput.Text == "/send default img")
                SendDefaultPhoto();
            else if (textBoxInput.Text == "/send default img2")
                SendDefaultPhoto2();
            else if(textBoxInput.Text == "/send default sound")
                SendDefaultSound();
            else
            {
                byte[] buffer = Encoding.UTF8.GetBytes(textBoxInput.Text);
                var msg = new Models.Message(MessageType.Text, buffer);
                _clientSocket.Send(ObjectToByteArray(msg));
            }
            textBoxInput.Text = String.Empty;
        }


        private void Connect()
        {
            int attempts = 0;
            while (!_clientSocket.Connected)
            {
                try
                {
                    attempts++;
                    _clientSocket.Connect(IPAddress.Loopback, PORT);
                }
                catch (SocketException)
                {
                    listBoxLogs.Items.Add($"Connection attempts: {attempts}");
                }
            }
            listBoxMessages.Items.Add("Connected!");
            _messages.Add(new Models.Message(MessageType.Text, Encoding.UTF8.GetBytes("Connected!")));
        }
        private async Task<string> Loop()
        {
            var message = await Task.Run(ScanMessages);
            var messageAsObj = ByteArrayToObject<Models.Message>(message);

            var result = _handler.Handle(messageAsObj);

            if (result is string)
                HandleText(messageAsObj);
            else if (result is Bitmap)
                HandleImg(messageAsObj);
            else if (result is IWaveProvider)
                HandleAudio(messageAsObj);
            
            return Encoding.UTF8.GetString(message);
        }

        private string HandleImg(Models.Message message)
        {

            listBoxMessages.Items.Add("<<Picture has been uploaded>>");
            _messages.Add(message); 
            return Encoding.UTF8.GetString(message.Content);
        }

        private string HandleText(Models.Message message)
        {
            listBoxMessages.Items.Add(Encoding.UTF8.GetString(message.Content));
            _messages.Add(message);
            return Encoding.UTF8.GetString(message.Content);
        }

        private string HandleAudio(Models.Message message)
        {
            try
            {
                _messages.Add(message);
            }
            catch (Exception)
            {
                listBoxLogs.Items.Add("Error occured while initializing audio");
            }
            var retMsg = "<<Audio file has been sent!>>";
            listBoxMessages.Items.Add(retMsg);
            return retMsg;
        }

        private byte[] ScanMessages()
        {
            while (true)
            {
                byte[] buffer = new byte[BUFFER_SIZE];
                int len = _clientSocket.Receive(buffer);
                if(len >= 0)
                {
                    byte[] data = new byte[len];
                    Array.Copy(buffer, data, len);
                    return data;
                }
            }
        }


        #region Send default

        private async Task<bool> SendDefaultPhoto()
        {
            MemoryStream ms = new MemoryStream();
            _defaultImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

            byte[] data = ms.ToArray();

            var msg = new Models.Message(MessageType.Image, data);

            _clientSocket.Send(ObjectToByteArray(msg));
            ms.Close();

            return true;
        }

        private async Task<bool> SendDefaultPhoto2()
        {
            MemoryStream ms = new MemoryStream();
            _defaultImage2.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

            byte[] data = ms.ToArray();

            var msg = new Models.Message(MessageType.Image, data);

            _clientSocket.Send(ObjectToByteArray(msg));
            ms.Close();

            return true;
        }

        private async Task<bool> SendDefaultSound()
        {
            var msg = new Models.Message(MessageType.Sound, _defaultAudio);

            _messages.Add(msg);
            _clientSocket.Send(ObjectToByteArray(msg));
            return true;
        }

        #endregion

        #region Winforms events

        private void listBoxMessages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxMessages.SelectedItem== null)
                return;
            var index = listBoxMessages.SelectedIndex;
            if (index > _messages.Count)
                return;
            var msg = _messages[index];


            var result = _handler.Handle(msg);
            pictureBox1.Image = result as Bitmap;
            pictureBox1.Refresh();
            pictureBox1.Invalidate();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (listBoxMessages.SelectedItem == null)
                return;
            var index = listBoxMessages.SelectedIndex;
            if (index > _messages.Count)
                return;
            var msg = _messages[index];

            var result = _handler.Handle(msg);

            if(!(result is IWaveProvider))
                listBoxLogs.Items.Add("You didn't pick a message with audio!");
            else
            {
                var waveOut = new WaveOut();
                waveOut.Init(result as IWaveProvider);
                waveOut.Play();
            }
        }

        #endregion

        #region Helpers

        private static byte[] ObjectToByteArray(Object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        private static T ByteArrayToObject<T>(byte[] data)
        {
            if (data == null)
                return default(T);
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream(data))
            {
                object obj = bf.Deserialize(ms);
                return (T)obj;
            }
        }


        #endregion
    }
}
