using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pc.Core.Entities
{
    //[Table("wallet")]
     public class Wallet
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        public decimal Balance { get; set; }

    }

}
