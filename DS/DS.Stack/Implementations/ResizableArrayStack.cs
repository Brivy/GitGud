using GitGud.DS.Stack.Interfaces;
using System.Collections;

namespace GitGud.DS.Stack.Implementations;

public class ResizableArrayStack<TItem>(int cap) : IStack<TItem>
{
    private TItem[] _items = new TItem[cap];
    private int _index;

    public void Push(TItem item)
    {
        if (_index == _items.Length)
            Resize(2 * _items.Length);
        _items[_index++] = item;
    }

    public TItem Pop()
    {
        var item = _items[--_index];
        if (_index > 0 && _index == _items.Length / 4)
            Resize(_items.Length / 2);
        return item;

    }
    public bool IsEmpty() => _index == 0;
    public int Size() => _index;

    private void Resize(int max)
    {
        var tempItems = new TItem[max];
        for (var i = 0; i < _index; i++)
            tempItems[i] = _items[i];
        _items = tempItems;
    }

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
