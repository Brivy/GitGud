using GitGud.DS.Stack.Interfaces;
using System.Collections;

namespace GitGud.Ex.Fundamentals._1._3._12;

public class StackWithCopy<TItem>() : IStack<TItem>
{
    private Node? _first;
    private int _index;

    private sealed record Node
    {
        public required TItem Item;
        public Node? Next;
    }

    public void Push(TItem item)
    {
        var oldFirst = _first;
        _first = new Node
        {
            Item = item,
            Next = oldFirst
        };

        _index++;
    }

    public TItem Pop()
    {
        if (_first == null) throw new InvalidOperationException("Stack is empty");

        var item = _first.Item;
        _first = _first.Next;
        _index--;

        return item;
    }

    public bool IsEmpty() => _first == null;
    public int Size() => _index;

    public static StackWithCopy<TItem> Copy(StackWithCopy<TItem> stack)
    {
        var temp = new StackWithCopy<TItem>();
        foreach (var item in stack)
        {
            temp.Push(item);
        }

        var copy = new StackWithCopy<TItem>();
        foreach (var item in temp)
        {
            copy.Push(item);
        }

        return copy;
    }

    public IEnumerator<TItem> GetEnumerator()
    {
        if (_first == null)
            yield break;

        var node = _first;
        while (node != null)
        {
            yield return node.Item;
            node = node.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

