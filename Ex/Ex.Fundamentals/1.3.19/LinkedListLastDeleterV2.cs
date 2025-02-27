using System.Collections;

namespace GitGud.Ex.Fundamentals._1._3._19;

public class LinkedListLastDeleterV2<TItem> : IEnumerable<TItem>
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

    public void RemoveLastNode()
    {
        if (IsEmpty()) return;
        if (_index == 1)
        {
            _first = null;
            return;
        }

        for (var x = _first; x != null; x = x.Next)
        {
            if (x!.Next!.Next == null)
            {
                x.Next = null;
            }
        }
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
