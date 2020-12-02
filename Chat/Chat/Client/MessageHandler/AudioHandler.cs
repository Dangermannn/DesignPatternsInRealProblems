using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Client.Interfaces
{
    public class AudioHandler : Handler
    {
        public override object Handle(object request)
        {
            if ((request as Models.Message).Type == MessageType.Sound)
            {
                IWaveProvider provider = new RawSourceWaveStream(new MemoryStream((request as Models.Message).Content), new WaveFormat());
                return provider;
            }
            return base.Handle(request);
        }
    }
}
