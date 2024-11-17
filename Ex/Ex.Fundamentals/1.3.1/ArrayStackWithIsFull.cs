using GitGud.DS.Stack.Interfaces;
using System.Collections;

namespace GitGud.Ex.Fundamentals._1._3._1;

public class ArrayStackWithIsFull<TItem>(int cap) : IStack<TItem>
{
    private readonly TItem[] _items = new TItem[cap];
    private int _index;

    public void Push(TItem item) => _items[_index++] = item;
    public TItem Pop() => _items[--_index];
    public bool IsEmpty() => _index == 0;
    public int Size() => _index;
    // Additional method for 1.3.1
    public bool IsFull() => _items.Length == _index;

    public IEnumerator<TItem> GetEnumerator()
    {
        foreach (var item in _items)
            yield return item;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

