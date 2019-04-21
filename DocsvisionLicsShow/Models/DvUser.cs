using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DocsvisionLicsShow.Models
{
    [Table("dvsys_users")]
    public class DvUser
    {
        [Key]
        public Guid UserID { get; set; }
        public string AccountName { get; set; }
       
    }
}
