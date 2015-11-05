using Emoticoner.Emoticons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Emoticoner.Tool
{
    public partial class EmoticonManager : Form
    {
        public EmoticonDatabase database { set; get; }

        private List<string> tags = new List<string>();

        public EmoticonManager()
        {
            InitializeComponent();
            TopMost = true;
            setupTags();
        }

        

        private void setupTags()
        {
            tags = database.GetTags();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.UserClosing)
            {
                Visible = false;
                e.Cancel = true;
            }
        }

    }
}
