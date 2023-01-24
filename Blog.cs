using System;
using System.Linq;
using System.Text.Json;

namespace blog_task_medium
{
    public class Blog
    {
        public string PublishDate { get; set; }
        public string BlogCode { get; set; }
        public string BlogTitle { get; set; }
        public string Content { get; set; }
        public string UserId { get; set; }

        public Blog( string userId, string blogTitle, string content)
        {
            PublishDate = DateTime.Now.ToString();
            BlogCode = new BlogActions().GenerateBlockCode();
            BlogTitle = blogTitle;
            Content = content;
            UserId = userId;
        }
    }

    public class BlogActions
    {
        public void RunAddBlog()
        {
            string title;
            string content;
            Console.Write("Please write blog title: ");
            title = Console.ReadLine();
            Console.Write("Please write blog content: ");
            content = Console.ReadLine();
            AddBlog("638101753836599668", title, content);
        }

        public string GenerateBlockCode()
        {
            return $"BL{10000}";
        }

        public void AddBlog(string userId, string title, string content)
        {
            Blog newBlog = new Blog(userId, title, content);
            
            Blog[] blogList = GetBlogList();
            blogList = blogList.Append(newBlog).ToArray();
            
            string forWriteToFile = JsonSerializer.Serialize(blogList);
            System.IO.File.Delete("../../../files/blogs.json");
            System.IO.File.AppendAllText("../../../files/blogs.json", forWriteToFile);
            Console.WriteLine("New blog was added.");
        }

        public Blog[] GetBlogList()
        {
            string textFile = System.IO.File.ReadAllText("../../../files/blogs.json");
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };
            Blog[] blogList = JsonSerializer.Deserialize<Blog[]>(textFile, options);
            return blogList;
        }
    }
}