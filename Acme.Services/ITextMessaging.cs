using System;
using System.Collections.Generic;
using Acme.Services.ViewModels;

namespace Acme.Services
{
    public interface ITextMessaging
    {
        void AddMessage(TextMessage message);
        List<TextMessage> GetMessages(DateTime? since, long groupid);
    }
}