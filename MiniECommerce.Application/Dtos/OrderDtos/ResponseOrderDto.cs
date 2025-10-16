namespace MiniECommerce.Application.Dtos.OrderDtos;

public class ResponseOrderDto
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<OrderDetailResponseDto> Details { get; set; }
}
