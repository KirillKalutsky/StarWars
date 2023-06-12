using Common.DataLayer;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Converters;
using StarWars.Api.Contexts;
using StarWars.Api.DataLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
        options.SerializerSettings.Converters.Add(new StringEnumConverter()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGenNewtonsoftSupport();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbContext, StarWarsContext>(optionsBuilder =>
{
    optionsBuilder.UseSqlite(builder.Configuration.GetConnectionString("StarWarsConnection"));
});

builder.Services.AddScoped<IWriteDbContext<IStarWarsEntity>, WriteDbContext<IStarWarsEntity>>();
builder.Services.AddScoped<IReadDbContext<IStarWarsEntity>, ReadDbContext<IStarWarsEntity>>();
builder.Services.AddScoped<AppRequestContext>();

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
