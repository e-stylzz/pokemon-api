using System;
using PokemonAPI.Models;

namespace PokemonAPI.DTO
{
	public class PokemonSummaryDTO
	{
		public int? id { get; set; }
		public string? name { get; set; }
		public string? imageUrl { get; set; }
	}
}

