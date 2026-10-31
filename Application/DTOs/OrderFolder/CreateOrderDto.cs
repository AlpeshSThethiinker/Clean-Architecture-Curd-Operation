using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.OrderFolder
{
    public class CreateOrderDto
    {
        public string OrderName { get; set; } = string.Empty;
        public string OrderPrice { get; set; } = string.Empty;

    }
}

//namespace Application.DTOs.OrderFolder
//{
//    public record CreateProductDto(string Name, decimal price);




//}
