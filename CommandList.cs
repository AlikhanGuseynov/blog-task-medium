using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog_task_medium
{
    internal class CommandList
    {
        private Command[] _commandList =
        {
            new Command(1, "/register"),
            new Command(2, "/login"),
            new Command(3, "/show-blogs-with-comments"),
            new Command(4, "/show-filtered-blogs-with-comments"),
            new Command(5, "/find-blog-by-code"),
        };

        public Command[] GetAllCommands()
        {
            return _commandList;
        }

        public Command GetCommandById(int id)
        {
           return Array.Find(_commandList, el => el.Id == id);
        }
        
        public void ShowAllCommand()
        {
            foreach (var command in _commandList)
            {
                Console.WriteLine($"{command.Id} {command.Content}");
            }
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