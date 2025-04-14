using System.Text.Json;

// Reading from a file as well as blindly parsing it to JSON
// without checking that they succeed are not good.
// You are adviced to check for errors and propogate them
// to the place that can take action and fix them.

public class QuoteService
{
  public static List<Quote> GetAllQuotes()
  {
    string quotesJson = File.ReadAllText("quotes.json");
    return JsonSerializer.Deserialize<List<Quote>>(quotesJson);
  }

  public static void SaveQuote(Quote quote)
  {
    // Load existing data
    string oldQuotesJson = File.ReadAllText("quotes.json");
    List<Quote> oldQuotes = JsonSerializer.Deserialize<List<Quote>>(oldQuotesJson);

    oldQuotes.Add(quote);

    // Write back to disk
    string newQuotesJson = JsonSerializer.Serialize(oldQuotes);
    File.WriteAllText("quotes.json", newQuotesJson);
  }
}
