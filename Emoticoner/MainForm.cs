using Emoticoner.Emoticons;
using Emoticoner.Helpers;
using Emoticoner.Hooks;
using Emoticoner.Tool;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Emoticoner
{
    /// <summary>
    /// Main Form
    /// </summary>
    public partial class MainForm : Form
    {
        public MouseEventHandler mouseClickHandlerRightClickGoTray;
        public FormMoveHook formMoveHook;
        public ColorScheme colorScheme;

        private ShortcutHook shortCutHook = new ShortcutHook();
        private EmoticonDatabase emoticonDatabase;
        private TabControl tabControl;
        private ContextMenu contextMenu = new ContextMenu();
        private EmoticonManager emoticonManager = new EmoticonManager();

        // Maybe move it
        public const AnchorStyles anchorFull = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left);

        /* Black magic hook. Fix flickering when untray (not work for first time) */
        /* http://stackoverflow.com/questions/2612487/how-to-fix-the-flickering-in-user-controls */
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        public MainForm()
        {
            InitializeComponent();
            InitializeEventHandlers();
            InitializeComponentByHand();
            Start();
        }

        private void Start()
        {
            toTray();
            notifyIcon1.BalloonTipTitle = "App is runing";
            notifyIcon1.BalloonTipText = "Use alt+e";
            notifyIcon1.ShowBalloonTip(2000);

            for (int i = 0; i < tabControl.TabCount; i++)
            {
                EmoticonLayer emoticonLayer = tabControl.TabPages[i].Controls[0] as EmoticonLayer;
                emoticonLayer.Start();
            }
        }

        public void toTray()
        {
            Hide();
            WindowState = FormWindowState.Minimized;
            notifyIcon1.Visible = true;
        }

        public void fromTray()
        {
            Show();
            WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void InitializeEventHandlers()
        {
            formMoveHook = new FormMoveHook(this);
            formMoveHook.SetupHandlers(this);

            mouseClickHandlerRightClickGoTray = new MouseEventHandler(MouseClickHandlerRightClickGoTray);
            MouseClick += mouseClickHandlerRightClickGoTray;
            KeyPress += new KeyPressEventHandler(KeyPressHandlerEscapeGoTray);
            Resize += new EventHandler(this.HandlerResize);

            shortCutHook.RegisterHotKey(ModifierKeysEnum.Alt, Keys.E);
            shortCutHook.KeyPressed += new EventHandler<KeyPressedEventArgs>(HandlerGoFromTray);
        }

        private void InitializeComponentByHand()
        {
            InitializeForm();

            /* Init colorScheme */
            colorScheme = new ColorScheme();

            /* Init emoticonDatabase */
            emoticonDatabase = new EmoticonDatabase();
            emoticonDatabase.Load("Emoticons.xml");

            emoticonManager.database = emoticonDatabase;

            /* Init tableLayoutPanelRoot */
            tableLayoutPanelRoot.Width = ClientSize.Width;
            tableLayoutPanelRoot.Height = ClientSize.Height;
            tableLayoutPanelRoot.BackColor = colorScheme.color2;
            formMoveHook.SetupHandlers(tableLayoutPanelRoot);

            /* Init tabControl */
            tabControl = new TabControl()
            {
                Location = new Point(0, 0),
                Anchor = anchorFull
            };
            formMoveHook.SetupHandlers(tabControl);
            tableLayoutPanelRoot.Controls.Add(tabControl, 0, 0);

            /* Init tabs */
            addEmoticonTab("All", f => f.id > 0);

            /* Init contextMenu */
            InitializeContestMenu();
        }

        private void InitializeContestMenu()
        {
            contextMenu.MenuItems.Add(new MenuItem() { Text = "Emoticon manager" });
            contextMenu.MenuItems[contextMenu.MenuItems.Count - 1].Click += menuItemClickEmoticonManagerHandler;

            contextMenu.MenuItems.Add(new MenuItem() { Text = "Settings" });
            contextMenu.MenuItems[contextMenu.MenuItems.Count - 1].Click += menuItemClickSettingsHandler;

            contextMenu.MenuItems.Add(new MenuItem() { Text = "About" });
            contextMenu.MenuItems[contextMenu.MenuItems.Count - 1].Click += menuItemClickAboutHandler;

            contextMenu.MenuItems.Add(new MenuItem() { Text = "Exit" });
            contextMenu.MenuItems[contextMenu.MenuItems.Count - 1].Click += menuItemClickExitHandler;

        }

        private void menuItemClickExitHandler(object sender, EventArgs e)
        {
            Close();
        }

        private void menuItemClickAboutHandler(object sender, EventArgs e)
        {
            MessageBox.Show("Visit https://github.com/nibomed/Emoticoner for more info");
        }

        private void menuItemClickSettingsHandler(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void menuItemClickEmoticonManagerHandler(object sender, EventArgs e)
        {
            emoticonManager.Visible = true;
        }

        private void addEmoticonTab(string title, Predicate<Emoticon> condition)
        {
            TabPage tabPage = new TabPage() {
                Text = title,
            };
            tabControl.Controls.Add(tabPage);
            formMoveHook.SetupHandlers(tabPage);
            
            /* Init emoticonLayer */
            EmoticonLayer emoticonLayer = new EmoticonLayer(this)
            {
                Width = ClientSize.Width,
                Height = ClientSize.Height,
                Location = new Point(0, 0),
                MinimalWidth = 80,
                MinimalHeight = 25,
                Font = Font,
                colorScheme = colorScheme,
                Margin = new Padding(3,3,3,50)
            };
            emoticonLayer.Anchor = anchorFull;
            emoticonLayer.MouseClick += mouseClickHandlerRightClickGoTray;
            formMoveHook.SetupHandlers(emoticonLayer);
            emoticonLayer.AddEmoticons(emoticonDatabase.GetAll(condition));

            /* Scroll magic */
            emoticonLayer.HorizontalScroll.Maximum = 1;
            emoticonLayer.HorizontalScroll.Visible = false;
            emoticonLayer.HorizontalScroll.Enabled = false;
            emoticonLayer.VerticalScroll.Maximum = 0;
            emoticonLayer.VerticalScroll.Visible = false;
            emoticonLayer.AutoScroll = true;

            tabPage.Controls.Add(emoticonLayer);
        }

        private void InitializeForm()
        {
            Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            ClientSize = new Size(364, 364);
            TopMost = true;
        }

        private void HandlerGoFromTray(object sender, EventArgs e)
        {
            fromTray();
        }

        private void HandlerResize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
            {
                toTray();
            }
            else if (FormWindowState.Normal == WindowState)
            {
                fromTray();
            }
        }

        private void NotyfiIconMouseClickHandler(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                fromTray();
            }
            else if (e.Button == MouseButtons.Right)
            {
                // TODO show menu here
                Close();
            }
        }

        private void KeyPressHandlerEscapeGoTray(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                toTray();
            }
        }

        private void MouseClickHandlerRightClickGoTray(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                toTray();
            }
        }

        private void buttonMenuClick(object sender, EventArgs e)
        {
            contextMenu.Show(buttonMenu, new Point(0, 0));
        }
    }
}
