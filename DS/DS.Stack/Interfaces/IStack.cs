namespace GitGud.DS.Stack.Interfaces;

public interface IStack<TItem> : IEnumerable<TItem>
{
    void Push(TItem item);
    TItem Pop();
    bool IsEmpty();
    int Size();
}
