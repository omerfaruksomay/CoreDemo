using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBLogService
    {
        IBlogDal _blogDal;
        public BlogManager(IBlogDal IblogDal)
        {
            _blogDal = IblogDal;
        }

        public void Add(Blog t)
        {
            _blogDal.Insert(t);
        }

        public void Delete(Blog t)
        {
           _blogDal.Delete(t);
        }


        public List<Blog> GetAll()
        {
            return _blogDal.GetAll();
        }

        public List<Blog> GetBloglistByWriter(int id)
        {
           return _blogDal.GetAll(x=>x.WriterId == id);
        }

        public List<Blog> GetBlogListWithCategory()
        {
           return _blogDal.GetListWithCategory();
        }

        public List<Blog> GetBlogListWithCategoryByWriter(int id) 
        {
            return _blogDal.GetListWithCategoryByWriter(id);
        }

        public Blog GetById(int id)
        {
            return _blogDal.GetById(id);
        }

        public void Update(Blog t)
        {
            _blogDal.Update(t);
        }

        public List<Blog> GetLast3Blog()
        {
            return _blogDal.GetAll().Take(3).ToList();
        }


    }
}
