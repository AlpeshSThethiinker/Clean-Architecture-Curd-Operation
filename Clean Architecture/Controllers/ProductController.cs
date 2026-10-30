//using Application.DTOs;
//using Application.Interfaces;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace Clean_Architecture.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ProductController : ControllerBase
//    {
//        private readonly IProductService _productService;
//        public ProductController(IProductService productService)
//        {
//            _productService = productService;

//        }
//        [HttpGet]
//        public async Task<IActionResult> GetAll() => Ok(await _productService.GetAllAsync());

//        [HttpGet ("{id:int}")]
//        public async Task<IActionResult> GetById(int id) => Ok(await _productService.GetByIdAsync(id));

//        [HttpPost]
//        public async Task<IActionResult> Create(CreateProductDto dto)
//        {
//            await _productService.AddAsync(dto);
//            return Ok(new
//            {
//                message = "Product created successfully"
//            });
//        }

//        [HttpPut]
//        public async Task<IActionResult> Update(UpdateProductDto dto)
//        {
//            await _productService.UpdateAsync(dto);
//            return Ok();
//        }

//        [HttpDelete]
//        public async Task<IActionResult> Delete(int id)
//        {
//            await _productService.DeleteAsync(id);
//            return Ok();
//        }

//    }
//}

using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Clean_Architecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        // GET: api/Product/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            if (product == null)
                return NotFound(new { message = "Product not found" });

            return Ok(product);
        }

        // POST: api/Product
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductDto dto)
        {
            await _productService.AddAsync(dto);

            return StatusCode(201, new
            {
                message = "Product created successfully"
            });
        }

        // PUT: api/Product
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProductDto dto)
        {
            await _productService.UpdateAsync(dto);

            return Ok(new
            {
                message = "Product updated successfully"
            });
        }

        // DELETE: api/Product/1
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.DeleteAsync(id);

            return Ok(new
            {
                message = "Product deleted successfully"
            });
        }
    }
}
