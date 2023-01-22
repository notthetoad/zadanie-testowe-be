using TestApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder => {
                    builder.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()
                    .WithOrigins("http://localhost:5173");
            });
        });
builder.Services.AddTransient<IRandomUserService, RandomUserService>();

var app = builder.Build();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
