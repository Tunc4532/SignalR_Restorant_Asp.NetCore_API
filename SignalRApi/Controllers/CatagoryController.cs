using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CatagoryDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CatagoryController : ControllerBase
	{
		private readonly ICatagoryService _catagoryService;
		private readonly IMapper _mapper;

		public CatagoryController(ICatagoryService catagoryService, IMapper mapper)
		{
			_catagoryService = catagoryService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult CatagoryList()
		{
			var value = _mapper.Map<List<ResultCatagoryDto>>(_catagoryService.TGetListAll());
			return Ok(value);
		}

		[HttpGet("SendCatagoryCount")]
		public IActionResult CatagoryCount()
		{
			return Ok(_catagoryService.TSendCatagoryCount());
		}

        [HttpGet("ActiveCatagoryCount")]
        public IActionResult ActiveCatagoryCount()
        {
            return Ok(_catagoryService.TActiveCatagoryCount());
        }

        [HttpGet("PasiveCatagoryCount")]
        public IActionResult PasiveCatagoryCount()
        {
            return Ok(_catagoryService.TPasiveCatagoryCount());
        }

        [HttpPost]
		public IActionResult CreateCatagory(AddCatagoryDto addCatagoryDto)
		{
			_catagoryService.TAdd(new Catagory
			{
				CatagoryName = addCatagoryDto.CatagoryName,
				Status = true
			});
			return Ok("Başarılı");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteCatagory(int id)
		{
			var value = _catagoryService.TGetById(id);
			_catagoryService.TDelete(value);
			return Ok("Silindi");
		}

		[HttpPut]
		public IActionResult UpdateCatagory(UpdateCatagoryDto updateCatagoryDto)
		{
			_catagoryService.TUpdate(new Catagory
			{
				CatagoryID = updateCatagoryDto.CatagoryID,
				CatagoryName = updateCatagoryDto.CatagoryName,
				Status = updateCatagoryDto.Status
			});
			return Ok("Güncellendi");
		}
		[HttpGet("{id}")]
		public IActionResult GetCatagory(int id)
		{
			var value = _catagoryService.TGetById(id);
			return Ok(value);
		}

	}
}
