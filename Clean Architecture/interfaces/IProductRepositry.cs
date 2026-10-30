using Domain.Entities;

namespace Clean_Architecture.interfaces
{
    public interface IProductRepositry
    {
        Task<List<Product>> GetAllAsync();

        Task<Product> GetAsync(int id);
        Task DeleteAsync(int id);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        

    }
}
