using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DocsvisionLicsShow.Models
{
    [Table("dvsys_sessions")]
    public class DvSession
    {
        [Key]
        public Guid SessionID { get; set; }

        public Guid UserID { get; set; }

        public string ComputerName { get; set; }

        public string ComputerAddress { get; set; }

        public DateTime LastAccessTime { get; set; }

        public DateTime LoginTime { get; set; }

        public bool Offline { get; set; }

        [ForeignKey("UserID")]
        public DvUser User { get; set; }
    }
}
