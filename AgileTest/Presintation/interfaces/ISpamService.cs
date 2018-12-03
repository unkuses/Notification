using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presintation.interfaces
{
    public interface ISpamService
    {
        bool SendNotification(string subject, string[] recipients, string message);
    }
}
