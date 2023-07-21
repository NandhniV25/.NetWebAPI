global using NotesAPI.Models;
using Microsoft.EntityFrameworkCore;
using NotesAPI.Data;
using NotesAPI.Mapping;
using NotesAPI.Repository;
using NotesAPI.Repository.IRepository;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region Configure CORS(Cross Origin Resource Sharing

builder.Services.AddCors(options =>
{
    options.AddPolicy("CustomPolicy", x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

#endregion

#region Configure Database

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

#endregion


#region Configure AutoMapper

builder.Services.AddAutoMapper(typeof(MapperProfile));

#endregion

#region Configure Country Repository - Interface and class

builder.Services.AddTransient<INotesRepository, NotesRepository>();

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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

#region use cors
app.UseCors("CustomPolicy");
#endregion

app.UseAuthorization();

app.MapControllers();

app.Run();
