using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Models
{
    [Serializable]
    public class Message
    {
        public MessageType Type { get; set; }
        public byte[] Content { get; set; }

        public Message() {}

        public Message(MessageType type, byte[] content)
        {
            Type = type;
            Content = content;
        }
    }
}
