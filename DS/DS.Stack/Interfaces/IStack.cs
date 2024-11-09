namespace GitGud.DS.Stack.Interfaces;

internal interface IStack<TItem> : IEnumerable<TItem>
{
    void Push(TItem item);
    TItem Pop();
    bool IsEmpty();
    int Size();
}
