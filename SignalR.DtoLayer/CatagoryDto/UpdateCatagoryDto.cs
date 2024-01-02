using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.CatagoryDto
{
    public class UpdateCatagoryDto
    {
        public int CatagoryID { get; set; }
        public string CatagoryName { get; set; }
        public bool Status { get; set; }
    }
}
