using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanyPieShop.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; } //pk
        public int OrderId { get; set; } //fk
        public int PieId { get; set; }//fk
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public virtual Pie Pie { get; set; } //linking to pie
        public virtual Order Order { get; set; } //linking to order
    }
}
