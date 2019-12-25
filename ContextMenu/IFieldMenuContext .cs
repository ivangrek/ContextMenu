namespace ContextMenu
{
    public interface IFieldMenuContext : IMenuContext
    {
        bool AActionEnabled { get; }

        bool BActionEnabled { get; }

        bool CActionEnabled { get; }
    }
}
