using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Application.Interfaces;
using infrastructure.Repositres;


namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepositry _productRepositry;
        private readonly IMapper _mapper;
        public ProductService(IProductRepositry productRepository, IMapper mapper)
        {
            
            _mapper = mapper;
            _productRepositry = productRepository;

        }
        public async Task AddAsync(CreateProductDto productDto)
        {
            //await _productRepository.AddAsync(_mapper.Map<Product>(product));
            var product = _mapper.Map<Product>(productDto);

            await _productRepositry.AddAsync(product);
        }

        public  async Task DeleteAsync(int id)
        {
            
            await _productRepositry.DeleteAsync(id);
        }

        public async Task<List<ProductDto>> GetAllAsync()
        {
            //return _mapper.Map<List<ProductDto>>(await _productRepository.GetAllAsync());
            var products = await _productRepositry.GetAllAsync();

            return _mapper.Map<List<ProductDto>>(products);
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            //throw new NotImplementedException();
            //return _mapper.Map<ProductDto>(await _productRepositry.GetByIdAsync(id));

            var product = await _productRepositry.GetAsync(id);

            return _mapper.Map<ProductDto>(product);
        }

        public async Task UpdateAsync(UpdateProductDto productDto)
        {
            //throw new NotImplementedException();
            //await _productRepository.UpdateAsync(_mapper.Map<Product>(product));

            var product = _mapper.Map<Product>(productDto);

            await _productRepositry.UpdateAsync(product);

        }
    }
}
