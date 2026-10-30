
using Application.Services;
using infrastructure.Data;
using infrastructure.Repositres;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;
using Application.Miappings;

var builder = WebApplication.CreateBuilder(args);


//added ApplicationDbContext on the below
builder.Services.AddDbContext<ApplicationDbContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<IProductRepositry, ProductRepositry>();

//builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddMaps(typeof(MappingProfile).Assembly);
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

//add swagger in the program 
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
