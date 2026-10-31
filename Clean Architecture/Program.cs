
using Application.Services;
using infrastructure.Data;
using infrastructure.Repositres;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;
using Application.Miappings;

var builder = WebApplication.CreateBuilder(args);


//added ApplicationDbContext on the below
builder.Services.AddDbContext<ApplicationDbContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("infrastructure")));



// added services and repositry in the program.cs that means i register the services in the main file
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepositry, ProductRepositry>();

builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderRepositry, OrderRepositry>();

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
