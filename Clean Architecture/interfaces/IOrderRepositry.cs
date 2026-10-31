using Domain.Entities;
namespace CleanArchitecture.interfaces
{
    public interface IOrderRepositry
    {
        Task<List<Order>> GetAllAsync();
        Task<Order> GetAsync(int id);
        Task AddAsync(Order order);
        Task DeleteAsync(int id);
        Task UpdateAsync(Order order);
    }
}
