using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class BlogService
    {
        private BloggingEntities _context;

        public BlogService(BloggingEntities context)
        {
            _context = context;
        }

        public Blog AddBlog(string url)
        {
            var blog = _context.Blog.Add(new Blog {Url = url });
            _context.SaveChanges();

            return blog;
        }

        public List<Blog> GetAllBlogs()
        {
            var query = from b in _context.Blog
                        orderby b.Url
                        select b;

            return query.ToList();
        }

        public async Task<List<Blog>> GetAllBlogsAsync()
        {
            var query = from b in _context.Blog
                        orderby b.Url
                        select b;

            return await query.ToListAsync();
        }
    }
}
