using System;
using System.Linq;
using System.Text.Json;

namespace blog_task_medium
{
    public class Registration
    {
        public string Name;
        public string Surname;
        public string Email;
        public string Password;

        public void RunRegistration()
        {
            string name;
            do
            {
                Console.WriteLine("Please enter your name:");
                name = Console.ReadLine();
            } while (!Validation.CheckNameSurnameValidation(name, 3, 30));

            string surname;
            do
            {
                Console.WriteLine("Please enter your surname:");
                surname = Console.ReadLine();
            } while (!Validation.CheckNameSurnameValidation(surname, 4, 29));

            string email;
            do
            {
                Console.WriteLine("Please enter your email:");
                email = Console.ReadLine();
            } while (!Validation.CheckEmailValidation(email));

            string password;
            string repeatPassword;
            do
            {
                Console.WriteLine("\n Enter your password: ");
                password = PasswordInput();
                Console.WriteLine("\n Repeat your password: ");
                repeatPassword = PasswordInput();
            } while (!Validation.CheckPassword(password, repeatPassword));

            User newUser = new User(name, surname, email, password);
            newUser.AddUserToJson(newUser);
            Console.WriteLine("\n You successfully registered, now you can login with your new account!");
        }

        private string PasswordInput()
        {
            var pass = string.Empty;
            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;
                if (key == ConsoleKey.Backspace && pass.Length > 0)
                {
                    Console.Write("\b \b");
                    pass = pass[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    pass += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);

            return pass;
        }
    }


    public class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User(string name, string surname, string email, string password)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
        }

        public void AddUserToJson(User newUserData)
        {
            string textFile = System.IO.File.ReadAllText("../../../files/user.json");
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };
            User[] userList = JsonSerializer.Deserialize<User[]>(textFile, options);
            userList = userList.Append(newUserData).ToArray();
            string forWriteToFile = JsonSerializer.Serialize(userList);
            System.IO.File.Delete("../../../files/user.json");
            System.IO.File.AppendAllText("../../../files/user.json", forWriteToFile);
        }
    }
}