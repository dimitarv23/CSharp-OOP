using P08.CollectionHierarchy.Collections;
using System;
using System.Collections.Generic;

namespace P08.CollectionHierarchy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var addColl = new AddCollection();
            var addRemoveColl = new AddRemoveCollection();
            var myList = new MyList();

            string[] input = Console.ReadLine().Split();

            var firstCollAdded = new List<int>();
            var secondCollAdded = new List<int>();
            var thirdCollAdded = new List<int>();

            foreach (var item in input)
            {
                firstCollAdded.Add(addColl.Add(item));
                secondCollAdded.Add(addRemoveColl.Add(item));
                thirdCollAdded.Add(myList.Add(item));
            }

            int numberOfRemoves = int.Parse(Console.ReadLine());

            var firstCollRemoved = new List<string>();
            var secondCollRemoved = new List<string>();

            for (int i = 0; i < numberOfRemoves; i++)
            {
                firstCollRemoved.Add(addRemoveColl.Remove());
                secondCollRemoved.Add(myList.Remove());
            }

            Console.WriteLine(string.Join(" ", firstCollAdded));
            Console.WriteLine(string.Join(" ", secondCollAdded));
            Console.WriteLine(string.Join(" ", thirdCollAdded));
            Console.WriteLine(string.Join(" ", firstCollRemoved));
            Console.WriteLine(string.Join(" ", secondCollRemoved));
        }
    }
}
