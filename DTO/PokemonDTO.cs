using System;
using PokemonAPI.Models;

namespace PokemonAPI.DTO
{
	public class PokemonDTO
	{
		public int? id { get; set; }
		public string? name { get; set; }
		public string? imageUrl { get; set; }

		public virtual ICollection<RegionDTO>? Regions { get; set; }
	}
}

