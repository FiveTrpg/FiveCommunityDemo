using System;

namespace Gaming.API.Domain.Chat
{
    public struct Message
    {
        public Chatter Chatter { get; set; }
        public string Body { get; set; }
        public DateTime SentAt { get; set; }
    }
}
