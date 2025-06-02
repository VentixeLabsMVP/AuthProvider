var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();



//added
builder.Services.AddHttpClient();
builder.Services.AddCors(x =>
{
    x.AddPolicy("AllowAll", x =>
    {
        x.AllowAnyOrigin();
        x.AllowAnyHeader();
        x.AllowAnyMethod();
    });
});

var app = builder.Build();

app.MapOpenApi();
app.UseHttpsRedirection();
app.UseCors("AllowAll");//added
app.UseAuthentication();//added
app.UseAuthorization();
app.MapControllers();
app.Run();
