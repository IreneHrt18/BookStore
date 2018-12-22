﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int Count { get; set; }
        public DateTime Time { get; set; }

        public Book Book { get; set; }
        public User User { get; set; }
    }
}
