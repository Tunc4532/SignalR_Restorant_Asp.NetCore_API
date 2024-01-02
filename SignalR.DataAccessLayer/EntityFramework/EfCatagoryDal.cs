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
    public class EfCatagoryDal : GenericRepostory<Catagory>, ICatagoryDal
    {

        public EfCatagoryDal(SignalRContext context) : base(context)
        {
        }

        public int ActiveCatagoryCount()
        {
            using var context = new SignalRContext();
            return context.Catagories.Where(x => x.Status == true).Count();
        }

        public int PasiveCatagoryCount()
        {
            using var context = new SignalRContext();
            return context.Catagories.Where(x => x.Status == false).Count();
        }

        public int SendCatagoryCount()
        {
            using var context = new SignalRContext();
           return context.Catagories.Count();

        }
    }
}

