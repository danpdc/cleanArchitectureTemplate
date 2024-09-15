using Physicube.Application.Extensions;
using Physiqube.API.Extensions;
using Physiqube.API.Filters;
using Physiqube.Infrastructure.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(corsBuilder =>
    {
        corsBuilder.WithOrigins("http://localhost:4200", "https://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.AddControllers(config =>
{
    config.Filters.Add(typeof(PhysiqubeExceptionHandler));
});
builder.Services.AddSwagger();
builder.RegisterAuthentication();
builder.Services.AddApplicationServices();
builder.Services.AddDataServices(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();