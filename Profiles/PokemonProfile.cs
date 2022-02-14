using System;
using AutoMapper;
using PokemonAPI.DTO;
using PokemonAPI.Models;

namespace PokemonAPI.Profiles
{
	public class PokemonProfile : AutoMapper.Profile
	{
		public PokemonProfile()
		{
			CreateMap<Pokemon, PokemonDTO>()
				.ForMember(dto => dto.Regions, c => c.MapFrom(c => c.PokemonRegions.Select(cs => cs.Region)));

			CreateMap<Pokemon, PokemonSummaryDTO>()
				.ReverseMap();
		}
	}
}

