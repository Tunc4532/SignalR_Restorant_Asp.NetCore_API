using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestimonialController : ControllerBase
	{
		private readonly ITestimonialService _testimonialService;
		private readonly IMapper _mapper;

		public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
		{
			_testimonialService = testimonialService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult TestimonialLİst()
		{
			var value = _mapper.Map<List<ResultTestimonialDto>>(_testimonialService.TGetListAll());
			return Ok(value);
		}

		[HttpPost]
		public IActionResult CreateTestimonial(AddTestimonialDto addTestimonialDto)
		{
			_testimonialService.TAdd(new Testimonial
			{
				Comment = addTestimonialDto.Comment,
				ImageUrl = addTestimonialDto.ImageUrl,
				Name = addTestimonialDto.Name,
				Status = addTestimonialDto.Status,
				Tittle = addTestimonialDto.Tittle
			});
			return Ok("Başarılı");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteTestimonial(int id)
		{
			var value = _testimonialService.TGetById(id);
			_testimonialService.TDelete(value);
			return Ok("Silindi");
		}

		[HttpPut]
		public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
		{
			_testimonialService.TUpdate(new Testimonial
			{
				Comment = updateTestimonialDto.Comment,
				ImageUrl = updateTestimonialDto.ImageUrl,
				Name = updateTestimonialDto.Name,
				Status = updateTestimonialDto.Status,
				Tittle = updateTestimonialDto.Tittle,
				TestimonialID = updateTestimonialDto.TestimonialID
			});
			return Ok("Güncellendi");
		}

		[HttpGet("{id}")]
		public IActionResult GetTestimonial(int id)
		{
			var value = _testimonialService.TGetById(id);
			return Ok(value);	
		}


	}
}
