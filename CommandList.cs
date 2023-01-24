using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace blog_task_medium
{
    internal class CommandList
    {
        private Command[] _publicCommandList =
        {
            new Command(1, "/register"),
            new Command(2, "/login"),
            new Command(3, "/show-blogs-with-comments"),
            new Command(4, "/show-filtered-blogs-with-comments"),
            new Command(5, "/find-blog-by-code"),
        };
        private Command[] _privateCommandList =
        {
            new Command(1, "/inbox"),
            new Command(2, "/add-comment"),
            new Command(3, "/blogs"),
            new Command(4, "/add-blog"),
            new Command(5, "/delete-blog"),
        };
        public Command GetPublicCommandById(int id)
        {
           return Array.Find(_publicCommandList, el => el.Id == id);
        }
        
        public void ShowAllPublicCommand()
        {
            foreach (var command in _publicCommandList)
            {
                Console.WriteLine($"{command.Id} {command.Content}");
            }
        }     
        public Command GetPrivateCommandById(int id)
        {
           return Array.Find(_privateCommandList, el => el.Id == id);
        }
        
        public void ShowAllPrivateCommand()
        {
            Console.WriteLine(new String('-', 150));
            foreach (var command in _privateCommandList)
            {
                Console.WriteLine($"{command.Id} {command.Content}");
            }
            Console.WriteLine(new String('-', 150));
        }
    }

    public class Command
    {
        public int Id;
        public string Content;

        public Command(int id, string content)
        {
            Id = id;
            Content = content;
        }
    }
    
}