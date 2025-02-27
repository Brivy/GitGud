using System.Collections;

namespace GitGud.Ex.Fundamentals._1._3._19;

public class LinkedListIndexDeleter<TItem> : IEnumerable<TItem>
{
    private Node? _first;
    private int _index;

    private sealed class Node
    {
        public required TItem Item { get; init; }
        public Node? Next { get; set; }
    }

    public void Add(TItem item)
    {
        var oldFirst = _first;
        _first = new Node
        {
            Item = item,
            Next = oldFirst
        };

        _index++;
    }

    public void RemoveAtIndex(int index)
    {
        if (IsEmpty()) return;
        if (index == 0)
        {
            if (_index == 1) _first = null;
            else _first = _first!.Next;
            return;
        }

        var node = _first;
        for (var i = 0; i < index - 1; i++)
        {
            if (node!.Next == null) return; // if you ever encounter a null, just quit
            node = node.Next;
        }

        if (node!.Next == null) return; // safeguard for if you try to delete something right out of your index
        node!.Next = node!.Next!.Next; // overwrite the node that you are supposed to delete
    }

    public bool IsEmpty() => _first == null;
    public int Size() => _index;

    public IEnumerator<TItem> GetEnumerator()
    {
        if (IsEmpty())
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
