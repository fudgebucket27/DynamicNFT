using DynamicNFT.Models;

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

builder.Services.AddSingleton<IWeatherClient,WeatherClient>();
builder.Services.AddSingleton<IGasClient, GasClient>();
// Add services to the container.

builder.Services.AddControllers();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    ApiKeyHelper.WeatherApiKey = Environment.GetEnvironmentVariable("WEATHERAPIKEY", EnvironmentVariableTarget.Machine);

}
else
{
    ApiKeyHelper.WeatherApiKey = Environment.GetEnvironmentVariable("APPSETTING_WEATHERAPIKEY");
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseCors("AllowAll");

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
