using P08.CollectionHierarchy.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P08.CollectionHierarchy.Collections
{
    public class AddRemoveCollection : IAddRemove, IEnumerable<string>
    {
        public AddRemoveCollection()
        {
            this.Items = new List<string>();
        }
        public AddRemoveCollection(IEnumerable<string> collection)
        {
            this.Items = collection.ToList();
        }

        public List<string> Items { get; set; }

        public int Add(string element)
        {
            this.Items.Insert(0, element);

            return 0;
        }


        public string Remove()
        {
            if (this.Items.Count == 0)
            {
                throw new InvalidOperationException("Cannot remove item from an empty collection.");
            }

            var removedItem = Items.Last();
            this.Items.RemoveAt(Items.Count - 1);

            return removedItem;
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
