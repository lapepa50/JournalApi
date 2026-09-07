using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/time", () => DateTimeOffset.Now);
app.MapGet("/echo", (string? msg) =>
{
    if (string.IsNullOrEmpty(msg))
    {
        return Results.BadRequest();
    }
    return Results.Ok(new
    {
        message = msg,
        length = msg.Length
    });
});

app.Run();
