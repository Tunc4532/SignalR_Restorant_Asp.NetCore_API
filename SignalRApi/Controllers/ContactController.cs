using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CatagoryDto;
using SignalR.DtoLayer.ContactDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactController : ControllerBase
	{
		private readonly IContactService _contactService;
		private readonly IMapper _mapper;
		public ContactController(IContactService contactService, IMapper mapper)
		{
			_contactService = contactService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult ContactList()
		{
			var value = _mapper.Map<List<ResultContactDto>>(_contactService.TGetListAll());
			return Ok(value);
		}

		[HttpPost]
		public IActionResult CreateContact(AddContactDto addContactDto)
		{
			_contactService.TAdd(new Contact
			{
				FooterDescription = addContactDto.FooterDescription,
				Location = addContactDto.Location,
				Mail = addContactDto.Mail,
				Phone = addContactDto.Phone,
				FooterTittle = addContactDto.FooterTittle,
				OpenDays = addContactDto.OpenDays,
				OpenDaysDescription = addContactDto.OpenDaysDescription,
				OpenHours = addContactDto.OpenHours
			});
			return Ok("Başarılı");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteContact(int id)
		{
			var values = _contactService.TGetById(id);
			_contactService.TDelete(values);
			return Ok("Silindi");
		}

		[HttpPut]
		public IActionResult UpdateContact(UpdateContactDto updateContactDto)
		{
			_contactService.TUpdate(new Contact
			{
				ContactID = updateContactDto.ContactID,
				FooterDescription =updateContactDto.FooterDescription,
				Location = updateContactDto.Location,
				Mail =updateContactDto.Mail,
				Phone =updateContactDto.Phone,
				OpenHours=updateContactDto.OpenHours,
				OpenDaysDescription=updateContactDto.OpenDaysDescription,
				OpenDays = updateContactDto.OpenDays,
				FooterTittle =updateContactDto.FooterTittle
			});
			return Ok("Güncellendi");
		}


		[HttpGet("{id}")]
		public IActionResult GetContact(int id)
		{
			var value = _contactService.TGetById(id);
			return Ok(value);
		}

	}
}
