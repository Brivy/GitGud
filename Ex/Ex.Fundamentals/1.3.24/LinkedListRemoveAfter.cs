using System.Collections;

namespace GitGud.Ex.Fundamentals._1._3._24;

public class LinkedListRemoveAfter : IEnumerable<string>
{
    private Node? _first;
    private int _index;

    private sealed class Node
    {
        public required string Item { get; init; }
        public Node? Next { get; set; }
    }

    public void Add(string item)
    {
        var oldFirst = _first;
        _first = new Node
        {
            Item = item,
            Next = oldFirst
        };

        _index++;
    }

    public void RemoveAfter(string key)
    {
        if (IsEmpty())
            return;

        for (var x = _first; x != null; x = x.Next)
        {
            if (x.Item != key) continue;
            if (x.Next == null || x.Next.Next == null) continue;
            x.Next = x.Next.Next;
        }
    }

    public bool IsEmpty() => _first == null;
    public int Size() => _index;

    public IEnumerator<string> GetEnumerator()
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
