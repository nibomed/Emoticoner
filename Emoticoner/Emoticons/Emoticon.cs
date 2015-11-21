using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Emoticoner.Emoticons
{
    public partial class Emoticon
    {
        public string Text { get; set; }
        public int Id  { get; set; }
        public List<Tag> Tags { get; set; }
        public static Emoticon None = new Emoticon() { Text = "NaN", Id = -1 };

        public Size RenderSize(Font font)
        {
            Size result = TextRenderer.MeasureText(Text, font);

            return result;
        }

        public Emoticon()
        {
            Tags = new List<Tag>();
        }

        public int TileWidth(Font font, int width)
        {
            int renderWidth = TextRenderer.MeasureText(Text, font).Width;
            int tileWidth = (renderWidth / width) + ((renderWidth % width) > 0 ? 1 : 0);
            if (tileWidth == 0)
            {
                tileWidth = 1;
            }

            return tileWidth;
        }
        
        internal bool HaveTag(Tag tag)
        {
            if (Tags.FindIndex(t => t.Text == tag.Text) >= 0)
            {
                return true;
            }
            return false;
        }
    }
}