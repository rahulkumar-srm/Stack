using StackQueue.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the expression");
            string exp = Console.ReadLine();
            EvaluateExpression(exp);
            Console.ReadKey();
        }

        private static void IsBalanced(string exp)
        {
            StackADT stackADT = new StackADT(50);

            for (int i = 0; i < exp.Length; i++)
            {
                if (exp[i] == '(')
                {
                    stackADT.Push(exp[i]);
                }
                else if (exp[i] == ')')
                {
                    if (stackADT.IsEmpty())
                    {
                        Console.WriteLine("Not Balanced");
                        return;
                    }

                    stackADT.Pop();
                }
            }

            if (stackADT.IsEmpty())
            {
                Console.WriteLine("Balanced");
                return;
            }
            else
            {
                Console.WriteLine("Not Balanced");
                return;
            }
        }

        private static void EvaluateExpression(string postfixExp)
        {
            StackADT stackADT = new StackADT(50);
            int res = 0;

            foreach(var item in postfixExp)
            {
                if(IsOperator(item))
                {
                    int x2 = stackADT.Pop();
                    int x1 = stackADT.Pop();

                    switch (item)
                    {
                        case '+': res = x1 + x2; break;
                        case '-': res = x1 - x2; break;
                        case '*': res = x1 * x2; break;
                        case '/': res = x1 / x2; break;
                        case '^': res = Convert.ToInt32(Math.Pow(x2, x1)); break;
                    }
                    stackADT.Push(res);
                }
                else
                {
                    stackADT.Push(item - '0');
                }
            }

            Console.WriteLine(res);
        }

        //private static void ConvertToPostFix(string infixExp)
        //{
        //    StringBuilder postfix = new StringBuilder();
        //    StackADT stackADT = new StackADT(50);
        //    int i = 0;

        //    while(i != infixExp.Length)
        //    {
        //        if(IsOperator(infixExp[i]))
        //        {
        //            if(stackADT.IsEmpty())
        //            {
        //                stackADT.Push(infixExp[i++]);
        //            }
        //            else
        //            {
        //                if(OutStackPre(infixExp[i]) > InStackPre(stackADT.StackTop()))
        //                {
        //                    stackADT.Push(infixExp[i++]);
        //                }
        //                else if (OutStackPre(infixExp[i]) == InStackPre(stackADT.StackTop()))
        //                {
        //                    stackADT.Pop();
        //                    i++;
        //                }
        //                else
        //                {
        //                    postfix.Append(stackADT.Pop());
        //                }
        //            }
        //        }
        //        else
        //        {
        //            postfix.Append(infixExp[i++]);
        //        }
        //    }

        //    while(!stackADT.IsEmpty())
        //    {
        //        postfix.Append(stackADT.Pop());
        //    }

        //    Console.WriteLine(postfix);
        //}

        private static bool IsOperator(char c)
        {
            char[] operand = { '+', '-', '*', '/' , '^', '(', ')' };
            if (operand.Contains(c))
                return true;
            else
                return false;
        }

        private static int InStackPre(char c)
        {
            if (c == '+' || c == '-')
            {
                return 2;
            }
            else if (c == '*' || c == '/')
            {
                return 4;
            }
            else if (c == '^')
            {
                return 5;
            }
            else if (c == '(')
            {
                return 0;
            }
            else
                return -1;
        }

        private static int OutStackPre(char c)
        {
            if (c == '+' || c == '-')
            {
                return 1;
            }
            else if (c == '*' || c == '/')
            {
                return 3;
            }
            else if (c == '^')
            {
                return 6;
            }
            else if (c == '(')
            {
                return 7;
            }
            else if (c == ')')
            {
                return 0;
            }
            else
                return -1;
        }

        private static void StackOperation()
        {
            StackUsingLinkedlist stack = new StackUsingLinkedlist();

            while (true)
            {
                Console.WriteLine
                    ("Please select an option" +
                        Environment.NewLine + "1. Push Stack" +
                        Environment.NewLine + "2. Pop Stack" +
                        Environment.NewLine + "3. Check for empty Stack" +
                        Environment.NewLine + "4. Peek Stack" +
                        Environment.NewLine + "5. Stack top" +
                        Environment.NewLine + "6. Display Stack" +
                        Environment.NewLine + "0. Exit"
                    );

                if (!int.TryParse(Console.ReadLine(), out int i))
                {
                    Console.WriteLine(Environment.NewLine + "Input format is not valid. Please try again." + Environment.NewLine);

                }

                if (i == 0)
                {
                    Environment.Exit(0);
                }
                else if (i == 1)
                {
                    stack.Push();
                }
                else if (i == 2)
                {
                    stack.Pop();
                }
                else if (i == 3)
                {
                    Console.WriteLine(stack.IsEmpty() ? "Yes" : "No");
                }
                else if (i == 4)
                {
                    stack.Peek();
                }
                else if (i == 5)
                {
                    stack.StackTop();
                }
                else if (i == 6)
                {
                    stack.Display();
                }
                else
                {
                    Console.WriteLine("Please select a valid option.");
                }
            }
        }
    }
}
