using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.Services.ViewModels
{
    public class Message<T>
    {
        public DateTime CreatedUtcDate { get; set; }
        public T Value { get; set; }
    }
}
