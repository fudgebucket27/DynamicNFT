


using DynamicNFT.Controllers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});


// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    ApiKeyHelper._apiKey = Environment.GetEnvironmentVariable("WEATHERAPIKEY", EnvironmentVariableTarget.Machine);
}
else
{
    ApiKeyHelper._apiKey = Environment.GetEnvironmentVariable("APPSETTING_WEATHERAPIKEY");
}

app.UseCors("AllowAll");

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
