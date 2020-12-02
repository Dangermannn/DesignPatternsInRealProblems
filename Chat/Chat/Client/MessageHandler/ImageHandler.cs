using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace Client.Interfaces
{
    public class ImageHandler : Handler
    {
        public override object Handle(object request)
        {
            if((request as Models.Message).Type == MessageType.Image)
            {
                using (MemoryStream ms = new MemoryStream((request as Models.Message).Content))
                {
                    var img = new Bitmap(Image.FromStream(ms));
                    return img;
                }
            }
            return base.Handle(request);
        }
    }
}
