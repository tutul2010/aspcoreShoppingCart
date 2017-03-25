using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanyPieShop.Models
{
    //master data
    public class Category
    {
        public int CategoryId { get; set; } //pk
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public List<Pie> Pies { get; set; } //linking
    }
}
