using StackQueue.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackQueue.Helper
{
    internal class StackUsingLinkedlist
    {
        private Node top = null;

        internal bool IsEmpty()
        {
            return top == null;
        }

        internal void Push()
        {
            Console.WriteLine("Enter the number to be pushed");
            int num = Convert.ToInt32(Console.ReadLine());

            Node node = new Node(num);

            if (node == null)
            {
                Console.WriteLine("Stack overflow");
            }   
            else
            {
                node.Next = top;
                top = node;
            }
        }

        internal void Pop()
        {
            if (top == null)
            {
                Console.WriteLine("Stack underflow");
            }
            else
            {
                top = top.Next;
            }
        }

        internal void StackTop()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Stack is empty");
            }
            else
            {
                Console.WriteLine(top.Data);
            }
        }

        internal void Peek()
        {
            Console.WriteLine("Enter the index number");
            int index = Convert.ToInt32(Console.ReadLine());

            Node tempNode = top;

            for(int i = 0; i < index - 1; i++)
            {
                if(tempNode == null)
                {
                    Console.WriteLine("Invalid index");
                    return;
                }
                tempNode = tempNode.Next;
            }

            Console.WriteLine(tempNode.Data);
        }

        internal void Display()
        {
            Node tempNode = top;
            while (tempNode != null)
            {
                Console.WriteLine(tempNode.Data);
                tempNode = tempNode.Next;
            }
        }
    }
}
