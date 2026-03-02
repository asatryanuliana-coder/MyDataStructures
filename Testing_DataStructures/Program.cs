
using MyLinkedListProj;
namespace Testing_DataStructures;

public class Program
{
    private static void Main()
    {
        Console.WriteLine("=======Hello Void=======");

        #region LinkedList
        var linkedList = new MyLinkedList<string>();

        linkedList.AddFirst("Aleph");
        linkedList.AddFirst("Betta");
        linkedList.AddFirst("Daleph");
        linkedList.AddFirst("Gileman");
        linkedList.AddFirst("La+");

        foreach (var item in linkedList)
        {
            Console.WriteLine($"Current Item: {item}");
        }

        Console.WriteLine();
        linkedList.RemoveFirst<string>();
        linkedList.RemoveFirst<string>();

        foreach (var item in linkedList)
        {
            Console.WriteLine($"Current Item: {item}");
        }
        #endregion LinkedList
    }
}