using System;
using System.Text.Json;

namespace blog_task_medium
{
    public class Login
    {
        public void RunLogin()
        {
            string email;
            string password;
            do
            {
                Console.Write("Please enter your email: ");
                email = Console.ReadLine();
                Console.Write("Please enter your password: ");
                password = Console.ReadLine();
            } while (!UserLogin(email, password));

            do
            {
                var commandList = new CommandList();
                commandList.ShowAllPrivateCommand();

                Console.Write("Select command number: ");
                Command selectedCommand = commandList.GetPrivateCommandById(Convert.ToInt32(Console.ReadLine()));

                switch (selectedCommand.Id)
                {
                    case 4:
                        new BlogActions().RunAddBlog();
                        break;
                }
            } while (true);
        }

        public bool UserLogin(string email, string password)
        {
            string textFile = System.IO.File.ReadAllText("../../../files/user.json");
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };
            User[] userList = JsonSerializer.Deserialize<User[]>(textFile, options);
            User some = Array.Find(userList, user => user.Email == email && user.Password == password);
            if (some == null)
            {
                Console.WriteLine("Error: email or password is invalid.");
                return false;
            }
            Console.WriteLine("---> Success login.");
            return true;
        }
    }
}