﻿using Cafe_Management.Code;
using Cafe_Management.Core.Entities;
using Cafe_Management.Core.Interfaces;
using Cafe_Management.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Data;
using System.Data.Odbc;

namespace Cafe_Management.Infrastructure.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly AppDbContext _context;

        public ProductCategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductCategory>> GetAllProductCategories()
        {
            return await _context.ProductCategory.ToListAsync();
        }


        public async Task AddProductCategory(ProductCategory category)
        {
            category.CreatedDate = DateTime.Now;
            category.ModifiedDate = DateTime.Now;

            if(category.Category_Name != null )
            {
                await _context.ProductCategory.AddAsync(category);
                await _context.SaveChangesAsync();
            }
            
           
        }


        [HttpPut("Update")]

        public async Task UpdateProductCategory(ProductCategory category)
        {
            var existingProductCategory = await _context.ProductCategory.FindAsync(category.Category_ID);
            if (existingProductCategory != null)
            {
                    existingProductCategory.Category_Name = category.Category_Name;
                    existingProductCategory.IsActive = category.IsActive;
                    await _context.SaveChangesAsync(); // Lưu thay đổi vào database

            }
        }
    }
}
