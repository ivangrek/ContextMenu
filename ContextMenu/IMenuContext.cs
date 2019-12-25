using System;

namespace ContextMenu
{
    public interface IMenuContext
    {
        event Action ContextChanged;
    }
}
