using System;
using System.Windows.Forms;

namespace ContextMenu
{
    public sealed class FieldContextMenuFactory : IContextMenuFactory<IFieldMenuContext>
    {
        private readonly ICommandHandler commandHandler;

        public FieldContextMenuFactory(ICommandHandler commandHandler)
        {
            this.commandHandler = commandHandler;
        }

        public MenuStrip CreateMenu(IFieldMenuContext context)
        {
            var addMenuItem = new ToolStripMenuItem();

            addMenuItem.Text = "Menu";
            addMenuItem.DropDownItems
                .AddRange(Items(context));

            var menu = new MenuStrip();

            menu.Items.AddRange(new[]
            {
                addMenuItem
            });

            return menu;
        }

        public ContextMenuStrip CreateContextMenu(IFieldMenuContext context)
        {
            var contextMenu = new ContextMenuStrip();

            contextMenu.Items
                .AddRange(Items(context));

            return contextMenu;
        }

        public ToolStrip CreateToolMenu(IFieldMenuContext context)
        {
            var toolMenu = new ToolStrip();

            toolMenu.Items
                .AddRange(Items(context));

            return toolMenu;
        }

        private ToolStripItem[] Items(IFieldMenuContext context)
        {
            var addAMenuItem = new ToolStripMenuItem();

            addAMenuItem.Text = "Add A";
            addAMenuItem.Click += (object sender, EventArgs e) =>
            {
                var command = new AddSymbodCommand
                {
                    Symbol = 'A'
                };

                this.commandHandler
                    .Handle(command);
            };

            var addBMenuItem = new ToolStripMenuItem();

            addBMenuItem.Text = "Add B";
            addBMenuItem.Click += (object sender, EventArgs e) =>
            {
                var command = new AddSymbodCommand
                {
                    Symbol = 'B'
                };

                this.commandHandler
                    .Handle(command);
            };

            var addCMenuItem = new ToolStripMenuItem();

            addCMenuItem.Text = "Add C";
            addCMenuItem.Click += (object sender, EventArgs e) =>
            {
                var command = new AddSymbodCommand
                {
                    Symbol = 'C'
                };

                this.commandHandler
                    .Handle(command);
            };

            context.ContextChanged += OnContextChanged;

            void OnContextChanged()
            {
                addAMenuItem.Enabled = context.AActionEnabled;
                addBMenuItem.Enabled = context.BActionEnabled;
                addCMenuItem.Enabled = context.CActionEnabled;
            };

            OnContextChanged();

            return new[]
            {
                addAMenuItem,
                addBMenuItem,
                addCMenuItem
            };
        }

        private sealed class AddSymbodCommand : IAddSymbolCommand
        {
            public char Symbol { get; set; }
        }
    }
}
