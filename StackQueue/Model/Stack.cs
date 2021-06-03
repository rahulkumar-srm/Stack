using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackQueue.Model
{
    internal class Stack
    {
        internal int Size { get; private set; }
        internal int Top { get; set; }
        internal int[] Item { set; get; }

        public Stack(int size)
        {
            Size = size;
            Top = -1;
            Item = new int[size];
        }
    }
}
