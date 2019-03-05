using Domain.Models;
using Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace Infrastructure
{
    public class NotificationUtility : INotificationUtility
    {
        private readonly ElasticEmailOptions _elasticEmailOptions;

        public NotificationUtility(ElasticEmailOptions elasticEmailOptions)
        {
            _elasticEmailOptions = elasticEmailOptions;
        }

        public void SendMail(MailModel mail)
        {
            var dict = new Dictionary<string, string>
            {
                { "apikey", _elasticEmailOptions.ApiKey },
                { "from", _elasticEmailOptions.From },
                { "fromName", _elasticEmailOptions.FromName },
                { "to", mail.To },
                { "subject", mail.Subject },
                { "bodyHtml", mail.Content },
                { "isTransactional", "true" }
            };

            var values = dict.Select(v => new KeyValuePair<string, string>(v.Key, v.Value));

            using (HttpClient client = new HttpClient())
            {
                var formContent = new FormUrlEncodedContent(values);
                client.PostAsync(_elasticEmailOptions.Url, formContent).Wait();
            }
        }
    }

    public class ElasticEmailOptions
    {
        public string ApiKey { get; set; }
        public string From { get; set; }
        public string FromName { get; set; }
        public string Url { get; set; }

    }
}
