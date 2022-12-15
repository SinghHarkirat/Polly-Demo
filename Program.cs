using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly_Demo.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddSingleton<ClientPolicy>(new ClientPolicy());

builder.Services.AddSingleton<ITodoService, TodoService>();
builder.Services.AddHttpClient("JsonPlaceholder", client =>
{
    client.BaseAddress = new System.Uri("https://jsonplaceholder.typicode.com");
})
.AddTransientHttpErrorPolicy(policy => policy.WaitAndRetryAsync(3, _ => TimeSpan.FromSeconds(5)));

var app = builder.Build();

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
