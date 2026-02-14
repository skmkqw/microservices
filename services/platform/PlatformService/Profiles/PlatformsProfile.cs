using AutoMapper;
using PlatformService.DTOs;
using PlatformService.Models;

namespace PlatformService.Profiles;

class PlatformsProfile : Profile
{
	public PlatformsProfile()
	{
		CreateMap<Platform, PlatformReadDto>();
		CreateMap<PlatformCreateDto, Platform>();
	}
}