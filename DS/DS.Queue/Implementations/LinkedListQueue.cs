using GitGud.DS.Queue.Interfaces;
using System.Collections;

namespace GitGud.DS.Queue.Implementations;

public class LinkedListQueue<TItem> : IQueue<TItem>
{
    private Node? _first;
    private Node? _last;
    private int _index;

    private sealed record Node
    {
        public required TItem Item;
        public Node? Next;
    }

    public void Enqueue(TItem item)
    {
        var oldLast = _last;
        _last = new Node
        {
            Item = item
        };

        if (IsEmpty())
            _first = _last;
        else
            oldLast!.Next = _last;

        _index++;
    }

    public TItem Dequeue()
    {
        if (_first == null) throw new InvalidOperationException("Queue is empty");

        var item = _first.Item;
        _first = _first.Next;

        if (IsEmpty())
            _last = null;

        _index--;

        return item;
    }

    public bool IsEmpty() => _first == null;
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
