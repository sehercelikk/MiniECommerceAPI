﻿namespace MiniECommerce.Application.Dtos.OrderDtos;

public class CreateOrderDto
{
    public int UserId { get; set; }
    public List<OrderItemDto> Items { get; set; }
}
