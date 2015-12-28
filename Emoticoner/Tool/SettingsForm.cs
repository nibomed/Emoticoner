using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emoticoner.Helpers;
using Emoticoner.Hooks;

namespace Emoticoner.Tool
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
           // FormBorderStyle = FormBorderStyle.None;
            TopMost = true;
        }

        public static void SetupTheme(int v)
        {
            Reg.Write("Theme", v.ToString());
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            int h_mode = 0;
            if (checkBoxAlt.Checked) h_mode += (int)ModifierKeysEnum.Alt;
            if (checkBoxCtrl.Checked) h_mode += (int)ModifierKeysEnum.Control;
            if (checkBoxWin.Checked) h_mode += (int)ModifierKeysEnum.Win;
            if (h_mode == 0)
            {
                MessageBox.Show("You must pick at least one shortcut modifier!");
                return;
            }

            string h_key = listBoxKey.SelectedItem.ToString();
            Reg.Write("HotKeyMod", h_mode.ToString());
            Reg.Write("HotKeyKey", h_key);
            if (radioButtonTheme1.Checked)
            {
                SetupTheme(0);
            }
            else
            {
                SetupTheme(1);
            }

            MessageBox.Show("Restart app for apply changes");
            Close();
        }

        private void SettingsForm_VisibleChanged(object sender, EventArgs e)
        {
            int h_mode = int.Parse(Reg.Read("HotKeyMod"));
            char h_key = char.Parse(Reg.Read("HotKeyKey"));
            checkBoxAlt.Checked = ((h_mode & (int)ModifierKeysEnum.Alt) > 0);
            checkBoxCtrl.Checked = ((h_mode & (int)ModifierKeysEnum.Control) > 0);
            checkBoxWin.Checked = ((h_mode & (int)ModifierKeysEnum.Win) > 0);
            listBoxKey.SelectedIndex = listBoxKey.Items.IndexOf(h_key.ToString());

            int theme = int.Parse(Reg.Read("Theme"));
            if (theme == 1)
            {
                radioButtonTheme2.Checked = true;
            }
            else
            {
                radioButtonTheme1.Checked = true;
            }
        }
    }
}
