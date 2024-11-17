using GitGud.DS.Stack.Interfaces;
using System.Collections;

namespace GitGud.Ex.Fundamentals._1._3._7;

internal class StackWithPeek<TItem> : IStack<TItem>
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

    // Extra method for peeking without popping
    public TItem? Peek() => _first != null ? _first.Item : default;
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
