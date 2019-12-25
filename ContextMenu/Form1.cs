using System;
using System.Windows.Forms;

namespace ContextMenu
{
    public partial class Form1 : Form, IFieldMenuContext, ICommandHandler
    {
        public Form1()
        {
            InitializeComponent();

            var factory = new FieldContextMenuFactory(this);

            var contextMenu = factory.CreateContextMenu(this);

            contextMenu.SuspendLayout();

            this.textBox1.ContextMenuStrip = contextMenu;

            contextMenu.ResumeLayout(false);

            var tool = factory.CreateToolMenu(this);

            Controls.Add(tool);

            tool.ResumeLayout(false);
            tool.PerformLayout();

            var menu = factory.CreateMenu(this);

            Controls.Add(menu);
            MainMenuStrip = menu;

            menu.ResumeLayout(false);
            menu.PerformLayout();
        }

        #region MenuContext

        public event Action ContextChanged;

        public bool AActionEnabled { get; set; } = true;

        public bool BActionEnabled { get; set; } = false;

        public bool CActionEnabled { get; set; } = false;

        #endregion MenuContext

        #region CommandHandler

        void ICommandHandler.Handle<TCommand>(TCommand command)
        {
            switch (command)
            {
                case IAddSymbolCommand addSymbolCommand:
                    switch (addSymbolCommand.Symbol)
                    {
                        case 'A':
                            AActionEnabled = false;
                            BActionEnabled = true;
                            CActionEnabled = false;
                            break;
                        case 'B':
                            AActionEnabled = false;
                            BActionEnabled = false;
                            CActionEnabled = true;
                            break;
                        case 'C':
                            AActionEnabled = true;
                            BActionEnabled = false;
                            CActionEnabled = false;
                            break;
                        default:
                            throw new InvalidOperationException("Unknown symbol.");
                    }

                    textBox1.Text += addSymbolCommand.Symbol;

                    ContextChanged?.Invoke();
                    break;
                default:
                    throw new InvalidOperationException("Unknown command.");
            }
        }

        #endregion CommandHandler

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thanks!");
        }
    }
}
