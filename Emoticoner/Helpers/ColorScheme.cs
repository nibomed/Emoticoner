using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emoticoner.Helpers
{
    public class ColorScheme
    {
        // TODO: Maybe use Properties.Seting.setings
        public Color colorSectionBG = Color.FromArgb(120, 200, 240);
        public Color colorSelectedItem = Color.FromArgb(199, 237, 252);
        public Color colorUnselectedItem = Color.FromArgb(229, 247, 253);
        public Color colorEmoticonLayerBG = Color.FromArgb(245, 252, 254);
        public Color colorButton = Color.FromArgb(199, 237, 252);
        public Color colorMainBG = Color.FromArgb(245, 252, 254);
        public Color colorWarning = Color.FromArgb(230, 190, 210);

        static public int id = 0;
        public ColorScheme()
        {
            _ColorScheme(id);
        }

        public ColorScheme(int v)
        {
            id = v;
            _ColorScheme(id);
        }

        private void _ColorScheme(int v)
        {
            if (v == 0)
            {
                colorSectionBG = Color.FromArgb(120, 200, 240);
                colorSelectedItem = Color.FromArgb(199, 237, 252);
                colorUnselectedItem = Color.FromArgb(229, 247, 253);
                colorEmoticonLayerBG = Color.FromArgb(245, 252, 254);
                colorButton = Color.FromArgb(199, 237, 252);
                colorMainBG = Color.FromArgb(245, 252, 254);
                colorWarning = Color.FromArgb(230, 190, 210);
            }
            if (v == 1)
            {
                colorSectionBG = Color.FromArgb(255, 229, 180);
                colorSelectedItem = Color.FromArgb(255, 217, 145);
                colorUnselectedItem = Color.FromArgb(250, 204, 195);
                colorEmoticonLayerBG = Color.FromArgb(251, 225, 228);
                colorButton = Color.FromArgb(250, 204, 195);
                colorMainBG = Color.FromArgb(254, 252, 240);
                colorWarning = Color.FromArgb(250, 90, 90);
            }
        }
    }
}
