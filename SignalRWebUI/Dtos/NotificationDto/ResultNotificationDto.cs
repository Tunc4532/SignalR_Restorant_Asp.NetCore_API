namespace SignalRWebUI.Dtos.NotificationDto
{
    public class ResultNotificationDto
    {
        public int NotificationID { get; set; }
        public string Icon { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime NotificationDate { get; set; }
        public bool Status { get; set; }
    }
}
