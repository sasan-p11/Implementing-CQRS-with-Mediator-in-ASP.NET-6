
using Appllication.Genres;
using Appllication.Mapper;
using Appllication.Validators;
using Domain.Data;
using Domain.DTO.GenresDTO;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Migrations;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddCors();
builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddMediatR(typeof(List.Handler).GetTypeInfo().Assembly);
builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
//builder.Services.AddScoped(typeof(IValidator), typeof(GenreDTOValidator));;
builder.Services.AddMvc()
  .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<GenreDTOValidator>());
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
