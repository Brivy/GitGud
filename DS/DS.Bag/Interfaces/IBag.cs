namespace GitGud.DS.Bag.Interfaces;

internal interface IBag<TItem> : IEnumerable<TItem>
{
    void Add(TItem item);
    bool IsEmpty();
    int Size();
}
