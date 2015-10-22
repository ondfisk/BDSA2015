using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDSA2015.Lecture03
{
    public class OrderLine
    {
        [Column(Order = 0)]
        [Key]
        public int OrderId { get; set; }

        [Column(Order = 1)]
        [Key]
        public int ProductId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
