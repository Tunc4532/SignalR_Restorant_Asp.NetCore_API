using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.EntityLayer.Entities
{
    public class Catagory
    {
        public int CatagoryID { get; set; }
        public string CatagoryName { get; set; }
        public bool Status { get; set; }

        public List<Product> Products { get; set; }
    }
}
