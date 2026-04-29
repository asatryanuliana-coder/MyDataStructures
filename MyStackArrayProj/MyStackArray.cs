using System;

namespace MyStackArrayProj
{
    // MyStack-ը հանում ենք MyStackArray-ի միջից, որպեսզի ավելի հեշտ լինի օգտագործել
    public class MyStack<T>
    {
        private T[] elements;
        private int top;
        private int max;

        public MyStack(int size)
        {
            // Սխալ 1. պետք է լինի new T[size], ոչ թե new int[size]
            elements = new T[size];
            top = -1;
            max = size;
        }

        // Սխալ 2. պետք է ընդունի T item, ոչ թե int item
        public void Push(T item)
        {
            if (top == max - 1)
            {
                Console.WriteLine("Stack Overflow!");
                return;
            }
            elements[++top] = item;
        }

        // Սխալ 3. պետք է վերադարձնի T, ոչ թե int
        public T Pop()
        {
            if (top == -1)
            {
                Console.WriteLine("Stack Underflow!");
                return default(T); // default(T)-ն վերադարձնում է null կամ 0՝ կախված տիպից
            }
            return elements[top--];
        }

        public T Peek()
        {
            if (top == -1) return default(T);
            return elements[top];
        }

        public void Display()
        {
            for (int i = top; i >= 0; i--)
            {
                Console.WriteLine(elements[i]);
            }
        }
    }

    class Program
    {
        static void Main()
        {
            // Սխալ 4. պետք է նշել տիպը փակագծերի մեջ <int>
            MyStack<int> stack = new MyStack<int>(5);

            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            Console.WriteLine("Current Stack:");
            stack.Display();

            Console.WriteLine("Top element: " + stack.Peek());
            Console.WriteLine("Removed: " + stack.Pop());

            Console.WriteLine("Stack after Pop:");
            stack.Display();
        }
    }
}