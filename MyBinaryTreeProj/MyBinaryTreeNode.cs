using System.Collections;
namespace MyBinaryTreeProj;

public class BinaryTree<T> : IEnumerable<T>
     where T : IComparable<T>
{
    private BinaryTreeNode<T> _head; 
    private int _count;

    #region Add
    public void Add(T value)
    {
        BinaryTreeNode<T> newNode = new BinaryTreeNode<T>(value);

        if (_head == null)
        {
            _head = newNode;
            _count++;
            return;
        }

        BinaryTreeNode<T> current = _head;

        while (true)
        {
            int result = value.CompareTo(current.Value);

            if (result < 0)
            {
                if (current.Left == null)
                {
                    current.Left = newNode;
                    break;
                }
                current = current.Left;
            }

            else
            {
                if (current.Right == null)
                {
                    current.Right = newNode;
                    break;
                }
                current = current.Right;
            }
        }

        _count++;
    }

    #endregion Add

    public bool? Contains(T value)
    {
        if (_head == null)
            return null;

        return Contains(_head, value);
    }

    private bool Contains(BinaryTreeNode<T> node, T value)
    {
        int result = value.CompareTo(node.Value);

        if (result == 0)
            return true;

        if (result < 0)
        {
            if (node.Left == null)
                return false;

            return Contains(node.Left, value);
        }
        else
        {
            if (node.Right == null)
                return false;

            return Contains(node.Right, value);
        }
    }


    #region Remove
    public bool Remove(T value)
    {
        BinaryTreeNode<T> current = _head;
        BinaryTreeNode<T> parent = null;

        while (current != null)
        {
            int result = value.CompareTo(current.Value);

            if (result == 0)
                break;

            parent = current;

            if (result < 0)
                current = current.Left;
            else
                current = current.Right;
        }

        if (current == null)
            return false;

        if (current.Left == null && current.Right == null)
        {
            if (parent == null)
                _head = null;
            else if (parent.Left == current)
                parent.Left = null;
            else
                parent.Right = null;
        }

        else if (current.Left == null || current.Right == null)
        {
            BinaryTreeNode<T> child = current.Left ?? current.Right;

            if (parent == null)
                _head = child;
            else if (parent.Left == current)
                parent.Left = child;
            else
                parent.Right = child;
        }


        else
        {
            BinaryTreeNode<T> successorParent = current;
            BinaryTreeNode<T> successor = current.Right;

            while (successor.Left != null)
            {
                successorParent = successor;
                successor = successor.Left;
            }

            current.Value = successor.Value;

            if (successorParent.Left == successor)
                successorParent.Left = successor.Right;
            else
                successorParent.Right = successor.Right;
        }

        _count--;
        return true;
    }
    #endregion Remove
    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}