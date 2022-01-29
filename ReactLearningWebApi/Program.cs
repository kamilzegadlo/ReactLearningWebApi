using Microsoft.EntityFrameworkCore;
using ReactLearningWebApi.Domain;
using ReactLearningWebApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbAppRepositoryContext>(
        options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection", b => b.MigrationsAssembly("ReactLearningWebApi.Repositories")));

builder.Services.AddSingleton<IDBContextFactory, DBContextFactory>();
builder.Services.AddSingleton<IRepository<ProjectEntity>, ProjectRepository>();
builder.Services.AddSingleton<IProjectService, ProjectService>();

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
