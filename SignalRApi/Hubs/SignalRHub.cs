using Microsoft.AspNetCore.SignalR;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;

namespace SignalRApi.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ICatagoryService _catagoryService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IMoneyCaseService _moneyCaseService;
        private readonly IMenuTableService _menuTableService;
        private readonly IBookingService _bookingService;
        private readonly INotificationService _notificationService;

        public SignalRHub(ICatagoryService catagoryService, IProductService productService, IOrderService orderService, IMoneyCaseService moneyCaseService, IMenuTableService menuTableService, IBookingService bookingService, INotificationService notificationService)
        {
            _catagoryService = catagoryService;
            _productService = productService;
            _orderService = orderService;
            _moneyCaseService = moneyCaseService;
            _menuTableService = menuTableService;
            _bookingService = bookingService;
            _notificationService = notificationService;
        }

        public static int clientcount { get; set; } = 0;

        public async Task SendStatistics()
        {
            var value = _catagoryService.TSendCatagoryCount();
            await Clients.All.SendAsync("ReceiveCatagoryCount", value);

            var value2 = _productService.TSendProductCount();
            await Clients.All.SendAsync("ReceiveProductCount", value2);

            var value3 = _catagoryService.TActiveCatagoryCount();
            await Clients.All.SendAsync("ReceiveActiveCatagoryCount", value3);

            var value4 = _catagoryService.TPasiveCatagoryCount();
            await Clients.All.SendAsync("ReceivePasveCatagoryCount", value4);

            var value5 = _productService.TProductCountByCatagoryNameHamburger();
            await Clients.All.SendAsync("ReceiveProductCountByCatagoryNameHamburger", value5);

            var value6 = _productService.TProductCountByCatagoryNameDrink();
            await Clients.All.SendAsync("ReceiveProductCountByCatagoryNameDrink", value6);

            var value7 = _productService.TProductPriceAvg();
            await Clients.All.SendAsync("ReceiveProductPriceAvg", value7.ToString("0.00")+"₺");

            var value8 = _productService.TProductNameByMaxPrice();
            await Clients.All.SendAsync("ReceiveProductNameByMaxPrice", value8);

            var value9 = _productService.TProductNameByMinPrice();
            await Clients.All.SendAsync("ReceiveProductNameByMinPrice", value9);

            var value10 = _productService.TProductAvgPriceByHamburger();
            await Clients.All.SendAsync("ReceiveProductAvgPriceByHamburger", value10.ToString("0.00") + "₺");

            var value11 = _orderService.TTotalOrderCount();
            await Clients.All.SendAsync("ReceiveTTotalOrderCount", value11);

            var value12 = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiveTActiveOrderCount", value12);

            var value13 = _orderService.TLastOrderPrice();
            await Clients.All.SendAsync("ReceiveTLastOrderPrice", value13.ToString("0.00") + "₺");

            var value14 = _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("ReceiveTTotalMoneyCaseAmount", value14.ToString("0.00") + "₺");

            var value16 = _menuTableService.TMenuTableCount();
            await Clients.All.SendAsync("ReceiveTMenuTableCount", value16);

        }

        public async Task SendProgress()
        {

            var value = _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", value.ToString("0,00" + "₺"));

            var value1 = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiveActiveOrderCount", value1);

            var value2 = _menuTableService.TMenuTableCount();
            await Clients.All.SendAsync("ReceiveMenuTableCount", value2);

            var value4 = _productService.TProductPriceAvg();
            await Clients.All.SendAsync("ReceiveProductPriceAvg", value4);

            var value5 = _catagoryService.TSendCatagoryCount();
            await Clients.All.SendAsync("ReceiveSendCatagoryCount",value5);

            var value6 = _productService.TProductAvgPriceByHamburger();
            await Clients.All.SendAsync("ReceiveProductAvgPriceByHamburger", value6);

            var value7 = _productService.TProductCountByCatagoryNameDrink();
            await Clients.All.SendAsync("ReceiveSendProductCountbyDrink", value7);

            var value8 = _orderService.TTotalOrderCount();
            await Clients.All.SendAsync("ReceiveTotalOrderCount", value8);

            var value9 = _orderService.TLastOrderPrice();
            await Clients.All.SendAsync("ReceiveLastOrderPrice", value9);

            var value10 = _productService.TProductBySteakBurgerPrice();
            await Clients.All.SendAsync("ReceiveProductBySteakBurgerPrice", value10);

            var value11 = _productService.TTotalPriceByDrinkCatagoryId();
            await Clients.All.SendAsync("ReceiveTProductCountByCatagoryNameDrink", value11);

        }

        public async Task GetBookingList()
        {
            var value = _bookingService.TGetListAll();
            await Clients.All.SendAsync("ReceiveBookingList", value);

        }

        public async Task SendNotification()
        {
            var value = _notificationService.TNotificationCountByStatusFalse();
            await Clients.All.SendAsync("ReceiveNotificationCountByStatusFalse", value);

            var values = _notificationService.TGetAllNotificationByFalse();
            await Clients.All.SendAsync("ReceiveNotificationGetByListFalse", values);
        }

        public async Task GetMenuTableStatus()
        {
            var value = _menuTableService.TGetListAll();
            await Clients.All.SendAsync("ReceiveMenuTableStatus", value);
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage",user,message);
        }

        public override async Task OnConnectedAsync()
        {
            clientcount++;
            await Clients.All.SendAsync("ReceiveClientCount", clientcount);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            clientcount--;
            Clients.All.SendAsync("ReceiveClientCount", clientcount);
            await base.OnDisconnectedAsync(exception);

        }

    }
}
