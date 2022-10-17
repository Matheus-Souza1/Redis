using Microsoft.EntityFrameworkCore;
using Redis.Infrastructure.Caching;
using Redis.Infrastructure.Persistence;
using Redis.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PersonDbContext>(o => o.UseInMemoryDatabase("RedisDb"));

builder.Services.AddScoped<ICachingService, CachingService>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();

builder.Services.AddStackExchangeRedisCache(o =>
{
    o.InstanceName = "person";
    o.Configuration = "localhost:6379";
});

builder.Services.AddControllers();
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

