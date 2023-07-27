global using first.Models;
global using first.Services.CharacterServices;
global using first.DTOs.Character;
global using Microsoft.EntityFrameworkCore;
global using first.Data;
global using first.DTOs.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region Configure Database

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection"); //DefaultConnection in appsettings.json

builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));

#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = """Standard Authorization header using the Bearer scheme.Example: "bearer {token}" """,
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    c.OperationFilter<SecurityRequirementsOperationFilter>();
});

#region Configure Automapper

builder.Services.AddAutoMapper(typeof(Program).Assembly);

#endregion

#region Configure Icharacterservice and CharacterService

builder.Services.AddScoped<ICharacterServices, CharacterServices>();
#endregion

#region Configure IAuthRepository and AuthRepository

builder.Services.AddScoped<IAuthRepository, AuthRepository>();
#endregion

#region Configure authentication middleware and attribute

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options=>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8
            .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value!)), //unary postfix operation - null forgiving
            ValidateIssuer = false,
            ValidateAudience = false

        };
    });
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
