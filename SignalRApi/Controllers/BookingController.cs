using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookingController : ControllerBase
	{
		private readonly IBookingService _bookingService;
		public BookingController(IBookingService bookingService)
		{
			_bookingService = bookingService;
		}

		[HttpGet("BokkinngStatusApprroved")]
		public IActionResult BokkinngStatusApprroved(int id)
		{
			_bookingService.TBokkinngStatusApprroved(id);
			return Ok("Rezervasyon Açıklaması Değiştirildi");
		}

		[HttpGet("BokkinngStatusCancellled")]
		public IActionResult BokkinngStatusCancellled(int id)
		{
			_bookingService.TBokkinngStatusCancelled(id);
			return Ok("Rezervasyon Açıklaması Değiştirildi");
		}

        [HttpGet]
		public IActionResult BookingList()
		{
			var values = _bookingService.TGetListAll();
			return Ok(values);
		}
		[HttpPost]
		public IActionResult CreateBooking(CreateBookingDto createBookingDto)
		{
			Booking booking = new Booking()
			{
				Date = createBookingDto.Date,
				Mail = createBookingDto.Mail,
				Name = createBookingDto.Name,
				PersonCount = createBookingDto.PersonCount,
				Phone = createBookingDto.Phone,
				Description = createBookingDto.Description
			};
			_bookingService.TAdd(booking);
			return Ok("Başarılı");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteBooking(int id)
		{
			var value = _bookingService.TGetById(id);
			_bookingService.TDelete(value);
			return Ok("Silindi");
		}

		[HttpPut]
		public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
		{
			Booking booking = new Booking()
			{
				BookingID = updateBookingDto.BookingID,
				Mail = updateBookingDto.Mail,
				Name = updateBookingDto.Name,
				PersonCount = updateBookingDto.PersonCount,
				Phone = updateBookingDto.Phone,
				Date = updateBookingDto.Date,
				Description = updateBookingDto.Description
			};
			_bookingService.TUpdate(booking);
			return Ok("Güncelendi");
		}
		[HttpGet("{id}")]
		public IActionResult GetBooking(int id)
		{
			var value = _bookingService.TGetById(id);
			return Ok(value);
		}

	}
}
