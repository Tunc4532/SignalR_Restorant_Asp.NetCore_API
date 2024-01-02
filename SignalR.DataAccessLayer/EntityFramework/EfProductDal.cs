using Microsoft.EntityFrameworkCore;
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
    public class EfProductDal : GenericRepostory<Product>, IProductDal
    {
        public EfProductDal(SignalRContext context) : base(context)
        {
        }

        public List<Product> GetProductWithProducts()
        {
            var context = new SignalRContext();
            var values = context.Products.Include(x => x.Catagory).ToList();
            return values;
        }

        public int ProductCountByCatagoryNameDrink()
        {
            using var context = new SignalRContext();
            return context.Products.Where(x => x.CatagoryID == (context.Catagories.Where(y => y.CatagoryName == "İçecek").Select(z => z.CatagoryID).FirstOrDefault())).Count();
        }

        public int ProductCountByCatagoryNameHamburger()
        {
            using var context = new SignalRContext();
            return context.Products.Where(x => x.CatagoryID == (context.Catagories.Where(y => y.CatagoryName == "Hamburger").Select(z => z.CatagoryID).FirstOrDefault())).Count();
        }

        public string ProductNameByMaxPrice()
        {
            using var context = new SignalRContext();
            return context.Products.Where(x => x.Price == (context.Products.Max(y => y.Price))).Select(z => z.ProductName).FirstOrDefault(); 
        }

        public string ProductNameByMinPrice()
        {
            using var context = new SignalRContext();
            return context.Products.Where(x => x.Price == (context.Products.Min(y => y.Price))).Select(z => z.ProductName).FirstOrDefault();
        }

        public decimal ProductPriceAvg()
        {
            using var context = new SignalRContext();
            return context.Products.Average(x => x.Price);
        }

        public decimal ProductAvgPriceByHamburger()
        {
            using var context = new SignalRContext();
            return context.Products.Where(x => x.CatagoryID == (context.Catagories.Where(y => y.CatagoryName == "Hamburger").Select(z => z.CatagoryID).FirstOrDefault())).Average(t => t.Price);
        }

        public int SendProductCount()
        {
            using var context = new SignalRContext();
            return context.Products.Count();
        }

        public decimal ProductBySteakBurgerPrice()
        {
            using var  context = new SignalRContext();
            return context.Products.Where(x => x.ProductName == "Steak Burger").Select(y => y.Price).FirstOrDefault();
        }

        public decimal TotalPriceByDrinkCatagoryId()
        {
            using var contex = new SignalRContext();
            int ID = contex.Catagories.Where(t => t.CatagoryName == "İçecek").Select(y => y.CatagoryID).FirstOrDefault();
            return contex.Products.Where(x => x.CatagoryID == (ID)).Sum(e => e.Price);
        }
    }
}
