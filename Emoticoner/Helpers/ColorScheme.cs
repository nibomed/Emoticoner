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
#if some
        public Color colorSectionBG = Color.FromArgb(120, 200, 240);
        public Color colorSelectedItem = Color.FromArgb(199, 237, 252);
        public Color colorUnselectedItem = Color.FromArgb(229, 247, 253);
        public Color colorEmoticonLayerBG = Color.FromArgb(245, 252, 254);
        public Color colorButton = Color.FromArgb(199, 237, 252);
        public Color colorMainBG = Color.FromArgb(245, 252, 254);
        public Color colorWarning = Color.FromArgb(230, 190, 210);
#else
        public Color colorSectionBG = Color.FromArgb(255, 229, 180);
        public Color colorSelectedItem = Color.FromArgb(255, 217, 145);
        public Color colorUnselectedItem = Color.FromArgb(250, 204, 195);
        public Color colorEmoticonLayerBG = Color.FromArgb(251, 225, 228);
        public Color colorButton = Color.FromArgb(250, 204, 195);
        public Color colorMainBG = Color.FromArgb(254, 252, 240);
        public Color colorWarning = Color.FromArgb(250, 90, 90);
#endif
        public ColorScheme()
        {
        }
    }
}
