using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StackOverflowAPI.Entities;
using StackOverflowAPI.Seeder;
using StackOverflowAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyStackContext>(
    option => option
    .UseSqlServer(builder.Configuration.GetConnectionString("MyConnection"))
    );

builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<QuestionSeeder>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using var scope = app.Services.CreateScope();

var dbContext = scope.ServiceProvider.GetService<MyStackContext>();
var seeder = scope.ServiceProvider.GetRequiredService<QuestionSeeder>();
seeder.Seed();

var pendingMigrations = dbContext.Database.GetPendingMigrations();
if (pendingMigrations.Any())
{
    dbContext.Database.Migrate();
}


app.MapPost("/question", (IQuestionService service, [FromBody] Question quest) => service.Create(quest));

app.MapGet("/api/questions", (IQuestionService service) => service.getAll());


app.Run();


