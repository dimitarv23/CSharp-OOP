using P08.CollectionHierarchy.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P08.CollectionHierarchy.Collections
{
    public class AddCollection : IAdd, IEnumerable<string>
    {
        public AddCollection()
        {
            this.Items = new List<string>();
        }
        public AddCollection(IEnumerable<string> collection)
        {
            this.Items = collection.ToList();
        }

        public List<string> Items { get; set; }

        public int Add(string element)
        {
            this.Items.Add(element);

            return this.Items.Count - 1;
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
