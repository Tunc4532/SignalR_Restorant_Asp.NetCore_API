using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ProductDto;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SocialMediaController : ControllerBase
	{
		private readonly ISocialMediaService _socialMediaService;
		private readonly IMapper _mapper;

		public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
		{
			_socialMediaService = socialMediaService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult SocialMediaList()
		{
			var value = _mapper.Map<List<ResultSocialMediaDto>>(_socialMediaService.TGetListAll());
			return Ok(value);	
		}

		[HttpPost]
		public IActionResult CreateSocialMedia(AddSocialMediaDto addSocialMediaDto)
		{
			_socialMediaService.TAdd(new SocialMedia
			{
			    Icon = addSocialMediaDto.Icon,
				Tittle = addSocialMediaDto.Tittle,
				Url = addSocialMediaDto.Url
			});
			return Ok("Başarılı");
		}

		[HttpPut]
		public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
		{
			_socialMediaService.TUpdate(new SocialMedia
			{
				Icon = updateSocialMediaDto.Icon,
				Tittle = updateSocialMediaDto.Tittle,
				Url = updateSocialMediaDto.Url,
				SocialMediaID = updateSocialMediaDto.SocialMediaID
			});
			return Ok("Güncellendi");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteSocialMedia(int id)
		{
			var value = _socialMediaService.TGetById(id);
			_socialMediaService.TDelete(value);
			return Ok("Silindi");
		}

		[HttpGet("{id}")]
		public IActionResult GetSocialMedia(int id)
		{
			var value = _socialMediaService.TGetById(id);
			return Ok(value);

		}
	}
}
