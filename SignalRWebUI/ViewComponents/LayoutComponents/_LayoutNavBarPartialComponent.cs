using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.LayoutComponents
{
	public class _LayoutNavBarPartialComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}


	}
}
