using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.EntityLayer.Entities
{
    public class Discount
    {
        public int DiscountID { get; set; }
        public string Tittle { get; set; }
        public string Description { get; set; }
        public string Amount { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
    }
}
