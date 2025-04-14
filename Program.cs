var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () =>
{
  Console.WriteLine("Whoo! We got a message!");
  return "Hello World!";
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
