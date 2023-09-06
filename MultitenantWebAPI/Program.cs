using Microsoft.EntityFrameworkCore;
using MultitenantWebAPI.Databases;
using MultitenantWebAPI.SwaggerFilters;
using MultitenantWebAPI.Tenants;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<List<Tenant>>(builder.Configuration.GetSection("Tenants"));

// Add services to the container.
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<TenantService>();
builder.Services.AddScoped<TenantProvider>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config =>
{
    config.OperationFilter<XTenantIdFilter>();
});

builder.Services.AddDbContext<OrdersDbContext>((sp, o) => 
{
    var tenantProvider = sp.GetRequiredService<TenantProvider>();
    var connectionString = tenantProvider.GetConnectionString();
    o.UseSqlServer(connectionString);
});

var app = builder.Build();

//var tenants = app.Configuration.GetSection("Tenants").Get<List<Tenant>>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
