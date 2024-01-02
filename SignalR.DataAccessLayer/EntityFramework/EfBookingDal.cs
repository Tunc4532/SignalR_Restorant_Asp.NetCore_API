using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfBookingDal : GenericRepostory<Booking>, IBookingDal
    {

        public EfBookingDal(SignalRContext context) : base(context)
        {

        }

        public void BokkinngStatusApprroved(int id)
        {
           using var context = new SignalRContext();
            var value = context.Bookings.Find(id);
            value.Description = "Rezervasyon Onaylandı";
            context.SaveChanges();
        }

        public void BokkinngStatusCancelled(int id)
        {
            using var contex = new SignalRContext();
            var value = contex.Bookings.Find(id);
            value.Description = "Rezervasyon İptal Edildi";
            contex.SaveChanges();
        }
    }
}

