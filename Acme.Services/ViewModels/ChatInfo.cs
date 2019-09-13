using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.Services.ViewModels
{
    public class ChatInfo
    {
        public long ChatId { get; set; }
        public List<long> Members { get; set; }
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
