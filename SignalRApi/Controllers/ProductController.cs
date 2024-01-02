using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.DiscountDto;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _productService;
		private readonly IMapper _mapper;

		public ProductController(IProductService productService, IMapper mapper)
		{
			_productService = productService;
			_mapper = mapper;
		}
		[HttpGet]
		public IActionResult ProductList()
		{
			var values = _mapper.Map<List<ResultProductDto>>(_productService.TGetListAll());
			return Ok(values);
		}
		[HttpGet("SendProductCount")]
		public IActionResult ProductCount()
		{
			return Ok(_productService.TSendProductCount());
		}
        [HttpGet("ProductAvgPriceByHamburger")]
        public IActionResult ProductAvgPriceByHamburger()
        {
            return Ok(_productService.TProductAvgPriceByHamburger());
        }
        [HttpGet("ProductNameMaxPrice")]
        public IActionResult ProductNameMaxPrice()
        {
            return Ok(_productService.TProductNameByMaxPrice());
        }
        [HttpGet("ProductNameMinPrice")]
        public IActionResult ProductNameMinPrice()
        {
            return Ok(_productService.TProductNameByMinPrice());
        }

        [HttpGet("ProductPriceAvg")]
        public IActionResult ProductPriceAvg()
        {
            return Ok(_productService.TProductPriceAvg());
        }

		[HttpGet("TotalPriceByDrinkCatagoryId")]
		public IActionResult TotalPriceByDrinkCatagoryId()
		{
			return Ok(_productService.TTotalPriceByDrinkCatagoryId());
		}

        [HttpGet("SendProductCountbyDrink")]
        public IActionResult SendProductCountbyDrink()
        {
            return Ok(_productService.TProductCountByCatagoryNameDrink());
        }
        [HttpGet("SendProductCountbyHamburger")]
        public IActionResult SendProductCountbyHamburger()
        {
            return Ok(_productService.TProductCountByCatagoryNameHamburger());
        }

		[HttpGet("ProductBySteakBurgerPrice")]
		public IActionResult ProductBySteakBurgerPrice()
		{
			return Ok(_productService.TProductBySteakBurgerPrice());
		}

        [HttpGet("ProductListWithCatagory")]
		public IActionResult ProductListWithCatagory()
		{
			var context = new SignalRContext();
			var values = context.Products.Include(x => x.Catagory).Select(y => new ResultProductWithCatagory
			{
				CatagoryName = y.Catagory.CatagoryName,
				Description = y.Description,
				ImageUrl = y.ImageUrl,
				Price = y.Price,
				ProductID = y.ProductID,
				ProductName = y.ProductName,
				ProductStatus = y.ProductStatus
			});
			return Ok(values.ToList());

		}

		[HttpPost]
		public IActionResult CreateProduct(AddProductDto addProductDto)
		{
			_productService.TAdd(new Product
			{
				Description = addProductDto.Description,
				ImageUrl = addProductDto.ImageUrl,
				Price = addProductDto.Price,
				ProductName = addProductDto.ProductName,
				ProductStatus = addProductDto.ProductStatus,
				CatagoryID = addProductDto.CatagoryID
			});
			return Ok("Başarılı");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteProduct(int id)
		{
			var values = _productService.TGetById(id);
			_productService.TDelete(values);
			return Ok("Silindi");
		}

		[HttpPut]
		public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
		{
			_productService.TUpdate(new Product
			{
				Description = updateProductDto.Description,
				ImageUrl = updateProductDto.ImageUrl,
				Price = updateProductDto.Price,
				ProductName = updateProductDto.ProductName,
				ProductStatus = updateProductDto.ProductStatus,
				ProductID = updateProductDto.ProductID,
				CatagoryID = updateProductDto.CatagoryID
			});
			return Ok("Güncellendi");
		}

		[HttpGet("{id}")]
		public IActionResult GetProduct(int id)
		{
			var value = _productService.TGetById(id);
			return Ok(value);
		}

	}
}
