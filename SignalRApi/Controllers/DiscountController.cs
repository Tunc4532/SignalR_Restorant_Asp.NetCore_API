using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ContactDto;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntityLayer.Entities;
using System.Net.Http;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DiscountController : ControllerBase
	{
		private readonly IDiscountService _discountService;
		private readonly IMapper _mapper;
		public DiscountController(IDiscountService discountService, IMapper mapper)
		{
			_discountService = discountService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult DiscountList()
		{
			var value = _mapper.Map<List<ResultDiscountDto>>(_discountService.TGetListAll());
			return Ok(value);
		}

		[HttpPost]
		public IActionResult CreateDiscount(AddDiscountDto addDiscountDto)
		{
			_discountService.TAdd(new Discount
			{
				Amount = addDiscountDto.Amount,
				Description = addDiscountDto.Description,
				ImageUrl = addDiscountDto.ImageUrl,
				Tittle = addDiscountDto.Tittle,
				Status = addDiscountDto.Status
			});
			return Ok("Başarılı");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteDiscount(int id)
		{
			var values = _discountService.TGetById(id);
			_discountService.TDelete(values);
			return Ok("Silindi");
		}

		[HttpPut]
		public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
		{
			_discountService.TUpdate(new Discount
			{
				Amount = updateDiscountDto.Amount,
				Description = updateDiscountDto.Description,
				ImageUrl = updateDiscountDto.ImageUrl,
				Tittle = updateDiscountDto.Tittle,
				DiscountID = updateDiscountDto.DiscountID,
				Status = updateDiscountDto.Status
			});
			return Ok("Güncellendi");
		}

		[HttpGet("{id}")]
		public IActionResult GetDiscount(int id)
		{
			var value = _discountService.TGetById(id);
			return Ok(value);
		}

        [HttpGet("ChangeStatusToTrue")]
        public IActionResult ChangeStatusToTrue(int id)
        {
			_discountService.TChangeStatusToTrue(id);
			return Ok("İşlem Başarılı");
        }

		[HttpGet("ChangeStatusToFalse")]
		public IActionResult ChangeStatusToFalse(int id)
		{
			_discountService.TChangeStatusToFalse(id);
			return Ok("İşlem Başarılı");
		}
		[HttpGet("GetListStatusByTrue")]
		public IActionResult GetListStatusByTrue()
		{
			return Ok(_discountService.TGetListStatusByTrue());
		}
    }
}
