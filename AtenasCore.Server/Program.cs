using AtenasCore.Server.Data;
using AtenasCore.Server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});;
builder.Services.AddControllers();

builder.Services.AddIdentity<AppUser,IdentityRole>(option =>{
    option.Password.RequireDigit=true;
    option.Password.RequireLowercase=true;
    option.Password.RequireUppercase=true;
    option.Password.RequireNonAlphanumeric=true;
    option.Password.RequiredLength=12;
}).AddEntityFrameworkStores<ApplicationDBContext>();

var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/openapi/v1.json", "My API v1");
    });
}

app.UseHttpsRedirection();

app.MapControllers();
app.Run();
