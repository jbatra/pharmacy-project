using System.Net.NetworkInformation;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Nuvem.PharmacyManagementSystem.Pharmacy.Data;
using Nuvem.PharmacyManagementSystem.Pharmacy.Data.Data;
using Nuvem.PharmacyManagementSystem.Pharmacy.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
Assembly apiAssembly = Assembly.GetExecutingAssembly();
Assembly servicesAssembly = Assembly.Load("Nuvem.PharmacyManagementSystem.Pharmacy.Services");
Assembly dataAssembly = Assembly.Load("Nuvem.PharmacyManagementSystem.Pharmacy.Data");

builder.Services.AddAutoMapper(apiAssembly,servicesAssembly);

builder.Services.AddDbContext<PharmacyDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("EFConnectionString"),
        ef => ef.MigrationsAssembly("Nuvem.PharmacyManagementSystem.Pharmacy.Data")));

builder.Services.AddSwaggerGen(e => e.EnableAnnotations());
builder.Services.AddTransient<IPharmacyService, PharmacyService>();
builder.Services.AddTransient<IPharmacyRepository, PharmacyRepository>();

AppSettingsConfiguraion appConfig = new AppSettingsConfiguraion();
builder.Configuration.GetSection("ConnectionStrings").Bind(appConfig);
builder.Services.AddSingleton(appConfig);

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
