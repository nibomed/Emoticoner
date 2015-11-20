using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Emoticoner.Emoticons
{
    public partial class Emoticon
    {
        public string text { get; set; }
        public int id  { get; set; }
        public List<Tag> tags { get; set; }
        public static Emoticon None = new Emoticon() { text = "NaN", id = -1 };

        public Size RenderSize(Font font)
        {
            Size result = TextRenderer.MeasureText(text, font);

            return result;
        }

        public Emoticon()
        {
            tags = new List<Tag>();
        }

        public int TileWidth(Font font, int width)
        {
            int renderWidth = TextRenderer.MeasureText(text, font).Width;
            int tileWidth = (renderWidth / width) + ((renderWidth % width) > 0 ? 1 : 0);
            if (tileWidth == 0)
            {
                tileWidth = 1;
            }

            return tileWidth;
        }
        
        internal bool HaveTag(Tag tag)
        {
            if (tags.FindIndex(t => t.Text == tag.Text) >= 0)
            {
                return true;
            }
            return false;
        }
    }
}