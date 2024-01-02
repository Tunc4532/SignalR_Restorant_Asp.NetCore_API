namespace SignalRWebUI.Dtos.MessageDto
{
    public class GetMessageDto
    {
        public int MessageID { get; set; }
        public string NameSurname { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Subject { get; set; }
        public string MessageContend { get; set; }
        public DateTime MessageSendDate { get; set; }
        public bool Status { get; set; }
    }
}
