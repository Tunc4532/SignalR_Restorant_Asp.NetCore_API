using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IProductDal : IGenericDal<Product>
    {
        List<Product> GetProductWithProducts();
        int SendProductCount();
        int ProductCountByCatagoryNameHamburger();
        int ProductCountByCatagoryNameDrink();

        decimal ProductPriceAvg();

        string ProductNameByMaxPrice();
        string ProductNameByMinPrice();

        decimal ProductAvgPriceByHamburger();
        decimal ProductBySteakBurgerPrice();

        decimal TotalPriceByDrinkCatagoryId();
    }
}
