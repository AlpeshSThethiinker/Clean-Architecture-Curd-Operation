using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public required string OrderName { get; set; }
        public decimal OrderPrice { get; set; }
    }

}
