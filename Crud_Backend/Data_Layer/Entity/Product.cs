﻿using System.ComponentModel.DataAnnotations;

namespace Data_Layer.Entity

{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }

        public string Discount { get; set; }

    }
}
