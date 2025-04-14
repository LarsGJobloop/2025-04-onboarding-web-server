var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/status", () =>
{
  return "A-OK!";
});

app.MapPost("/", () =>
{
  return "Creating something";
});

app.MapPut("/", () =>
{
  return "Updating something";
});

app.MapDelete("/", () =>
{
  return "Deleting something";
});

app.Run();
