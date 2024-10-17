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
		public PartialViewResult PartialAddComment()
		{
			return PartialView();
		}
		[HttpPost]
		public PartialViewResult PartialAddComment(Comment c)
		{
			c.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
			c.CommentStatus = true;
			c.BlogID = 2;
			cm.CommentAdd(c);
			Response.Redirect("/Blog/Index/");
			return PartialView();
		}

		public PartialViewResult CommentListByBlog(int id)
		{
			var values = cm.GetComments(id);
			return PartialView(values);
		}
	}
}
