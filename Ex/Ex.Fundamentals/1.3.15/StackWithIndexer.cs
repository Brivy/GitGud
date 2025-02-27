using GitGud.DS.Stack.Interfaces;
using System.Collections;

namespace GitGud.Ex.Fundamentals._1._3._15;

public class StackWithIndexer<TItem> : IStack<TItem>
{
    private Node? _first;
    private int _index;

    private sealed record Node
    {
        public required TItem Item { get; init; }
        public Node? Next { get; init; }
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
        if (IsEmpty()) throw new InvalidOperationException("Stack is empty");

        var item = _first!.Item;
        _first = _first.Next;
        _index--;

        return item;
    }

    public TItem this[int index]
    {
        get
        {
            var indexedNode = _first;
            for (var i = 0; i < index; i++)
            {
                indexedNode = indexedNode?.Next ?? throw new InvalidOperationException("Index not found");
            }

            return indexedNode!.Item;
        }
    }

    public int Size() => _index;
    public bool IsEmpty() => _index == 0;

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
