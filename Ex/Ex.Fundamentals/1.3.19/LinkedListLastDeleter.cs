using System.Collections;

namespace GitGud.Ex.Fundamentals._1._3._19;

public class LinkedListLastDeleter<TItem> : IEnumerable<TItem>
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

        var nextNode = _first;
        do
        {
            if (nextNode!.Next!.Next == null)
            {
                nextNode.Next = null;
            }
            nextNode = nextNode.Next;
        } while (nextNode != null);
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
