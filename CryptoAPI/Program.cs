using ServiceStack.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Hosting;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Add CORS middleware to allow requests from all origins (for development purposes)
//app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());


//Configure the HTTP request pipeline.
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}





app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapGet("/Crypto", () => "Hello World v2!");
/*app.MapGet("/", () =>
{
    // Serve the index.html file from the wwwroot folder
    string indexPath = Path.Combine(app.Environment.ContentRootPath, "wwwroot", "index.html");
    return File.ReadAllText(indexPath);
});*/


app.MapGet("/", (IWebHostEnvironment env) => {
    // Serve the index.html file from the wwwroot folder
    return File.ReadAllText(Path.Combine(env.WebRootPath, "index.html"));
});

app.Run();
