using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Utilities
{
    public interface INotificationUtility
    {
        void SendMail(MailModel email);
    }
}
