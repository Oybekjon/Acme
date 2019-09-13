using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.Services.ViewModels
{
    public class TextMessage
    {
        public long TextMessageId { get; set; }
        public string Text { get; set; }
        public long UserId { get; set; }
        public DateTime DateCreated { get; set; }
        public long ChatId { get; set; }
    }
}
