using System;
using System.Collections.Generic;
using System.Text;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllAsync();
        Task<ProductDto?> GetByIdAsync(int id);

        // delete productDto by id

        Task DeleteAsync(int id);

        //add productDto 

        Task AddAsync(CreateProductDto productDto);

        // update productDto by id
        Task UpdateAsync(UpdateProductDto productDto);


    }
}
