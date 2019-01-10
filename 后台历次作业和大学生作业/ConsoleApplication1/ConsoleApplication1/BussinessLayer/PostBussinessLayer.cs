using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Models;
using ConsoleApplication1.DataAccessLayer;
using System.Data.Entity;

namespace ConsoleApplication1.BussinessLayer
{
    public class PostBussinessLayer
    {
        public void Add(Post post)
        {
            using (var db = new BloggingContext())
            {
                db.Posts.Add(post);

                db.SaveChanges();
            }
        }
        public void Update(Post post)
        {
            using (var db = new BloggingContext())
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        public void Delete(Post post)
        {
            using (var db = new BloggingContext())
            {
                db.Entry(post).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
        public Post Query(int id)
        {
            using (var db = new BloggingContext())
            {
                return db.Posts.Find(id);
            }
        }
        public List<Post> Querformtitle(string title)
        {
            using(var db = new BloggingContext())
            {
                var query = from z in db.Posts
                            where z.Title.Contains(title)
                            select z;
                return query.ToList();
            }
        }
        //public List<Post> Querformtitle1(string title)
        //{
        //    using (var db = new BloggingContext())
        //    {
        //        var query = db.Posts.Where(b => b.Title.Contains(title));
        //        foreach (var item in query)
        //        {
        //            Console.WriteLine(item);
        //        }
        //    }
        //}

    }
}
