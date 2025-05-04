using APIPruebaTecnicav2.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var provider = builder.Configuration["DatabaseSettings:Provider"];
var connectionString = builder.Configuration["DatabaseSettings:ApiConnection"];
builder.Services.AddDbContext<ApiDbContext>(options =>
{
    switch (provider)
    {
        case "SQL":
            options.UseSqlServer(connectionString);
            break;
        case "MYSQL":
            options.UseMySql(connectionString,ServerVersion.AutoDetect("ApiConnection")); 
            break;
        case "POSTGRESQL":
            options.UseNpgsql(connectionString);
            break;
        default :
            throw new Exception($"Proveedor de base de datos no soportado:{provider}");
            
    }
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

//using(var scope = app.Services.CreateScope())
//{
    //var datacontext = scope.ServiceProvider.GetRequiredService<ApiDbContext>();
    //datacontext.Database.Migrate();
//}


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
