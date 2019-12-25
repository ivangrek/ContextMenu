namespace ContextMenu
{
    public interface IAddSymbolCommand : ICommand
    {
        char Symbol { get; }
    }
}
