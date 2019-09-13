using System;
using System.Collections.Generic;
using Acme.Services.ViewModels;

namespace Acme.Services
{
    public interface IInstantMessage<T>
    {
        void AddMessage(Message<T> message);
        List<Message<T>> GetMessages(DateTime? since);
    }
}