using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Models;
using ConsoleApplication1.BussinessLayer;
using ConsoleApplication1.DataAccessLayer;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //createBlog();
            QueryAllBlog();
            //Delete();
            //Update();
            //AddPost();
            //gong();
            //Console.WriteLine("按任意键退出");
            //Console.ReadKey();
            //QueryPostForTitle();
            while (true)
            {
                Console.Clear();
                gong();

            }
            //增加----交互
        }
        static void QueryPostForTitle()
        {
            Console.WriteLine("请输需要查询的帖子");
            string name = Console.ReadLine();
            PostBussinessLayer ppl = new BussinessLayer.PostBussinessLayer();
            var query = ppl.Querformtitle(name);
            foreach(var itme in query)
            {
                Console.WriteLine(itme.Title + "  " + itme.Content);
            }
            Console.ReadKey();
        }
        static void gong()
        {
           
             QueryAllBlog();

            Console.WriteLine("1--新增博客  2--删除博客   3--更新博客  4--查找博客帖子 5--根据内容查找帖子");
            int num = int.Parse(Console.ReadLine());

            switch (num)
            {
                case 1:
                    createBlog();
                    Console.Clear();
                    
                    break;
                case 2:
                    Delete();
                    Console.Clear();
                    
                    break;
                case 3:
                    Update();
                    Console.Clear();
                    
                    break;
                case 4:
                    shou();
                    break;
                case 5:
                    

                    break;
                 }
                
            }

        
        static void shou()
        {
           
            int blogid = getBlogid();
            while (true)
            {
                Console.Clear();
                DisplayPosts(blogid);
                Console.WriteLine("1--新增帖子 2--更改贴子 3--删除帖子 4--返回博客");
                int num2 = int.Parse(Console.ReadLine());
                switch (num2)
                {
                    case 1:

                        Post post = new Post();
                        //填写帖子属性
                        Console.WriteLine("请输入帖子标题");
                        post.Title = Console.ReadLine();
                        Console.WriteLine("请输入帖子内容");
                        post.Content = Console.ReadLine();
                        post.BlogId = blogid;
                        //帖子通过数据上下文新增
                        using (var db = new BloggingContext())
                        {
                            db.Posts.Add(post);
                            db.SaveChanges();
                        }
                        //显示指定博客的帖子列表
                        DisplayPosts(blogid);
                        break;
                    case 2:

                        break;
                    case 3:
                        
                        postDelete();
                        DisplayPosts(blogid);

                        break;
                    case 4:
                        Console.Clear();
                        gong();
                        break;
                }
            }

        }
        static void AddPost()
        {
            
            //用户选择某个博客（id）
            int blogid = getBlogid();
            //显示指定博客的帖子列表
             DisplayPosts(blogid);
            //根据指定到博客信息创建新帖子
            //新建帖子
            Post post = new Post();
            //填写帖子属性
            Console.WriteLine("请输入帖子标题");
            post.Title = Console.ReadLine();
            Console.WriteLine("请输入帖子内容");
            post.Content = Console.ReadLine();
            post.BlogId = blogid;
            //帖子通过数据上下文新增
            using(var db = new BloggingContext())
            {
                db.Posts.Add(post);
                db.SaveChanges();
            }
            //显示指定博客的帖子列表
            DisplayPosts(blogid);
        }


        static int getBlogid()
        {

            Console.WriteLine("请输入博客id");
            int id = int.Parse(Console.ReadLine());
            return id;

        }

        static void DisplayPosts(int blogid)
        {
            
            
            List<Post> list = null;
            //根据博客id获取博客
            using(var db= new BloggingContext())
            {
                Blog blog = db.Blogs.Find(blogid);
                 list = blog.Posts;
            }
            //Console.WriteLine(blogs.Name);

            //显示帖子列表
            foreach (var item in list)
            {
                Console.WriteLine(item.PostId + "--" + item.Title+"--"+item.Content);
            }

        }
        static void PostByID(int blogID)
        {
            Console.WriteLine("请输入一个帖子的名称");
            
        }

        static void createBlog()
        {
            Console.WriteLine("请输入一个博客名称");
            string name = Console.ReadLine();
            Blog blog = new Blog();
            blog.Name = name;
            BlogBussinessLayer bbl = new BlogBussinessLayer();
            bbl.Add(blog);
        }

        //显示全部的博客
        static void QueryAllBlog()
        {
            BlogBussinessLayer bbl = new BlogBussinessLayer();
            var blogs = bbl.Query();
            foreach(var item in blogs)
            {
                
                Console.WriteLine(item.BlogId + " " + item.Name);
            }
        }

        static void Update()
        {
            Console.WriteLine("请输入id");
            int id = int.Parse(Console.ReadLine());
            BlogBussinessLayer bbl = new BlogBussinessLayer();
            Blog blog = bbl.Query(id);
            Console.WriteLine("请输入新名字");
            string name = Console.ReadLine();
            blog.Name = name;
            bbl.Update(blog);
        }
        static void Delete()
        {
            BlogBussinessLayer bbl = new BlogBussinessLayer();  
            Console.WriteLine("请输入id");
            int id = int.Parse(Console.ReadLine());
            Blog blog = bbl.Query(id);
            bbl.Delete(blog);   
        }
        static void postDelete()
        {
            PostBussinessLayer bbl = new PostBussinessLayer();
            Console.WriteLine("请输入id");
            int id = int.Parse(Console.ReadLine());
            Post plog = bbl.Query(id);
            bbl.Delete(plog);
        }
        static void postcreateBlog()
        {
            Console.WriteLine("请输入一个帖子名称");
            string name = Console.ReadLine();
            Post plog = new Post();
            plog.Title = name;
            PostBussinessLayer bbl = new PostBussinessLayer();
            bbl.Add(plog);
        }

    }

}
