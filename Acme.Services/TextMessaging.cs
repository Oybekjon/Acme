using Acme.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Acme.Services
{
    public class TextMessaging
    {
        private IInstantMessage<TextMessage> InstantMessageService;
        public TextMessaging(IInstantMessage<TextMessage> instantMessageService)
        {
            Guard.NotNull(instantMessageService, nameof(instantMessageService));
            InstantMessageService = instantMessageService;
        }
        public void AddMessage(TextMessage message)
        {
            // check huyo moyo
            Guard.NotNull(message, nameof(message));
            InstantMessageService.AddMessage(new Message<TextMessage> {
                Value = message,
                CreatedUtcDate = DateTime.UtcNow
            });
            // db add

        }

        public List<TextMessage> GetMessages(DateTime? since, long groupid)
        {
            // db query
            var queryResult = new List<TextMessage>();
            var result = InstantMessageService.GetMessages(since);
            foreach (var item in result)
            {
                if (!queryResult.Any(x => x.TextMessageId == item.Value.TextMessageId))
                {
                    queryResult.Add(item.Value);
                }
            }
            return queryResult;
        }
    }
}
