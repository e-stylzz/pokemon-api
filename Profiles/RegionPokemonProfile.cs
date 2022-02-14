using System;
using PokemonAPI.DTO;
using PokemonAPI.Models;
using AutoMapper;

namespace PokemonAPI.Profiles
{
	public class RegionPokemonProfile : AutoMapper.Profile
	{
		public RegionPokemonProfile()
		{
			CreateMap<Region, RegionPokemonDTO>()
				.ForMember(dto => dto.Pokemon, c => c.MapFrom(c => c.PokemonRegions.Select(cs => cs.Pokemon)));
		}
	}
}
