using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocsvisionLicsShow.Models
{
    public class SessionsListViewModel
    {
        public int LicsCount { get; set; }

        public int LicsMax { get; set; }

        public List<SessionViewModel> Sessions { get; set; } = new List<SessionViewModel>();
    }
}
