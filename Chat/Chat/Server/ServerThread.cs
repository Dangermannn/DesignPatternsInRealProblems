using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    public class ServerThread
    {
        private static List<Socket> _clientSockets = new List<Socket>();
        private static Socket _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private const int BUFFER_SIZE = 2048 * 10000;
        private const int PORT = 100;
        private static byte[] _buffer = new byte[BUFFER_SIZE];

        public void SetupServer()
        {
            Console.WriteLine("Setting up a server...");
            _serverSocket.Bind(new IPEndPoint(IPAddress.Any, PORT));
            _serverSocket.Listen(1);
            _serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
        }

        public void CloseAllSockets()
        {
            foreach (Socket socket in _clientSockets)
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
            _serverSocket.Close();
        }

        private static void AcceptCallback(IAsyncResult AR)
        {
            Socket socket;

            try
            {
                socket = _serverSocket.EndAccept(AR);
            }
            catch (ObjectDisposedException)
            {
                return;
            }
            // add observer
            _clientSockets.Add(socket);
            socket.BeginReceive(_buffer, 0, BUFFER_SIZE, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
            Console.WriteLine("Client connected!");
            _serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
        }

        private static void ReceiveCallback(IAsyncResult AR)
        {
            Socket current = (Socket)AR.AsyncState;
            int received;

            try
            {
                received = current.EndReceive(AR);
            }
            catch (SocketException)
            {
                Console.WriteLine("Client disconnected");
                current.Close();
                _clientSockets.Remove(current);
                return;
            }

            byte[] recBuf = new byte[received];
            Array.Copy(_buffer, recBuf, received);
            string text = Encoding.UTF8.GetString(recBuf);
            Console.WriteLine("Received Text: " + text);

            if (text.ToLower() == "exit")
            {
                current.Shutdown(SocketShutdown.Both);
                current.Close();
                // removing observer
                _clientSockets.Remove(current);
                Console.WriteLine("Client disconnected");
                return;
            }
            else
            {
                byte[] data = Encoding.UTF8.GetBytes(text);

                // notifying all observers
                foreach (var socket in _clientSockets)
                    socket.Send(recBuf);
                Console.WriteLine("Data has been sent!");
            }

            current.BeginReceive(_buffer, 0, BUFFER_SIZE, SocketFlags.None, ReceiveCallback, current);
        }
    }
}
