var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Quote> qoutes = new List<Quote>();

app.MapGet("/status", () =>
{
  return "A-OK!";
});

app.MapGet("/", () =>
{
  return qoutes;
});

app.MapPost("/", (Quote content) =>
{
  qoutes.Add(content);
  return Results.Created();
});

// app.MapPut("/", () =>
// {
//   return "Updating something";
// });

// app.MapDelete("/", () =>
// {
//   return "Deleting something";
// });

app.Run();
