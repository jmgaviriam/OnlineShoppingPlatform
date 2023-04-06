﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.Domain.Entity
{
    public class Product
    {
        [Key]
        public string ProductId { get; set; }

        public string StoreId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        // Métodos CRUD
    }
}
