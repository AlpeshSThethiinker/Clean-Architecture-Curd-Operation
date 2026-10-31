using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.OrderFolder
{
    public class UpdateOrderDto
    {
        public string OrderName { get; set; } = string.Empty;
        public decimal OrderPrice { get; set; }
    }
}
