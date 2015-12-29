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
        private Settings settings;
        /* remove this, use signals*/
        private List<Action> subscribed = new List<Action>();

        public SettingsForm(Settings s)
        {
            settings = s;
            InitializeComponent();
            // FormBorderStyle = FormBorderStyle.None;
            TopMost = true;
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
            settings.ShortCutMod = h_mode;
            settings.ShortCutKey = char.Parse(h_key);
            
            if (radioButtonTheme1.Checked)
            {
                settings.Theme = 0;
            }
            else
            {
                settings.Theme = 1;
            }

            if (radioButtonMethod1.Checked)
            {
                settings.Method = SendMethod.SendKeys;
            }
            else
            {
                settings.Method = SendMethod.Clipboard;
            }
            settings.Save();
            //           MessageBox.Show("Restart app for apply changes");
            foreach (Action a in subscribed)
            {
                a();
            }
            //form.ApplySettings();
            Close();
        }

        private void SettingsForm_VisibleChanged(object sender, EventArgs e)
        {
            int h_mode = settings.ShortCutMod;
            char h_key = settings.ShortCutKey;

            checkBoxAlt.Checked = ((h_mode & (int)ModifierKeysEnum.Alt) > 0);
            checkBoxCtrl.Checked = ((h_mode & (int)ModifierKeysEnum.Control) > 0);
            checkBoxWin.Checked = ((h_mode & (int)ModifierKeysEnum.Win) > 0);
            listBoxKey.SelectedIndex = listBoxKey.Items.IndexOf(h_key.ToString());

            if (settings.Theme == 1)
            {
                radioButtonTheme2.Checked = true;
            }
            else
            {
                radioButtonTheme1.Checked = true;
            }

            if (settings.Method == SendMethod.SendKeys)
            {
                radioButtonMethod1.Checked = true;
            }
            else
            {
                radioButtonMethod2.Checked = true;
            }
        }
        internal void Subscribe(Action settingsClosedHandler)
        {
            subscribed.Add(settingsClosedHandler);
        }
    }
}
