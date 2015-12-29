using Emoticoner.Emoticons;
using Emoticoner.Helpers;
using Emoticoner.Hooks;
using Emoticoner.Tool;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
        public Settings settings = new Settings();

        private ShortcutHook shortCutHook = new ShortcutHook();
        private EmoticonDatabase emoticonDatabase;
        private TabControl tabControl;
        private ContextMenu contextMenu = new ContextMenu();
        private EmoticonManager emoticonManager = new EmoticonManager();
        static public Font OurFont;

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
            InitSettings();
            InitializeEventHandlers();
            InitializeComponentByHand();
            Start();
        }

        private void InitSettings()
        {
            settings.Load();
            StringSender.Method = settings.Method;
            colorScheme = new ColorScheme(settings.Theme);

            buttonMenu.BackColor = colorScheme.colorButton;
        }

        public void ApplySettings()
        {
            shortCutHook.Dispose();
            InitSettings();
            setupColors();
            for (int i = 0; i < tabControl.TabCount; i++)
            {
                EmoticonLayer emoticonLayer = tabControl.TabPages[i].Controls[0] as EmoticonLayer;
                emoticonLayer.Redraw();
            }
            shortCutHook = new ShortcutHook();
            RegisterShortcut();

            emoticonManager.Close();
            emoticonManager = new EmoticonManager();
            /* Init EmoticonManager */
            /* Code dublication */
            emoticonManager.database = emoticonDatabase;
            emoticonManager.Tags = emoticonDatabase.tags;
            emoticonManager.Init();
        }

        private void EmoticonChangedHandle(object sender, ChangeEmoticonEventArgs eventArgs)
        {
            updateAll(sender as EmoticonLayer);
        }

        private void EmoticonDeletedHandler(object sender, DeleteEmoticonEventArgs eventArgs)
        {
            updateAll(sender as EmoticonLayer);
        }

        public void EmoticonAddedHandler(object sender, AddEmoticonEventArgs eventArgs)
        {
            updateAll(sender as EmoticonLayer);
        }

        private void updateAll(EmoticonLayer emoticonLayer)
        {
            emoticonLayer.SetEmoticons(emoticonDatabase.GetAll(emoticonLayer.Condition));
            emoticonLayer.UpdateElement();
        }

        private void Start()
        {
            toTray();
            notifyIcon1.BalloonTipTitle = "Emoticoner is runing";
            notifyIcon1.BalloonTipText = "Use tray icon or your shortcut";
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

            RegisterShortcut();
        }

        private void RegisterShortcut()
        {
            shortCutHook.RegisterHotKey(settings.ShortCutMod, (Keys)char.ToUpper(settings.ShortCutKey));
            shortCutHook.KeyPressed += new EventHandler<KeyPressedEventArgs>(HandlerGoFromTray);
        }

        private void InitializeComponentByHand()
        {
            InitializeForm();

            /* Init emoticonDatabase */
            emoticonDatabase = new EmoticonDatabase();
            emoticonDatabase.Load(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Emoticoner\Emoticons.xml");

            /* Init EmoticonManager */
            emoticonManager.database = emoticonDatabase;
            emoticonManager.Tags = emoticonDatabase.tags;
            emoticonManager.Init();

            /* Init tableLayoutPanels */
            tableLayoutPanelRoot.Width = ClientSize.Width;
            tableLayoutPanelRoot.Height = ClientSize.Height;
            setupColors();

            formMoveHook.SetupHandlers(tableLayoutPanelRoot);
            formMoveHook.SetupHandlers(tableLayoutPanelUp);
            formMoveHook.SetupHandlers(tableLayoutPanelDown);


            /* Init tabControl */
            tabControl = new TabControl()
            {
                Location = new Point(0, 0),
                Anchor = anchorFull,
            };
            
            formMoveHook.SetupHandlers(tabControl);
            tableLayoutPanelUp.Controls.Add(tabControl, 0, 0);
            

            /* Init tabs */
            addEmoticonTab("All", f => f.Id > 0);
            foreach (Tag tag in emoticonDatabase.tags)
            {
                addEmoticonTab(tag.Text, f => f.HaveTag(tag));
            }
            //addEmoticonTab("Other", f => f.Tags.Count == 0);

            /* Init contextMenu */
            InitializeContestMenu();
        }

        private void setupColors()
        {
            tableLayoutPanelRoot.BackColor = colorScheme.colorMainBG;
            tableLayoutPanelUp.BackColor = colorScheme.colorSectionBG;
            tableLayoutPanelDown.BackColor = colorScheme.colorSectionBG;
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
            SettingsForm settingsForm = new SettingsForm(settings, this);
            settingsForm.Show();
        }

        private void menuItemClickEmoticonManagerHandler(object sender, EventArgs e)
        {
            emoticonManager.Visible = true;
        }

        private void addEmoticonTab(string title, Predicate<Emoticon> condition)
        {
            TabPage tabPage = new TabPage() {
                Text = title,
                Anchor = anchorFull
            };
            tabControl.Controls.Add(tabPage);
            formMoveHook.SetupHandlers(tabPage);
            
            /* Init emoticonLayer */
            EmoticonLayer emoticonLayer = new EmoticonLayer(this)
            {              
                Size = tabPage.ClientSize,
                MinimalWidth = 80,
                MinimalHeight = 25,
                Font = Font,
                colorScheme = colorScheme,
                Margin = new Padding(3,3,3,3)
            };
            emoticonLayer.Anchor = anchorFull;
            emoticonLayer.MouseClick += mouseClickHandlerRightClickGoTray;
            formMoveHook.SetupHandlers(emoticonLayer);
            emoticonLayer.SetEmoticons(emoticonDatabase.GetAll(condition));
            emoticonLayer.Condition = condition;

            /* Scroll magic */
            emoticonLayer.HorizontalScroll.Maximum = 100;
            emoticonLayer.HorizontalScroll.Visible = false;
            emoticonLayer.HorizontalScroll.Enabled = false;
            emoticonLayer.VerticalScroll.Maximum = 0;
            emoticonLayer.VerticalScroll.Visible = false;
            emoticonLayer.AutoScroll = true;

            /* Events */
            emoticonDatabase.Subscribe(emoticonLayer, EmoticonAddedHandler);
            emoticonDatabase.Subscribe(emoticonLayer, EmoticonDeletedHandler);
            emoticonDatabase.Subscribe(emoticonLayer, EmoticonChangedHandle);

            tabPage.Controls.Add(emoticonLayer);
        }

        private void InitializeForm()
        {
            Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            OurFont = Font;
            ClientSize = new Size(364, 364);
            TopMost = true;
            FormBorderStyle = FormBorderStyle.None;

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
