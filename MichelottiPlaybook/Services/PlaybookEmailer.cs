using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Web;
using SendGridMail.Transport;

namespace MichelottiPlaybook.Services
{
    public class PlaybookEmailer : MichelottiPlaybook.Services.IPlaybookEmailer
    {
        private const string steveEmail = "steve.michelotti@gmail.com";
        private static readonly string sendGridUserName = ConfigurationManager.AppSettings["SendGridUserName"];
        private static readonly string sendGridPassword = ConfigurationManager.AppSettings["SendGridPassword"];

        public void SendApprovalRequestEmail(string name)
        {
            var message = SendGridMail.SendGrid.GenerateInstance();
            message.AddTo(steveEmail);
            message.From = new MailAddress(steveEmail, "Michelotti Playbook");
            message.Subject = "Michelotti Playbook Approval Request for " + name;
            //message.Html = "<html><p>Hello</p><p>World</p></html>";
            message.Text = string.Format("Approval request for {0}.", name);


            //send the mail asyncronously
            ThreadPool.QueueUserWorkItem(SendEmail, (object)message);
        }

        private void SendEmail(object message)
        {
            var transportInstance = SMTP.GenerateInstance(new NetworkCredential(sendGridUserName, sendGridPassword));
            transportInstance.Deliver((SendGridMail.SendGrid)message);
        }
    }
}