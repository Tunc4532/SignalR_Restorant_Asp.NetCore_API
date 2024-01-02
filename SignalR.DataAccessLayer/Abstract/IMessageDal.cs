using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IMessageDal : IGenericDal<Message>
    {
        void MessagesButtonChangeTrue(int id);
        void MessagesButtonChangeFalse(int id);
        
        List<Message> GetMessagesByStatusTrue();
        List<Message> GetMessagesByStatusFalse();
    }
}
