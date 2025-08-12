using Kurochou.DI;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
        .AddJsonFile("appsettings.json", false, true)
        .AddJsonFile("appsettings.{builder.Environment.EnvironmentName}.json", true)
        .AddEnvironmentVariables();

builder.Services.AddDependencies(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
        app.UseSwagger();
        app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
