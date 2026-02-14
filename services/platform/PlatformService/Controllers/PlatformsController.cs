using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.DTOs;
using PlatformService.Models;

namespace PlatformService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlatformsController : ControllerBase
{
	private readonly IMapper _mapper;

	private readonly IPlatformRepository _platformRepository;

	public PlatformsController(IMapper mapper, IPlatformRepository platformRepository)
	{
		_mapper = mapper;
		_platformRepository = platformRepository;
	}

	[HttpGet]
	public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
	{
		Console.WriteLine("--> Getting a list of platforms");

		var platforms = _platformRepository.GetPlatforms();

		return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platforms));
	}

	[HttpGet("{id}", Name = "GetPlatformById")]
	public ActionResult<PlatformReadDto> GetPlatformById(int id)
	{
		var platformItem = _platformRepository.GetPlatformById(id);
		if (platformItem != null)
		{
			return Ok(_mapper.Map<PlatformReadDto>(platformItem));
		}

		return NotFound();
	}

	[HttpPost]
	public ActionResult<PlatformReadDto> CreatePlatform(PlatformCreateDto platformCreateDto)
	{
		var platformModel = _mapper.Map<Platform>(platformCreateDto);
		_platformRepository.CreatePlatform(platformModel);
		_platformRepository.SaveChanges();

		var platformReadDto = _mapper.Map<PlatformReadDto>(platformModel);

		return CreatedAtRoute(nameof(GetPlatformById), new { platformReadDto.Id }, platformReadDto);
	}
}

