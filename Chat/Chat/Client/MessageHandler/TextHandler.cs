using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Interfaces
{
    public class TextHandler : Handler
    {
        public override object Handle(object request)
        {
            if ((request as Models.Message).Type == MessageType.Text)
                return Encoding.ASCII.GetString((request as Models.Message).Content);
            return base.Handle(request);
        }
    }
}
