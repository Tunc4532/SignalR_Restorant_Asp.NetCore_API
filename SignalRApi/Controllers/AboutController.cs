using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AboutController : ControllerBase
	{
		private readonly IAboutService _aboutService;
		public AboutController(IAboutService aboutService)
		{
			_aboutService = aboutService;
		}

		[HttpGet]
		public IActionResult AboutList()
		{
			var values = _aboutService.TGetListAll();
			return Ok(values);
		}

		[HttpPost]
		public IActionResult CreateAbout(CreateAbotDto createAbotDto)
		{
			About about = new About()
			{
				Description = createAbotDto.Description,
				ImageUrl = createAbotDto.ImageUrl,
				Tittle = createAbotDto.Tittle
			};
			_aboutService.TAdd(about);
			return Ok("Başarılı");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteAbout(int id)
		{
			var value = _aboutService.TGetById(id);
			_aboutService.TDelete(value);
			return Ok("Silindi");
		}

		[HttpPut]
		public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
		{
			About about = new About()
			{
				AboutID = updateAboutDto.AboutID,
				Description = updateAboutDto.Description,
				ImageUrl = updateAboutDto.ImageUrl,
				Tittle = updateAboutDto.Tittle
			};
			_aboutService.TUpdate(about);
			return Ok("Güncellendi");
		}

		[HttpGet("{id}")]
		public IActionResult GetAbout(int id)
		{
			var value = _aboutService.TGetById(id);
			return Ok(value);
		}


	}
}
