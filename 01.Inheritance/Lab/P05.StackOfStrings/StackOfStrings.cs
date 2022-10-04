using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            return Count == 0;
        }

        public void AddRange(Stack<string> range)
        {
            foreach (var item in range)
            {
                this.Push(item);
            }
        }
    }
}
