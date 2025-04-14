var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Define enpoints
app.MapGet("/status", () =>
{
  return "A-OK!";
});

app.MapGet("/quotes", () =>
{
  return QuoteService.GetAllQuotes();
});

app.MapPost("/quotes", (Quote content) =>
{
  QuoteService.SaveQuote(content);
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
