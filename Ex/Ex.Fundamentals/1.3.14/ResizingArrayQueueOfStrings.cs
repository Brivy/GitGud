using GitGud.DS.Queue.Interfaces;
using System.Collections;

namespace GitGud.Ex.Fundamentals._1._3._14;

public class ResizingArrayQueueOfStrings<TItem>(int cap) : IQueue<TItem>
{
    private TItem[] _items = new TItem[cap];
    private int _index;

    public void Enqueue(TItem item)
    {
        if (_index == _items.Length)
            Resize(2 * _items.Length);
        _items[_index++] = item;
    }

    public TItem Dequeue()
    {
        var item = _items[0];
        Reorder();
        _index--;

        if (_index > 0 && _index == _items.Length / 4)
            Resize(_items.Length / 2);
        return item;
    }

    private void Reorder()
    {
        var tempItems = new TItem[_items.Length];
        for (var i = 1; i < _index; i++)
            tempItems[i - 1] = _items[i];
        _items = tempItems;
    }

    private void Resize(int max)
    {
        var tempItems = new TItem[max];
        for (var i = 0; i < _index; i++)
            tempItems[i] = _items[i];
        _items = tempItems;
    }

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
