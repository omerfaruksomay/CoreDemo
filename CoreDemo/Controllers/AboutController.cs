using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace CoreDemo.Controllers
{
	public class AboutController : Controller
	{
		AboutManager am = new AboutManager(new EfAboutRepository());
		public IActionResult Index()
		{
			var values = am.Getlist();
			return View(values);
		}
		public PartialViewResult SocialMediaAbout() 
		{
			
			return PartialView();
		}
	}
}
