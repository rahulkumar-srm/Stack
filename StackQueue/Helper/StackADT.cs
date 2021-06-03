using StackQueue.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackQueue.Helper
{
    internal class StackADT
    {
        static Stack stack;

        public StackADT(int size)
        {
            stack = new Stack(size);
        }

        internal bool IsEmpty()
        {
            return stack.Top == -1;
        }

        internal bool IsFull()
        {
            return stack.Top == stack.Size - 1;
        }

        internal void Push(int num)
        {
            if (IsFull())
            {
                Console.WriteLine("Stack overflow");
            }
            else
            {
                stack.Item[++stack.Top] = num;
            }
        }

        internal int Pop()
        {
            if (IsEmpty())
            {
                return ' ';
            }
            else
            {
                return stack.Item[stack.Top--];
            }
        }

        internal int StackTop()
        {
            if (IsEmpty())
            {
                return ' ';
            }
            else
            {
                return stack.Item[stack.Top];
            }
        }

        internal void Peek()
        {
            Console.WriteLine("Enter the index number");

            int index = Convert.ToInt32(Console.ReadLine());

            if ((stack.Top - index + 1) < 0)
            {
                Console.WriteLine("Invalid index");
            }
            else
                Console.WriteLine(stack.Item[stack.Top - index + 1]);
        }

        internal void Display()
        {
            for(int i = 0; i <= stack.Top; i++)
            {
                Console.WriteLine(stack.Item[i]);
            }
        }
    }
}