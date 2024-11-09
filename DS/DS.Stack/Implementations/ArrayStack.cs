using GitGud.DS.Stack.Interfaces;
using System.Collections;

namespace GitGud.DS.Stack.Implementations;

internal class ArrayStack<TItem>(int cap) : IStack<TItem>
{
    private readonly TItem[] _items = new TItem[cap];
    private int _index;

    public void Push(TItem item) => _items[_index++] = item;
    public TItem Pop() => _items[--_index];
    public bool IsEmpty() => _index == 0;
    public int Size() => _index;

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
