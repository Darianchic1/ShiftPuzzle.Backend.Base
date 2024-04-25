
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
 
builder.Services.AddSingleton<IOrderManager>(provider =>
{
    var optionsBuilder = new DbContextOptionsBuilder<OrderContext>();
    optionsBuilder.UseSqlite("Data Source=TaskDataBase.db"); 
    var orderContext = new OrderContext(optionsBuilder.Options);
    orderContext.Database.EnsureCreated(); 
    IOrderRepository orderRepository = new OrderRepository(orderContext);
    IOrderManager orderManager = new OrderManager(orderRepository);

    return orderManager;
});

builder.Services.AddSingleton<IAccountManager>(provider =>
{
    var optionsBuilder = new DbContextOptionsBuilder<UserContext>();
    optionsBuilder.UseSqlite("Data Source=AccountDataBase.db");
    var accountContext = new UserContext(optionsBuilder.Options);
    userContext.Database.EnsureCreated();
    IUserManager userManager = new UserManager(userContext);
    return userManager;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();

app.Run();
