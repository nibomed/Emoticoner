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

        private int currentWidth = 0;
        private MainForm parentForm = null;
        public ColorScheme colorScheme = new ColorScheme();

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
            BackColor = colorScheme.color4;
        }

        private void resizeHandler(object sender, EventArgs e)
        {
            Init();
            UpdateElement();
        }

        public void Init()
        {
            try
            {
                ColumnCount = ClientSize.Width / (MinimalWidth);
                currentWidth = ClientSize.Width / ColumnCount - 2 * Border;
                if (currentWidth <= 0)
                {
                    throw (new Exception("EmoticonLayer: Wrong width of cell"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
            Control c;
            c = GetNextControl(this, true);
            while (c != null)
            {
                Controls.Remove(c);
                c = GetNextControl(this, true);
            }
        }

        public void AddEmoticons(List<Emoticon> newEmoticons)
        {
            foreach (Emoticon e in newEmoticons)
            {
                 AddEmoticon(e);
            }
        }

        public void AddEmoticon(Emoticon newEmoticons)
        {
            if (!emoticons.Any(f => (f.id == newEmoticons.id)||(f.text == newEmoticons.text)))
            {
                emoticons.Add(newEmoticons);
            }
        }

        public void UpdateElement()
        {
            var mouseClickHandlerEmo = new MouseEventHandler(mouseClick);
            var mouseHoverHandlerEmo = new EventHandler(mouseHover);
            var mouseLeaveHandlerEmo = new EventHandler(mouseLeave);

            clearTableLayout();
            emoticons = new Placer().Place(emoticons, Font, currentWidth, ColumnCount);

            int x = 0;
            int y = 0;
            for (int i = 0; i < emoticons.Count; i++)
            {
                int tileWidth = emoticons[i].TileWidth(Font, currentWidth);
                Label label = new Label()
                {
                    Text = emoticons[i].text,
                    ClientSize = new Size((currentWidth + Border) * tileWidth, MinimalHeight),
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = colorScheme.color3,
                    Font = Font,
                    Margin = new Padding(Border)
                };
                if (parentForm != null)
                {
                    label.MouseClick += parentForm.mouseClickHandlerRightClickGoTray;
                }
                label.MouseClick += mouseClickHandlerEmo;
                // formMoveHook.SetupHandlers(label);
                label.MouseHover += mouseHoverHandlerEmo;
                label.MouseLeave += mouseLeaveHandlerEmo;

                if (tileWidth + x > ColumnCount)
                {
                    y++;
                    x = 0;
                    RowStyles.Add(new RowStyle(SizeType.Absolute, MinimalHeight + Border));
                }
                SetColumnSpan(label, tileWidth);
                Controls.Add(label, x, y);
                x += tileWidth;
            }
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
            current.BackColor = colorScheme.color3;
        }

        private void mouseHover(object sender, EventArgs e)
        {
            Label current = (Label)sender;
            current.BackColor = colorScheme.color2;
        }
    }
}
