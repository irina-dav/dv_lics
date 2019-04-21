using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DocsvisionLicsShow.Models
{
    [Table("dvtable_{DBC8AE9D-C1D2-4D5E-978B-339D22B32482}")]
    public class DvEmployee
    {
        [Key]
        public Guid RowID { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string FirstName { get; set; }
        
        public string AccountName { get; set; }
    }
}
