using Presintation.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presintation.Service
{
    public class ExternalNotificationService : ISpamService
    {
        static Random random = new Random();
        public bool SendNotification (string subject, string[] recipients, string message)
        {
            //Send spam to all
            return random.Next(0, 1) == 0; // imitation of hard work
        }
    }
}
