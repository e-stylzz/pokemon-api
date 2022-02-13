namespace PokemonAPI.Models;

public class Card
{
    public string? id { get; set; }
    public string? name { get; set; }
    public string? setId { get; set; }
    public int? hp { get; set; }
    public int? number { get; set; }
    public int? pokedexId { get; set; }
    public string? type { get; set; }
    public string? supertype { get; set; }
    public string? strength { get; set; }
    public string? strengthValue { get; set; }
    public string? weakness { get; set; }
    public string? weaknessValue { get; set; }
    public string? imageSmall { get; set; }
    public string? imageLarge { get; set; }

    public virtual ICollection<Attack>? Attacks { get; set; }
}