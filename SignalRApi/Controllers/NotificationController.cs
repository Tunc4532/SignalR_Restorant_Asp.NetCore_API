using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.NotificationDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;
        public NotificationController(INotificationService notificationService, IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult NotificationList()
        {
            return Ok(_notificationService.TGetListAll());
        }

        [HttpGet("NotificationCountByStatusFalse")]
        public IActionResult NotificationGet()
        {
            return Ok(_notificationService.TNotificationCountByStatusFalse());
        }

        [HttpGet("GetAllNotificationByFalse")]
        public IActionResult GetAllNotificationByFalse()
        {
            return Ok(_notificationService.TGetAllNotificationByFalse());

        }

        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
        {
            _notificationService.TAdd(new Notification
            {
                 Description = createNotificationDto.Description,
                 Icon = createNotificationDto.Icon,
                 Status = false,
                 Type = createNotificationDto.Type,
                 NotificationDate = Convert.ToDateTime(DateTime.Now.ToShortDateString())
            });
            return Ok("Başarılı");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNotification(int id)
        {
            var value = _notificationService.TGetById(id);
            _notificationService.TDelete(value);
            return Ok("Silindi");
        }

        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
        {
            _notificationService.TUpdate(new Notification
            {
                NotificationID = updateNotificationDto.NotificationID,
                Description = updateNotificationDto.Description,
                Icon = updateNotificationDto.Icon,
                Status = updateNotificationDto.Status,
                Type = updateNotificationDto.Type,
                NotificationDate = updateNotificationDto.NotificationDate
            });
            return Ok("Güncellendi");
        }

        [HttpGet("NotificationStatusChangeToTrue")]
        public IActionResult NotificationStatusChangeToTrue(int id)
        {
            _notificationService.TNotificationStatusChangeToTrue(id);
            return Ok("Güncelleme Yapıldı");
        }

        [HttpGet("TNotificationStatusChangeToFalse")]
        public IActionResult TNotificationStatusChangeToFalse(int id)
        {
            _notificationService.TNotificationStatusChangeToFalse(id);
            return Ok("Güncelleme  Yapıldı");
        }

        [HttpGet("{id}")]
        public IActionResult GetNotificationid(int id)
        {
            var value = _notificationService.TGetById(id);
            return Ok(value);
        }
    }
}
