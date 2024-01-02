using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IMessageService : IGenericService<Message>
    {
        List<Message> TGetMessagesByStatusTrue();
        List<Message> TGetMessagesByStatusFalse();

        void TMessagesButtonChangeTrue(int id);
        void TMessagesButtonChangeFalse(int id);
    }
}
