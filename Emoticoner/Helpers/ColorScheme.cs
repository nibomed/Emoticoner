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
        public Color color1 = Color.FromArgb(0, 175, 240);
        public Color color2 = Color.FromArgb(199, 237, 252);
        public Color color3 = Color.FromArgb(229, 247, 253);
        public Color color4 = Color.FromArgb(245, 252, 254);
        public Color color5 = Color.FromArgb(255, 255, 255);

        public ColorScheme(Color c1, Color c2, Color c3, Color c4, Color c5)
        {
            color1 = c1;
            color2 = c2;
            color3 = c3;
            color4 = c4;
            color5 = c5;
        }
        public ColorScheme()
        {
        }
    }
}
