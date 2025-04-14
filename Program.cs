var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Quote> qoutes = new List<Quote>();

app.UseDefaultFiles();
app.UseStaticFiles();

// Define enpoints
app.MapGet("/status", () =>
{
  return "A-OK!";
});

app.MapGet("/quotes", () =>
{
  return qoutes;
});

app.MapPost("/quotes", (Quote content) =>
{
  qoutes.Add(content);
  return Results.Created();
});

// app.MapPut("/quotes", () =>
// {
//   return "Updating something";
// });

// app.MapDelete("/quotes", () =>
// {
//   return "Deleting something";
// });

app.Run();
