using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            using var context = new ApiDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApiDbContext>>());

            // Look for any products
            if (await context.Products.AnyAsync())
            {
                return; // DB has been seeded
            }

            await context.Products.AddRangeAsync(
                new Product
                {
                    Name = "Laptop Pro X1",
                    ImgUri = "https://example.com/images/laptop-pro-x1.jpg",
                    Price = 1299.99m,
                    Description = "High-performance laptop with 16GB RAM and 512GB SSD."
                },
                new Product
                {
                    Name = "Smartphone Z10",
                    ImgUri = "https://example.com/images/smartphone-z10.jpg",
                    Price = 899.99m,
                    Description = "Latest smartphone with 6.7-inch OLED display and 5G connectivity."
                },
                new Product
                {
                    Name = "Wireless Headphones",
                    ImgUri = "https://example.com/images/wireless-headphones.jpg",
                    Price = 199.99m,
                    Description = "Noise-cancelling wireless headphones with 30-hour battery life."
                },
                new Product
                {
                    Name = "Smart Watch V3",
                    ImgUri = "https://example.com/images/smart-watch-v3.jpg",
                    Price = 249.99m,
                    Description = "Fitness tracker with heart rate monitoring and GPS."
                },
                new Product
                {
                    Name = "Tablet Air",
                    ImgUri = "https://example.com/images/tablet-air.jpg",
                    Price = 499.99m,
                    Description = "Lightweight tablet with 10.9-inch Retina display and A14 chip."
                },
                new Product
                {
                    Name = "4K Monitor",
                    ImgUri = "https://example.com/images/4k-monitor.jpg",
                    Price = 349.99m,
                    Description = "27-inch 4K UHD monitor with HDR support."
                },
                new Product
                {
                    Name = "Wireless Mouse",
                    ImgUri = "https://example.com/images/wireless-mouse.jpg",
                    Price = 49.99m,
                    Description = "Ergonomic wireless mouse with adjustable DPI settings."
                },
                new Product
                {
                    Name = "Mechanical Keyboard",
                    ImgUri = "https://example.com/images/mechanical-keyboard.jpg",
                    Price = 129.99m,
                    Description = "RGB mechanical keyboard with customizable key switches."
                },
                new Product
                {
                    Name = "External SSD",
                    ImgUri = "https://example.com/images/external-ssd.jpg",
                    Price = 179.99m,
                    Description = "1TB portable solid-state drive with USB-C connectivity."
                },
                new Product
                {
                    Name = "Gaming Console",
                    ImgUri = "https://example.com/images/gaming-console.jpg",
                    Price = 499.99m,
                    Description = "Next-gen gaming console with 4K gaming and ray tracing support."
                },
                new Product
                {
                    Name = "Wireless Earbuds",
                    ImgUri = "https://example.com/images/wireless-earbuds.jpg",
                    Price = 129.99m,
                    Description = "True wireless earbuds with active noise cancellation."
                },
                new Product
                {
                    Name = "Smart Speaker",
                    ImgUri = "https://example.com/images/smart-speaker.jpg",
                    Price = 99.99m,
                    Description = "Voice-controlled smart speaker with premium sound quality."
                }
            );

            await context.SaveChangesAsync();
        }
    }
}