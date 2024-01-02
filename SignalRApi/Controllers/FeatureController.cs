using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.DiscountDto;
using SignalR.DtoLayer.FeatureDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FeatureController : ControllerBase
	{
		private readonly IFeatureService _featureService;
		private readonly IMapper _mapper;

		public FeatureController(IFeatureService featureService, IMapper mapper)
		{
			_featureService = featureService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult FeatureList()
		{
			var values = _mapper.Map<List<ResultFeatureDto>>(_featureService.TGetListAll());
			return Ok(values);
		}

		[HttpPost]
		public IActionResult CreateFeature(AddFeatureDto addFeatureDto)
		{
			_featureService.TAdd(new Feature
			{
				Description1 = addFeatureDto.Description1,
				Description2 = addFeatureDto.Description2,
				Description3 = addFeatureDto.Description3,
				Tittle1 = addFeatureDto.Tittle1,
				Tittle2 = addFeatureDto.Tittle2,
				Tittle3 = addFeatureDto.Tittle3
			});
			return Ok("Başarılı");
		}

		[HttpPut]
		public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
		{
			_featureService.TUpdate(new Feature
			{
				Description1 = updateFeatureDto.Description1,
				Description2 = updateFeatureDto.Description2,
				Description3 = updateFeatureDto.Description3,
				Tittle1 = updateFeatureDto.Tittle1,
				Tittle2 = updateFeatureDto.Tittle2,
				Tittle3 = updateFeatureDto.Tittle3,
				FeatureID = updateFeatureDto.FeatureID
			});
			return Ok("Güncellendi");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteFeature(int id)
		{
			var values = _featureService.TGetById(id);
			_featureService.TDelete(values);
			return Ok("Silindi");

		}

		[HttpGet("{id}")]
		public IActionResult GetFeature(int id)
		{
			var values = _featureService.TGetById(id);
			return Ok(values);
		}

	}
}
