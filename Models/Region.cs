namespace PokemonAPI.Models;

public class Region
{
    public int id { get; set; }
    public string? name { get; set; }

    public virtual ICollection<PokemonRegion>? PokemonRegions { get; set; }
}