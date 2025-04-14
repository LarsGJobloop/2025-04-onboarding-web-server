using System.Text.Json;

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
  string quotesJson = File.ReadAllText("quotes.json");
  List<Quote> quotes = JsonSerializer.Deserialize<List<Quote>>(quotesJson);
  return quotes;
});

app.MapPost("/quotes", (Quote content) =>
{
  // Load existing data
  string oldQuotesJson = File.ReadAllText("quotes.json");
  List<Quote> oldQuotes = JsonSerializer.Deserialize<List<Quote>>(oldQuotesJson);

  oldQuotes.Add(content);

  // Write back to disk
  string newQuotesJson = JsonSerializer.Serialize(oldQuotes);
  File.WriteAllText("quotes.json", newQuotesJson);
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
