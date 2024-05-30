using Inventory.Domain.Interfaces;
using Inventory.Infrastructure;
using Inventory.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.Configure<DatabaseSetting>(builder.Configuration.GetSection("InventoryDatabase"));
builder.Services.AddSingleton<IItemService, ItemService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();