using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Presintation.DB;
using Presintation.interfaces;

namespace Presintation.Controllers
{
    public class NotificationController : Controller
    {
        private ISpamService spamService;

        public NotificationController(ISpamService spamService)
        {
            this.spamService = spamService;
        }

        private const char DILIMITR = ';';
        [HttpPost]
        public ActionResult SendNotification([FromBody]JObject message)
        {
            bool sent = spamService.SendNotification(message: message["message"].Value<string>(), 
                subject: message["subject"].Value<string>(),
                recipients: message["recipients"].Value<string>().Split(DILIMITR));

            writeToDb(new Notification()
            {
                Body = message["message"].Value<string>(),
                Subject = message["subject"].Value<string>(),
                Recipients = message["recipients"].Value<string>(),
                IsSent = sent
            });

            return new JsonResult(true);
        }

        private void writeToDb(Notification notification)
        {
            using (var db = new SqliteDbContext())
            {
                db.Notifications.Add(notification);
                db.SaveChanges();
            }
        }
    }
}