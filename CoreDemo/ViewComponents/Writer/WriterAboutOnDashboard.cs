using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterAboutOnDashboard : ViewComponent
    {
        WriterManager writerManager = new WriterManager(new EfWriterRepository());
        Context c = new Context();
        public IViewComponentResult Invoke() 
        {
            var userMail = User.Identity.Name;
            var writerId = c.Writers.Where(x=>x.WriterMail == userMail).Select(y=>y.WriterId).FirstOrDefault();
            var value = writerManager.GetById(writerId);
            return View(value);
        }
    }
}
