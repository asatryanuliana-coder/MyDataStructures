using System.Collections;
using MyLinkedListProj;

namespace MyQueueProj;

public class MyQueue<T> : IEnumerable<T>
{
    MyLinkedList<T> items = new MyLinkedList<T>();
    
    public void Enqueue(T item)
    {
        items.AddLast(item);

    }
    public T Dequeue()
    {
        if (items.Count == 0)
            throw new InvalidOperationException("Queue is empty");
        T value = items.Head.Value;
        items.RemoveHead();
        return value;
    }
    public T Peek()
    {
        if (items.Count == 0)
            throw new InvalidOperationException("Queue is empty ");
        return items.Head.Value;
    }
    
    public IEnumerator<T> GetEnumerator()
    {
        return items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}


