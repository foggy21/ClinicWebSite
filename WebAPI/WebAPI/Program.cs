using DAL;
using DAL.Repositories;
using Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Service.Implementations;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseNpgsql($"Host=localhost;Port=5433;Database=clinicdb;Username=postgres;Password=#Foggy38515825"));

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<UserService>();

builder.Services.AddTransient<IDoctorRepository, DoctorRepository>();
builder.Services.AddTransient<DoctorService>();

builder.Services.AddTransient<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddTransient<AppointmentService>();

builder.Services.AddTransient<ITimetableRepository, TimetableRepository>();
builder.Services.AddTransient<TimetableService>();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ToDo API",
        Description = "An ASP.NET Core Web API for managing ToDo items",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseSwagger(options =>
    {
        options.SerializeAsV2 = true;
    });
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllers();

app.Run();