using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CoreDemo.Controllers
{
	public class CommentController : Controller
	{

		CommentManager cm = new CommentManager(new EfCommentRepository());

		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public PartialViewResult PartialAddComment(int id)
		{
			
			return PartialView(id);
		}
		[HttpPost]
		public IActionResult PartialAddComment(Comment c,int id)
		{
			c.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
			c.CommentStatus = true;
			c.BlogID = id;
			cm.CommentAdd(c);
			return RedirectToAction("BlogReadAll","Blog",new { id = id });
	
		}

		public PartialViewResult CommentListByBlog(int id)
		{
			var values = cm.GetComments(id);
			return PartialView(values);
		}
	}
}
