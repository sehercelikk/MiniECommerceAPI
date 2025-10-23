using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MiniECommerce.Application.AddDependenciesScoped;
using MiniECommerce.Application.AutoMapper;
using MiniECommerce.Application.Validations.CategoryValidations;
using MiniECommerce.Application.Validations.ProductValidations;
using MiniECommerce.Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddDbContextPool<ETicaretContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddAutoMapper(typeof(ETicaretProfile).Assembly);


builder.Services.AddDependenciesScoped();

builder.Services.AddControllers();


builder.Services.AddValidatorsFromAssembly(typeof(AddCategoryValidation).Assembly);
//builder.Services.AddValidatorsFromAssembly(typeof(CreateProductValidation).Assembly);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
