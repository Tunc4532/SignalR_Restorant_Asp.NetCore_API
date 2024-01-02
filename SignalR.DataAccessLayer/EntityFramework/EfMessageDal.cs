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
    public class EfMessageDal : GenericRepostory<Message>, IMessageDal
    {
        public EfMessageDal(SignalRContext context) : base(context)
        {
        }

        public List<Message> GetMessagesByStatusFalse()
        {
            using var context = new SignalRContext();
            var value = context.Messages.Where(x => x.Status==false).ToList();
            return value;
        }

        public List<Message> GetMessagesByStatusTrue()
        {
            using var context = new SignalRContext();
            var value = context.Messages.Where(x => x.Status == true).ToList();
            return value;
        }

        public void MessagesButtonChangeFalse(int id)
        {
            using var context = new SignalRContext();
            var value = context.Messages.Find(id);
            value.Status= false;
            context.SaveChanges();
        }

        public void MessagesButtonChangeTrue(int id)
        {
            using var context = new SignalRContext();
            var value = context.Messages.Find(id);
            value.Status = true;
            context.SaveChanges();
        }
    }
}
