using GitGud.DS.Bag.Interfaces;
using System.Collections;

namespace GitGud.DS.Bag.Implementations;

public class LinkedListBag<TItem> : IBag<TItem>
{
    private Node? _first;
    private int _index;

    private sealed record Node
    {
        public required TItem Item;
        public Node? Next;
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

    public bool IsEmpty() => _index == 0;
    public int Size() => _index;

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
