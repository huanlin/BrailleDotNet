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

string punctuation = """
    Punctuation:
      - Text: .
        Dots: 256
        Description: "Period, dot, decimal point."
      - Text: ...
        Dots: 256 256 256
        Description: "Ellipsis (刪節號)"
      - Text: ''''
        Dots: 3
        Description: 所有格符號
      - Text: '-'
        Dots: 36
        Description: "hyphen (連結號，若連續兩個則為破折號)"
    """;

/*
var deserializer = new DeserializerBuilder()    
    .WithNamingConvention(PascalCaseNamingConvention.Instance)
    .Build();

var p = deserializer.Deserialize<BrailleTable>(contractions);


Console.WriteLine(p?.Contractions[0].Text);
*/



// YAML string to deserialize
string yaml = @"
            Name: John
            Age: 30
        ";

// Create a deserializer
var deserializer = new DeserializerBuilder()
    .WithNamingConvention(CamelCaseNamingConvention.Instance)
    .Build();

// Deserialize YAML into a Person record
Person person = deserializer.Deserialize<Person>(yaml);

// Display the deserialized record
Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");


// Define a C# 9.0 record
public record Person(string Name, int Age);





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