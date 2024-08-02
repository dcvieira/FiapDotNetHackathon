using Domain.Entities;
using Infrastructure.Persistence;
using Infrastructure;
using Application;
using API.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddIdentityApiEndpoints<ApplicationUser>()
           .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllers(options => options.Filters.Add<ApiExceptionFilterAttribute>());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();
        await initialiser.InitialiseAsync();
    }

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapIdentityApi<ApplicationUser>();
app.UseAuthorization();

app.MapControllers();

app.Run();
