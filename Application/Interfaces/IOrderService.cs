
using Application.DTOs.OrderDtos;
using Application.DTOs.OrderFolder;

namespace Application.Interfaces
{
    public interface IOrderService
    {
        Task<List<OrderDto>> GetAllAsync();
        Task<OrderDto> GetByIdAsync(int id);
        // delete OrderDto by id

        Task DeleteAsync(int id);

        //add productDto 

        Task AddAsync(CreateOrderDto orderDto);

        // update productDto by id
        Task UpdateAsync(UpdateOrderDto orderDto);


    }
}
