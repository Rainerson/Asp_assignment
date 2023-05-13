﻿

namespace Views.Models
{
    public class ProductModel
    {
        public int? Id { get; set; }
        public string? Name { get; set; } = null!;

        public string? Description { get; set; } = null!;

        public decimal? Price { get; set; }

        public int? Rating { get; set; }
    }
}
