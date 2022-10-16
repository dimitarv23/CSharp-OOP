using P08.CollectionHierarchy.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P08.CollectionHierarchy.Collections
{
    public class MyList : IMyList, IEnumerable<string>
    {
        public MyList()
        {
            this.Items = new List<string>();
        }
        public MyList(IEnumerable<string> collection)
        {
            this.Items = collection.ToList();
        }

        public List<string> Items { get; set; }
        public int Used => this.Items.Count;

        public int Add(string element)
        {
            this.Items.Insert(0, element);

            return 0;
        }


        public string Remove()
        {
            if (Used == 0)
            {
                throw new InvalidOperationException("Cannot remove item from an empty collection.");
            }

            var removedElement = this.Items.First();
            this.Items.RemoveAt(0);

            return removedElement;
        }

        public string this[int index]
        {
            get => this.Items[index];
        }

        public IEnumerator<string> GetEnumerator()
        {
            return this.Items.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
