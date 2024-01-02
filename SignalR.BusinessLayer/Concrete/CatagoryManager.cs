using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class CatagoryManager : ICatagoryService
    {
        private readonly ICatagoryDal _catagoryDal;

        public CatagoryManager(ICatagoryDal catagoryDal)
        {
            _catagoryDal = catagoryDal;
        }

        public int TActiveCatagoryCount()
        {
            return _catagoryDal.ActiveCatagoryCount();
        }

        public void TAdd(Catagory entity)
        {
            _catagoryDal.Add(entity);
        }

        public void TDelete(Catagory entity)
        {
            _catagoryDal.Delete(entity);
        }

        public Catagory TGetById(int id)
        {
            return _catagoryDal.GetById(id);
        }

        public List<Catagory> TGetListAll()
        {
            return _catagoryDal.GetListAll();
        }

        public int TPasiveCatagoryCount()
        {
            return _catagoryDal.PasiveCatagoryCount();
        }

        public int TSendCatagoryCount()
        {
            return _catagoryDal.SendCatagoryCount();
        }

        public void TUpdate(Catagory entity)
        {
            _catagoryDal.Update(entity);
        }
    }
}
