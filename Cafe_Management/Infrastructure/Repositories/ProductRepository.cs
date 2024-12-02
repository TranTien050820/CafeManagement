using Cafe_Management.Code;
using Cafe_Management.Core.Entities;
using Cafe_Management.Core.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cafe_Management.Infrastructure.Data;

namespace Cafe_Management.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products
        .Select(p => new Product
        {
            Product_ID = p.Product_ID,
            Product_Name = p.Product_Name,
            Product_Category = p.Product_Category,
            Price = p.Price,
            Point = p.Point,
            IsActive = p.IsActive,
            CreatedDate = p.CreatedDate,
            ModifiedDate = p.ModifiedDate,
            ProductRecipe = p.ProductRecipe.Select(pr => new ProductRecipe
            {
                Recipe_ID = pr.Recipe_ID,
                Ingredient_ID = pr.Ingredient_ID,
                Quantity = pr.Quantity,
                Unit = pr.Unit
            }).ToList(),
            ProductImage = p.ProductImage.Select(pr => new ProductImage
            {
                ProductImage_ID = pr.ProductImage_ID,
                Image_URL = pr.Image_URL,
                AltText = pr.AltText
            }).ToList()
        }).ToListAsync();
        }

        public async Task AddAsync(Product product)
        {
            product.CreatedDate = DateTime.Now;
            product.ModifiedDate = DateTime.Now;

            // Tìm giá trị ProductID lớn nhất hiện tại
            var maxId = await _context.Products.MaxAsync(p => (int?)p.Product_ID) ?? 0;

            // Tự động tăng ID cho sản phẩm mới
            product.Product_ID = maxId + 1;
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Product product)
        {
            var existingProduct = await _context.Products.FindAsync(product.Product_ID);
            if (existingProduct != null )
            {
                if (product.IsActive != null)
                {
                    existingProduct.IsActive = product.IsActive;
                    await _context.SaveChangesAsync(); // Lưu thay đổi vào database
                    
                    return; 
                }
                if(product.IsActive == null) {
                    existingProduct.Product_Name = product.Product_Name;
                    existingProduct.Price = product.Price;
                    existingProduct.Product_Category = product.Product_Category;
                    existingProduct.Point = product.Point;
                    await _context.SaveChangesAsync(); // Lưu thay đổi vào database
                }
                
            }
        }

    }
}

