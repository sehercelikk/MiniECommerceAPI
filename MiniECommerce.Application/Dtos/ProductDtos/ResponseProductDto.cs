﻿namespace MiniECommerce.Application.Dtos.ProductDtos;

public class ResponseProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string CategoryName { get; set; }
}
