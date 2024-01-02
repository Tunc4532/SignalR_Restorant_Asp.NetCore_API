using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.DtoLayer.MessageDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public IActionResult MessageList()
        {
            var values = _messageService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto)
        {
            
            Message message = new Message()
            {
                Mail = createMessageDto.Mail,
                MessageContend = createMessageDto.MessageContend,
                MessageSendDate = DateTime.Now,
                NameSurname = createMessageDto.NameSurname,
                Phone = createMessageDto.Phone,
                Subject = createMessageDto.Subject,
                Status = true
            };
            _messageService.TAdd(message);
            return Ok("Başarılı");
        }

        [HttpPut]
        public IActionResult UpdateAbout(UpdateMessageDto updateMessageDto)
        {
            Message message = new Message()
            {
              Mail = updateMessageDto.Mail,
              Subject = updateMessageDto.Subject,
              Phone = updateMessageDto.Phone,
              NameSurname= updateMessageDto.NameSurname,
              MessageSendDate= updateMessageDto.MessageSendDate,
              MessageContend = updateMessageDto.MessageContend,
              Status = updateMessageDto.Status
            };
            _messageService.TUpdate(message);
            return Ok("Güncellendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(int id)
        {
            var value = _messageService.TGetById(id);
            _messageService.TDelete(value);
            return Ok("Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetMessage(int id)
        {
            var value = _messageService.TGetById(id);
            return Ok(value);
        }

        [HttpGet("GetMessagesByStatusFalse")]
        public IActionResult GetMessagesByStatusFalse()
        {
            return Ok(_messageService.TGetMessagesByStatusFalse());
        }

        [HttpGet("GetMessagesByStatusTrue")]
        public IActionResult GetMessagesByStatusTrue()
        {
            return Ok(_messageService.TGetMessagesByStatusTrue());
        }

        [HttpGet("MessagesButtonChangeTrue")]
        public IActionResult MessagesButtonChangeTrue(int id)
        {
            _messageService.TMessagesButtonChangeTrue(id);
            return Ok("Mesaj Aktifleştirildi");
        }

        [HttpGet("MessagesButtonChangeFaslse")]
        public IActionResult MessagesButtonChangeFaslse(int id)
        {
            _messageService.TMessagesButtonChangeFalse(id);
            return Ok("Mesaj Pasifleştirildi");
        }
    }
}
