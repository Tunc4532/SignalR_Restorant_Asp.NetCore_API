﻿using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Abstract
{
	public interface IProductService : IGenericService<Product>
	{
        List<Product> TGetProductWithProducts();
        public int TSendProductCount();
        int TProductCountByCatagoryNameHamburger();
        int TProductCountByCatagoryNameDrink();

        decimal TProductPriceAvg();

        string TProductNameByMaxPrice();
        string TProductNameByMinPrice();
        decimal TProductAvgPriceByHamburger();
        decimal TProductBySteakBurgerPrice();
        decimal TTotalPriceByDrinkCatagoryId();
    }
}
