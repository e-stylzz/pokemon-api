namespace PokemonAPI.Models;

public class Attack
{
    public int id { get; set; }
    public string? cardid { get; set; }
    public string? name { get; set; }
    public int? damage { get; set; }
    public string? text { get; set; }
    public int? damage_self { get; set; }
}