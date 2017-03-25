﻿using BethanyPieShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanyPieShop.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; } //pk
        public Pie Pie { get; set; } 
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
