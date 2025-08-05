using DesignCakesApp;
using DesignCakesApp.Core.Interfaces;
using DesignCakesApp.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AppDI(builder.Configuration);
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();
builder.Services.AddScoped<ILovedOnesRepository, LovedOnesRepository>();
builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
builder.Services.AddScoped<IProductPricesRepository, ProductPricesRepository>();
builder.Services.AddScoped<IPaymentsRepository, PaymentsRepository>();
builder.Services.AddScoped<IPaymentsTypesRepository, PaymentTypesRepository>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IOrderStatusesRepository, OrderStatusesRepository>();
builder.Services.AddScoped<IRolesRepository, RolesRepository>();
builder.Services.AddScoped<IProductSizeRepository, ProductSizeRepository>();
builder.Services.AddScoped<ILabelsRepository, LabelsRepository>();
builder.Services.AddScoped<ICustomerComplaintsRepository, CustomerComplaintRepository>();
builder.Services.AddScoped<ISuppliersRepository, SuppliersRepository>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy
            .WithOrigins("http://localhost:3000", "http://localhost:85")   // React dev server
            .AllowAnyHeader()                        // allow Authorization, Content-Type, etc.
            .AllowAnyMethod()                        // GET, POST, PUT, DELETE…
            .AllowCredentials();                     // if you need cookies or auth headers
    });
});
// Add more as needed

// Add more as needed


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();                // 1. Routing first
app.UseCors("AllowReactApp");   // 2. CORS AFTER routing
app.UseAuthorization();         // 3. Authorization if needed
app.MapControllers();           // 4. Map controllers last

app.Run();
