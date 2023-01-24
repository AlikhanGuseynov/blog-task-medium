using blog_task_medium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text.Json;
using Microsoft.VisualBasic;

namespace blog_task_medium
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var login = new Login();
            login.RunLogin();
            // var commandList = new CommandList();
            // commandList.ShowAllPublicCommand();
            // Console.WriteLine("\n Select command number:");
            // Command selectedCommand = commandList.GetPublicCommandById(Convert.ToInt32(Console.ReadLine()));
            // Console.WriteLine($"You select: {selectedCommand.Content}");
            // switch (selectedCommand.Id)
            // {
            //     case 1:
            //         var registration = new Registration();
            //         registration.RunRegistration();
            //         break;
            //     case 2:
            //         var login = new Login();
            //         login.RunLogin();
            //         break;
            // }
        }
    }

}