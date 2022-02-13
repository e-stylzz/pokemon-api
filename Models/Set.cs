namespace PokemonAPI.Models;

public class Set
{
    public string? id { get; set; }
    public string? name { get; set; }
    public string? series { get; set; }
    public int? printedTotal { get; set; }
    public int? total { get; set; }
    public string? code { get; set; }
    public DateTime? releaseDate { get; set; }
    public string? symbolLink { get; set; }
    public string? logoLink { get; set; }
}