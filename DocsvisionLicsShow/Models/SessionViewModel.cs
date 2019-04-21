using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocsvisionLicsShow.Models
{
    public class SessionViewModel
    {
        public string UserName { get; set; }

        public string ComputerName { get; set; }

        public DateTime LastAccessTime { get; set; }

        public DateTime LoginTime { get; set; }

        public TimeSpan IdleTime { get; set; }

        public string Offline { get; set; }

        public SessionViewModel(DvSession dvSession)
       {           
            ComputerName = dvSession.ComputerName;
            LastAccessTime = dvSession.LastAccessTime;
            LoginTime = dvSession.LoginTime;
            IdleTime = DateTime.Now.Subtract(LastAccessTime);
            Offline = dvSession.Offline ? "Оффлайн" : "Онлайн";
        }
    }
}
