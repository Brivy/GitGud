using System.Collections;

namespace GitGud.Ex.Fundamentals._1._3._21;

public class LinkedListFinder : IEnumerable<string>
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

    public bool Find(string key)
    {
        if (IsEmpty())
            return false;

        for (var x = _first; x != null; x = x.Next)
            if (x.Item == key) return true;

        return false;
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
