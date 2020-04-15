// Vang, Xoua
using System;
using System.Linq;
using System.Collections.Generic;

namespace HW2_ListsAndMoreLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Models.User> users = new List<Models.User>()
            {
                new Models.User { Name="Dave", Password="hello"},
                new Models.User { Name="Steve", Password="steve"},
                new Models.User { Name="Lisa", Password="hello"}
            };

            //1. Display to the console, all the passwords that are "hello"
            var helloQuery = users.Where(u => u.Password.Equals("hello"));
            Console.WriteLine("Users with 'hello' for their password:");
            helloQuery.ToList().ForEach(x => Console.WriteLine($"Username: {x.Name}, Password: {x.Password}"));

            //2. Delete any password that are the lower-cased version of their Name.
            users.RemoveAll(u => u.Name.ToLower() == u.Password);

            //3. Delete the first User that has the password "hello".
            if (helloQuery.Count() > 0)
            {
                users.Remove(helloQuery.FirstOrDefault()); 
            }

            //4. Display to the console the remaining users with their Name and Password.
            Console.WriteLine("\nRemaining Users:");
            users.ForEach(x => Console.WriteLine($"Username: {x.Name}, Password: {x.Password}"));
        }
    }
}
