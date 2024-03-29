using TeatroWeb.Data;
using TeatroWeb.Business;
using Microsoft.EntityFrameworkCore;
using TeatroWeb.common;

    var builder = WebApplication.CreateBuilder(args);
    var connectionString = builder.Configuration.GetConnectionString("ServerDB");
// Context
    builder.Services.AddDbContext<TeatroBackendContext>(options =>
        options.UseSqlServer(connectionString));

    // Scoped Services
    // Ticket
    builder.Services.AddScoped<ITicketService, TicketService>(); 
    builder.Services.AddScoped<ITicketRepository, TicketEFRepository>();

    // Play
    builder.Services.AddScoped<IPlayService, PlayService>(); 
    builder.Services.AddScoped<IPlayRepository, PlayEFRepository>();

    // User
    builder.Services.AddScoped<IUserService, UserService>(); 
    builder.Services.AddScoped<IUserRepository, UserEFRepository>();

    builder.Services.AddScoped<IlogError,LogErrorClass>();

    builder.Services.AddControllers();

    

    // Add services to the container.
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddAuthorization();


    var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
    // Mirar para que el isdevelopment lo pille en Docker
    app.UseSwagger();
    app.UseSwaggerUI();
// }

    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.UseCors(options =>
{
    options
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
});
    app.MapControllers();
    app.Run();