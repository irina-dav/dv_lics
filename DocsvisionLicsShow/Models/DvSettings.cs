using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocsvisionLicsShow.Models
{
    public class DvSettings
    {
        public int LicsMax { get; set; }
        public List<string> ExcludeAccounts { get; set; }
    }
}
