using Emoticoner.Algo;
using Emoticoner.Hooks;
using Emoticoner;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using Emoticoner.Helpers;

namespace Emoticoner.Emoticons
{
    public partial class EmoticonLayer : TableLayoutPanel
    {
        List<Emoticon> emoticons = new List<Emoticon>();
        //TODO: Calc it based on form and emoticons
        public int MinimalWidth = 80;
        public int MinimalHeight = 25;
        public int Border = 2;

        private bool started = false;
        private int currentEmoticonBaseWidth = 0;
        private int currentWidth = 0;
        private int currentHeight = 0;
        private MainForm parentForm = null;
        public ColorScheme colorScheme = new ColorScheme();

        public Predicate<Emoticon> Condition { get; internal set; }

        public EmoticonLayer(MainForm parrent)
        {
            parentForm = parrent;
            initElement();
        }

        public EmoticonLayer()
        {
            parentForm = null;
            initElement();
        }

        private void initElement()
        {
            Resize += new EventHandler(this.resizeHandler);
            BackColor = colorScheme.colorEmoticonLayerBG;
        }

        private void resizeHandler(object sender, EventArgs e)
        {
            if (Visible == true && needResize())
            {
                currentHeight = ClientSize.Height;
                currentWidth = ClientSize.Width;
                UpdateElement();
            }
        }

        private bool needResize()
        {
            if (currentHeight == Height && currentWidth == Width)
            {
                return false;
            }
            return true;
        }

        private void calculateSizes()
        {
            try
            {
                ColumnCount = ClientSize.Width / (MinimalWidth);
                if (ColumnCount == 0)
                {
                    ColumnCount = 1;
                }
                currentEmoticonBaseWidth = ClientSize.Width / ColumnCount - 2 * Border;
                
                if (currentEmoticonBaseWidth <= 0)
                {
                    currentEmoticonBaseWidth = MinimalWidth;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void setColumStyles()
        {
            for (int i = 0; i < ColumnCount; i++)
            {
                ColumnStyles.Add(new ColumnStyle(SizeType.Percent, (float)(1.0 / ColumnCount)));
            }
        }

        public void Clear()
        {
            clearTableLayout();
            emoticons = new List<Emoticon>();
        }

        private void clearTableLayout()
        {

            Controls.Clear();
            ColumnStyles.Clear();
            RowStyles.Clear();
        }

        public void AddEmoticons(List<Emoticon> newEmoticons)
        {
            foreach (Emoticon e in newEmoticons)
            {
                 AddEmoticon(e);
            }
        }
        public void SetEmoticons(List<Emoticon> newEmoticons)
        {
            emoticons = newEmoticons;
        }

        public void AddEmoticon(Emoticon newEmoticons)
        {
            if (!emoticons.Any(f => (f.Id == newEmoticons.Id)||(f.Text == newEmoticons.Text)))
            {
                emoticons.Add(newEmoticons);
            }
        }

        public void Start()
        {
            started = true;
            UpdateElement();
        }

        public void UpdateElement()
        {
            if (started)
            {
                calculateSizes();
                clearTableLayout();
                setColumStyles();
                placeEmoticons(false);
            }
        }

        private void placeEmoticons(bool v)
        {
            var mouseClickHandlerEmo = new MouseEventHandler(mouseClick);
            var mouseHoverHandlerEmo = new EventHandler(mouseHover);
            var mouseLeaveHandlerEmo = new EventHandler(mouseLeave);
            emoticons = new Placer().Place(emoticons, Font, currentEmoticonBaseWidth, ColumnCount);

            int x = 0;
            int y = 0;
            for (int i = 0; i < emoticons.Count; i++)
            {
                int tileWidth = emoticons[i].TileWidth(Font, currentEmoticonBaseWidth);
                Label label = new Label()
                {
                    Text = emoticons[i].Text,
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = colorScheme.colorUnselectedItem,
                    Font = Font,
                    Margin = new Padding(Border),
                    Anchor = MainForm.anchorFull,
                };
                if (parentForm != null)
                {
                    label.MouseClick += parentForm.mouseClickHandlerRightClickGoTray;
                }
                label.MouseClick += mouseClickHandlerEmo;
                label.MouseHover += mouseHoverHandlerEmo;
                label.MouseLeave += mouseLeaveHandlerEmo;

                if (tileWidth + x > ColumnCount)
                {
                    y++;
                    x = 0;
                    //TODO AddRange after fix bug with additional colum
                    RowStyles.Add(new RowStyle(SizeType.Absolute, MinimalHeight + Border));
                }
                SetColumnSpan(label, tileWidth);
                Controls.Add(label, x, y);
                x += tileWidth;
            }

            /* If we remove it we broke last row emoticons */
            RowStyles.Add(new RowStyle(SizeType.Absolute, MinimalHeight + Border));
            Controls.Add(new Label() { Text = "" }, 0, y+1);
        }

        private void mouseClick(object sender, MouseEventArgs e)
        {
            if (parentForm == null)
            {
                return;
            }
            parentForm.toTray();
            if (e.Button == MouseButtons.Left)
            {
                StringSender.Send(((Label)sender).Text);
            }
        }
        private void mouseLeave(object sender, EventArgs e)
        {
            Label current = (Label)sender;
            current.BackColor = colorScheme.colorUnselectedItem;
        }

        private void mouseHover(object sender, EventArgs e)
        {
            Label current = (Label)sender;
            current.BackColor = colorScheme.colorSelectedItem;
        }
    }
}
