using WEB_253502_BARANOVSKY.API.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Sqlite;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(connectionString));
var app = builder.Build();
app.UseHttpsRedirection();  
app.UseStaticFiles();
app.UseRouting();



app.Run();
