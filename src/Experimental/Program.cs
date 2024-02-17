using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

string contractions = """
    Contractions:
      # Shortforms
      - Text: about
        Dots: 1 12
      - Text: above
        Dots: 1 12 1236
      - Text: according
        Dots: 1 14
    """;

var deserializer = new DeserializerBuilder()    
    .WithNamingConvention(PascalCaseNamingConvention.Instance)
    .Build();

//yml contains a string containing your YAML
var p = deserializer.Deserialize<BrailleTable>(contractions);

Console.WriteLine(p?.Contractions[0].Text); 


public class  BrailleTable
{
    public List<BrailleSymbol> Contractions { get; set; } = new ();
}

/// <summary>
/// A BrailleSymbol represents a basic unit of a braille text. It can be a character, a word, or even words.
/// This class is supposed to support multiple languages, but currently only English and Traditional Chinese are supported.
/// </summary>
public class BrailleSymbol
{
    public string Text { get; set; }
    public string Dots { get; set; }
}