using Microsoft.EntityFrameworkCore;
using Serilog;
using World.API.Common;
using World.API.Data;
using World.API.Repository;
using World.API.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region Configure CORS

builder.Services.AddCors(Options =>
{
    Options.AddPolicy("CustomPolicy", x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()); //get post put delete
});

#endregion


#region Configure AutoMapper

builder.Services.AddAutoMapper(typeof(MappingProfile));

#endregion

#region Configure Country Repository - Interface and class

builder.Services.AddTransient<ICountryRepository, CountryRepository>();

#endregion

#region Configure State Repository - Interface and class

builder.Services.AddTransient<IStatesRepository, StatesRepository>();

#endregion

#region Configure Generic Repository - Interface and class

builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

#endregion

#region Configure Serilog

builder.Host.UseSerilog((context, config) =>
{
    config.WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day);

    if (context.HostingEnvironment.IsProduction() == false)
    {
        config.WriteTo.Console();
    }
});

#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseCors("CustomPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
