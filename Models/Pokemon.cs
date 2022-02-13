namespace PokemonAPI.Models;
using PokemonAPI.DTO;

public class Pokemon
{
    public int? id { get; set; }
    public string? name { get; set; }
    public string? imageUrl { get; set; }

    public virtual ICollection<PokemonRegion>? PokemonRegions {get;set;}
}