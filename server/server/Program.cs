using Microsoft.EntityFrameworkCore;
using server.Data;               
using server.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirFrontend", policy =>
    {
        policy.WithOrigins("*") 
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var connectionString = builder.Configuration.GetConnectionString("SupabaseConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<server.Repositories.IUsuarioRepository, server.Repositories.UsuarioRepository>();
builder.Services.AddScoped<server.Services.IUsuarioService, server.Services.UsuarioService>();
builder.Services.AddControllers();

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(); 
}
app.UseCors("PermitirFrontend");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();