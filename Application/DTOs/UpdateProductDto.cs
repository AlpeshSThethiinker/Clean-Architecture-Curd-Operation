using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public record UpdateProductDto(int Id, string Name, decimal Price);

}
