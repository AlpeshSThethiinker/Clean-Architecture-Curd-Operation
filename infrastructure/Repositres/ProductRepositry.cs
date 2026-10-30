using Domain.Entities;
using infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Repositres
{
    public interface IProductRepositry
    {
        Task<List<Product>> GetAllAsync();

        Task<Product> GetAsync(int id);
        Task DeleteAsync(int id);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);


    }

    public class ProductRepositry : IProductRepositry
    {
        private readonly ApplicationDbContext _context;
        public ProductRepositry(ApplicationDbContext context)
        {
            _context = context;

        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }
        public async Task<Product?> GetAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        //Add Product using the addasync method 
        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        //Delete product using the deleteasync method used remove method to delete the product from the database
        public async Task DeleteAsync(int id)
        {
            var Product = await _context.Products.FindAsync(id);
            if(Product != null)
            {
                _context.Products.Remove(Product);
                await _context.SaveChangesAsync();

            }
        }

        // Update product using the updateasync method used update method to update the product from the database

        public async Task UpdateAsync(Product product)
        {
            
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }


    }
}
