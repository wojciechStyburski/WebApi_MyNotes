using Application.Dto;
using Application.Interfaces;
using Application.Mappings;
using Application.Services;
using Application.Validators;
using Domain.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Dodwanie us³ug do kontenera IOC
builder.Services.AddScoped<INoteRepository, NoteRepository>();
builder.Services.AddScoped<INoteService, NoteService>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

//Rejestracja paczki Fluent Validation do obs³ugi walidacji
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();

//Rejestracja serwisów do obs³ugi walidacji
builder.Services.AddScoped<IValidator<CreateNoteDto>, CreateNoteValidator>();
builder.Services.AddScoped<IValidator<UpdateNoteDto>, UpdateNoteValidator>();
builder.Services.AddScoped<IValidator<CreateUpdateCategoryDto>, CreateUpdateCategoryDtoValidator>();

//Rejestracja middleware do obs³ugi b³êdów
builder.Services.AddScoped<ErrorHandlingMiddleware>();

//Konfigurowanie kontekstu po³¹czenia z baz¹ danych
builder.Services.AddDbContext<MyNotesContext>
(
    option => option.UseSqlServer(builder.Configuration.GetConnectionString("MyNotesConnectionString"))
);

//Konfigurowanie AutoMappera
builder.Services.AddSingleton(AutoMapperConfig.Initialize());

//Dodanie obs³ugi swaggera
builder.Services.AddSwaggerGen(c =>
{
    //dodanie adnotacji
    c.EnableAnnotations();
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyNotes API", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
