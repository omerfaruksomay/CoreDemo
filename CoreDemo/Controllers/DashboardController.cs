using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.Controllers
{
    public class DashboardController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {   
            Context c = new Context();
            ViewBag.stat1 = c.Blogs.Count().ToString();
            ViewBag.stat2 = c.Blogs.Count(x=>x.WriterId == 2).ToString();
            ViewBag.stat3 = c.Categories.Count().ToString();
            return View();
        }
    }
}
