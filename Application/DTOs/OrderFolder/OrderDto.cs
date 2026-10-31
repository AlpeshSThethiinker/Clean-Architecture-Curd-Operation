
namespace Application.DTOs.OrderDtos
{
    public record OrderDto
    {
        public int Id { get; set; }
        public string OrderName { get; set; } = string.Empty;
        public string OrderPrice { get; set; } = string.Empty;
    }
}



