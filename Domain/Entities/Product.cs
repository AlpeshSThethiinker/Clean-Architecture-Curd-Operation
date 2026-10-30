using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product
    {
        public int Id { get; set; } 
        public required string Name { get; set; }
        public decimal Price { get; set; }  

    }
}
