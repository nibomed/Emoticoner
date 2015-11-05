using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emoticoner.Emoticons
{
    public class Tag
    {
        public string Text {get; set;}
        public uint References { get; private set; }

        public void Ref()
        {
            References++;
        }
        public void Unref()
        {
            if (References > 0)
            {
                References--;
            }
            else
            {
                throw new Exception("Tag [" + Text + "] Unreference when zero References.");
            }
        }

    }
}
