using Application.DTOs.OrderDtos;
using Application.DTOs.OrderFolder;
using Application.Interfaces;
using AutoMapper;
using infrastructure.Repositres;
using Domain.Entities;

namespace Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepositry _orderRepositry;
        private readonly IMapper _mapper;
        public OrderService(IOrderRepositry orderRepository, IMapper mapper)
        { 
            _mapper = mapper;
            _orderRepositry = orderRepository;
        }

        public async Task AddAsync(CreateOrderDto orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            await _orderRepositry.AddAsync(order);
        }
        public async Task UpdateAsync(UpdateOrderDto orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            await _orderRepositry.UpdateAsync(order);
        }
        //public async Task UpdateAsync(int id, UpdateOrderDto dto)
        //{
        //    var order = await _orderRepositry.GetAsync(id);

        //    if (order == null)
        //    {
        //        throw new KeyNotFoundException("Order not found");
        //    }

        //    _mapper.Map(dto, order);

        //    await _orderRepositry.UpdateAsync(order);
        //}
        public async Task DeleteAsync(int id)
        {
            await _orderRepositry.DeleteAsync(id);
        }

        // for the Get data by id and All data from order
        public async Task<List<OrderDto>> GetAllAsync()
        {
            var order = await _orderRepositry.GetAllAsync();
            return _mapper.Map<List<OrderDto>>(order);
        }

        public async Task<OrderDto> GetByIdAsync(int id)
        {
            var order = await _orderRepositry.GetAsync(id);
            return _mapper.Map<OrderDto>(order);
        }



    }
}
