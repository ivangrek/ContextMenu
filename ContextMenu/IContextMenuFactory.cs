using System.Windows.Forms;

namespace ContextMenu
{
    public interface IContextMenuFactory<TContext>
        where TContext : IMenuContext
    {
        MenuStrip CreateMenu(TContext context);

        ContextMenuStrip CreateContextMenu(TContext context);

        ToolStrip CreateToolMenu(TContext context);
    }
}
