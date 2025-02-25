namespace GitGud.DS.Queue.Interfaces;

public interface IQueue<TItem> : IEnumerable<TItem>
{
    void Enqueue(TItem item);
    TItem Dequeue();
    bool IsEmpty();
    int Size();
}
