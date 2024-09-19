using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CoreAndFood.ViewComponents
{
	public class GetFoodList:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			FoodRepository foodRepository = new FoodRepository();
			var foodlist = foodRepository.TList();
			return View(foodlist);
		}
	}
}
