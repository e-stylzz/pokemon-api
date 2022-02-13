using System;
using PokemonAPI.DTO;
using PokemonAPI.Models;
using AutoMapper;

namespace PokemonAPI.Profiles
{
	public class RegionProfile : AutoMapper.Profile
	{
		public RegionProfile()
		{
			CreateMap<Region, RegionDTO>()
				.ReverseMap();
		}
	}
}
