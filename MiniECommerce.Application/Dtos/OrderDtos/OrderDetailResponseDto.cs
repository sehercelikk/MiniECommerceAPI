namespace MiniECommerce.Application.Dtos.OrderDtos;

public class OrderDetailResponseDto
{
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
