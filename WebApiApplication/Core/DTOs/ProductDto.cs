﻿namespace Core.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string ImgUri { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
    }
}
