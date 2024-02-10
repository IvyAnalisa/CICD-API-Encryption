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
app.MapGet("/Hello", () => "Hello World v2!");
/*app.MapGet("/", () =>
{
    // Serve the index.html file from the wwwroot folder
    string indexPath = Path.Combine(app.Environment.ContentRootPath, "wwwroot", "index.html");
    return File.ReadAllText(indexPath);
});*/

/*
app.MapGet("/", (IWebHostEnvironment env) => {
    // Serve the index.html file from the wwwroot folder
    return File.ReadAllText(Path.Combine(env.WebRootPath, "index.html"));
});*/
app.MapGet("/Crypto", () =>
{
    string htmlString = @"
    <!DOCTYPE html>
    <html lang=""en"">
    <head>
        <meta charset=""UTF-8"">
        <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
        <title>Encryption and Decryption</title>
    </head>
    <body>
        <h1>Encryption and Decryption</h1>
        <form id=""cryptoForm"">
            <label for=""text"">Text:</label>
            <input type=""text"" id=""text"" name=""text"" required><br><br>
            <label for=""operation"">Operation:</label>
            <select id=""operation"" name=""operation"" required>
                <option value=""encrypt"">Encrypt</option>
                <option value=""decrypt"">Decrypt</option>
            </select><br><br>
            <button type=""submit"">Submit</button>
        </form>
        <div id=""result""></div>

        <script>
            const form = document.getElementById('cryptoForm');
            const resultDiv = document.getElementById('result');

            form.addEventListener('submit', async (e) => {
                e.preventDefault();

                const formData = new FormData(form);
                const text = formData.get('text');
                const operation = formData.get('operation');

                try {
                    const requestData = { text }; // Include the 'text' field
                    const response = await fetch(`/crypto/${operation}`, {
                        method: 'POST',
                        headers: {
                            'Content-Type': 'application/json'
                        },
                        body: JSON.stringify(text)
                    });

                    const data = await response.json();
                    resultDiv.innerHTML = `<p>${operation}ed Text: ${data[operation + 'edText']}</p>`;
                } catch (error) {
                    console.error('Error:', error);
                    resultDiv.innerHTML = `<p>Error: ${error.message}</p>`;
                }
            });
        </script>
    </body>
    </html>";

    Results.Content(htmlString, "text/html");
});
app.MapGet("/helloweb", () => Results.Content(" <h1>Encryption and Decryption</h1>\r\n        <form id=\"cryptoForm\">\r\n            <label for=\"text\">Text:</label>\r\n            <input type=\"text\" id=\"text\" name=\"text\" required><br><br>\r\n            <label for=\"operation\">Operation:</label>\r\n            <select id=\"operation\" name=\"operation\" required>\r\n                <option value=\"encrypt\">Encrypt</option>\r\n                <option value=\"decrypt\">Decrypt</option>\r\n            </select><br><br>\r\n            <button type=\"submit\">Submit</button>\r\n        </form>\r\n        <div id=\"result\"></div>\r\n\r\n        <script>\r\n            const form = document.getElementById('cryptoForm');\r\n            const resultDiv = document.getElementById('result');\r\n\r\n            form.addEventListener('submit', async (e) => {\r\n                e.preventDefault();\r\n\r\n                const formData = new FormData(form);\r\n                const text = formData.get('text');\r\n                const operation = formData.get('operation');\r\n\r\n                try {\r\n                    const requestData = { text }; // Include the 'text' field\r\n                    const response = await fetch(`/crypto/${operation}`, {\r\n                        method: 'POST',\r\n                        headers: {\r\n                            'Content-Type': 'application/json'\r\n                        },\r\n                        body: JSON.stringify(text)\r\n                    });\r\n\r\n                    const data = await response.json();\r\n                    resultDiv.innerHTML = `<p>${operation}ed Text: ${data[operation + 'edText']}</p>`;\r\n                } catch (error) {\r\n                    console.error('Error:', error);\r\n                    resultDiv.innerHTML = `<p>Error: ${error.message}</p>`;\r\n                }\r\n            });\r\n        </script>", "text/html"));

app.Run();
