using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AuthorProblem
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            Type type = typeof(StartUp);

            foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic
                | BindingFlags.Static | BindingFlags.Instance))
            {
                var attrs = method.GetCustomAttributes(false);

                foreach (var attr in attrs)
                {
                    AuthorAttribute authorAttr = attr as AuthorAttribute;

                    if (authorAttr != null)
                    {
                        Console.WriteLine($"{method.Name} is written by {authorAttr.Name}");
                    }
                }
            }
        }
    }
}
