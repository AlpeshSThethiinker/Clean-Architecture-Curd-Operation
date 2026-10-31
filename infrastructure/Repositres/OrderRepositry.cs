using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace infrastructure.Repositres
{
    public interface IOrderRepositry
    {
        Task<List<Order>> GetAllAsync();
        Task<Order> GetAsync(int id);
        Task DeleteAsync(int id);
        Task AddAsync(Order order);
        Task UpdateAsync(Order order);
    }

    public class OrderRepositry : IOrderRepositry
    {
        private readonly ApplicationDbContext _context;
        public OrderRepositry(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Order>> GetAllAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order?> GetAsync(int id)
        {
            return await _context.Orders.FindAsync(id);

        }

        public async Task AddAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteAsync(int id)
        {
            var Order = await _context.Orders.FindAsync(id);
            if(Order != null)
            {
                _context.Orders.Remove(Order);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(Order order)
        {
            //var Order
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }
    }


}

