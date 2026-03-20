using System;

namespace StackArray
{
    class MyStack<T>
    {
        private T[] elements;
        private int top;
        private int max;

        public MyStack(int size)
        {
            elements = new T[size];
            top = -1;
            max = size;
        }

        public void Push(T item)
        {
            if (top == max - 1)
            {
                Console.WriteLine("Stack Overflow!");
                return;
            }

            elements[++top] = item;
        }

        public T Pop()
        {
            if (top == -1)
            {
                Console.WriteLine("Stack Underflow!");
                return default(T);
            }

            return elements[top--];
        }

        public T Peek()
        {
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