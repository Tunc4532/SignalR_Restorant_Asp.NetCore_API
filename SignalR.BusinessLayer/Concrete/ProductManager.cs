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
	public class ProductManager : IProductService
	{
		private readonly IProductDal _productDal;

		public ProductManager(IProductDal productDal)
		{
			_productDal = productDal;
		}

		public void TAdd(Product entity)
		{
			_productDal.Add(entity);
		}

		public void TDelete(Product entity)
		{
			 _productDal.Delete(entity);
		}

		public Product TGetById(int id)
		{
			return _productDal.GetById(id);
		}

		public List<Product> TGetListAll()
		{
			return _productDal.GetListAll();
		}

        public List<Product> TGetProductWithProducts()
        {
            return _productDal.GetProductWithProducts();
        }

        public int TProductCountByCatagoryNameDrink()
        {
            return _productDal.ProductCountByCatagoryNameDrink();
        }

        public int TProductCountByCatagoryNameHamburger()
        {
            return _productDal.ProductCountByCatagoryNameHamburger();
        }

        public string TProductNameByMaxPrice()
        {
            return _productDal.ProductNameByMaxPrice();
        }

        public string TProductNameByMinPrice()
        {
            return _productDal.ProductNameByMinPrice();
        }

        public decimal TProductPriceAvg()
        {
            return _productDal.ProductPriceAvg();
        }

        public decimal TProductAvgPriceByHamburger()
        {
            return _productDal.ProductAvgPriceByHamburger();
        }

        public int TSendProductCount()
        {
            return _productDal.SendProductCount();
        }

        public void TUpdate(Product entity)
		{
			_productDal.Update(entity);
		}

        public decimal TProductBySteakBurgerPrice()
        {
            return _productDal.ProductBySteakBurgerPrice();
        }

        public decimal TTotalPriceByDrinkCatagoryId()
        {
           return _productDal.TotalPriceByDrinkCatagoryId();
        }
    }
}
