namespace SignalRWebUI.Dtos.DiscountDto
{
    public class UpdateDiscountDto
    {
        public int DiscountID { get; set; }
        public string Tittle { get; set; }
        public string Description { get; set; }
        public string Amount { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
    }
}
