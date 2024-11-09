namespace GitGud.DS.Queue.Interfaces;

internal interface IQueue<TItem> : IEnumerable<TItem>
{
    void Enqueue(TItem item);
    TItem Dequeue();
    bool IsEmpty();
    int Size();
}
