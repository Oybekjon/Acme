using Acme.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Acme.Services
{
    public class InstantMessage<T> : IInstantMessage<T>
    {

        private List<Message<T>> _messages;
        private readonly object threadLock = new object();
        public List<Message<T>> Messages => _messages = _messages ?? new List<Message<T>>();

        public InstantMessage() { }

        #region Messaging
        public void AddMessage(Message<T> message)
        {
            if (message == null)
            {
                throw new ArgumentNullException();
            }
            message.CreatedUtcDate = DateTime.UtcNow;

            lock (threadLock)
            {
                Messages.Add(message);
            }
        }

        public List<Message<T>> GetMessages(DateTime? since)
        {
            if (since == null)
            {
                return Messages;
            }

            since = since.Value.ToUniversalTime();

            var startDate = DateTime.UtcNow;

            while (true)
            {
                var messagesForReturn = Messages.Where(m => m.CreatedUtcDate >= since).ToList();

                if (messagesForReturn.Count > 0 || DateTime.UtcNow >= startDate + TimeSpan.FromMinutes(5))
                {
                    return messagesForReturn;
                }

                Thread.Sleep(1000);
            }

        }
        #endregion
    }
}
