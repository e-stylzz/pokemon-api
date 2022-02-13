namespace PokemonAPI.Models;

public class PokemonRegion
{
    public int pokemonid { get; set; }
    public Pokemon? Pokemon { get; set; }
    public int RegionId { get; set; }
    public Region? Region { get; set; }
}

