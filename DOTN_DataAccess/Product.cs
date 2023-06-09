﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTN_DataAccess
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool ShopFavorites { get;set; }
        public bool CustomerFavorites { get; set; }
        public string Color { get; set; }
        public string  ImageUrl { get; set; }  
        public int CategoryId { get; set; }
        public double Price { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

    }
}
