using dotnetEnsekTechChallenge.Data;
using dotnetEnsekTechChallenge.Middlewares;
using dotnetEnsekTechChallenge.Services.AccountService;
using dotnetEnsekTechChallenge.Services.MeterReading;
using Microsoft.EntityFrameworkCore;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:3000", "http://localhost:3000/").AllowAnyHeader()
                                                  .AllowAnyMethod();

                      });
});

// Add services to the container.

//Set Dependency Injection with service container
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(connectionString));
builder.Services.AddTransient<ExceptionHandlingMiddleware>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//transient singleton TOLEARN
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IMeterReadingService, MeterReadingService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlingMiddleware>();

// Custom status handling

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
