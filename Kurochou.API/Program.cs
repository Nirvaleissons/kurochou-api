using Kurochou.DI;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDependencies(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
        app.MapOpenApi();
        app.MapScalarApiReference(options =>
        {
                options.Title = "Scalar PORRA";
                options.Theme = ScalarTheme.Purple;
        });
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
