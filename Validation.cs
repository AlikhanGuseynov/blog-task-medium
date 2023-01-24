using System;
using System.Text.RegularExpressions;

namespace blog_task_medium
{
    public class Validation
    {
        public static bool CheckNameSurnameValidation(string text, int minLength, int maxLength)
        {
            if (text.Length < minLength || text.Length > maxLength)
            {
                Console.WriteLine($"Error: entered text must be > {minLength} and < {maxLength}");
                return false;
            }
            
            if (!Regex.IsMatch(text, @"^[a-zA-Z]+$"))
            {
                Console.WriteLine("Error: entered text must be only letter");
                return false;
            }
            
            if (!Regex.IsMatch(text, @"[A-Z]+[a-z]*"))
            {
                Console.WriteLine("Error: first and only first letter must be uppercase");
                return false;
            }
            return true;
        }
        
        public static bool CheckEmailValidation(string email)
        {
            if (false)
            {
                Console.WriteLine("Error: email must be, for example - alixan@code.edu.az");
                return false;
            }
            return true;
        }

        public static bool CheckPassword(string password, string repeatPassword)
        {
            if (password != repeatPassword)
            {
                Console.WriteLine("\n Error: Both password must be equal.");
                return false;
            }
            return true;
        }
        
        
        
    }
}