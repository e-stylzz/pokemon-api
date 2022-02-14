using System;
using PokemonAPI.DTO;

namespace PokemonAPI.DTO
{
	public class RegionPokemonDTO
	{
		public string? name { get; set; }

		public virtual ICollection<PokemonSummaryDTO>? Pokemon { get; set; }

	}
}

