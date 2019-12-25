namespace ContextMenu
{
    public interface ICommandHandler
    {
        void Handle<TCommand>(TCommand command)
            where TCommand : ICommand;
    }
}
