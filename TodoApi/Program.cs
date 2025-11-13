var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ Register your custom service
builder.Services.AddSingleton<TodoApi.Services.TodoService>();

var app = builder.Build();

// Enable Swagger for all environments
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo API v1");
    c.RoutePrefix = string.Empty; // optional - loads Swagger UI at root
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
