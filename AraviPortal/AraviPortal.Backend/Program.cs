var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer(); // Necesario para que Swagger pueda explorar tus endpoints
builder.Services.AddSwaggerGen(); // Agrega los servicios de generación de Swagger
builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger(); // Habilita el middleware de generación de documentos Swagger JSON
    app.UseSwaggerUI(); // Habilita el middleware de Swagger UI (la interfaz web)
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();