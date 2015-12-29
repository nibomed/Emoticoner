using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emoticoner.Helpers;
using Emoticoner.Tool;

namespace Installer
{
    public partial class Form1 : Form
    {
        List<string> files = new List<string>() {
            "Emoticoner.exe",
            "Emoticons.xml",
        };

        Settings settings = new Settings();
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonLicense_Click(object sender, EventArgs e)
        {
            MessageBox.Show("No one care! (-_-`]");
        }

        private void buttonInstall_Click(object sender, EventArgs e)
        {
            string path = textBoxPath.Text;
            if (!Install())
            {
                return;
            }
            if (checkBoxRegister.Checked)
            {
                Register(path);
            }
            if (checkBoxShortcut.Checked)
            {
                CreateShortcut(path);
            }      
            SetupTheme();
            settings.Save();
            MessageBox.Show("Installation finished succesfull");
            Close();
        }

        private void SetupTheme()
        {
            if (radioButtonTheme1.Checked)
            {
                settings.Theme = 0;
                return;
            }
            if (radioButtonTheme2.Checked)
            {
                settings.Theme = 1;
                return;
            }
            throw new NotImplementedException();
        }

        private void CreateShortcut(string path)
        {
            string dst = textBoxPath.Text;
            dst += @"\Emoticoner";
            object shDesktop = (object)"Desktop";
            WshShell shell = new WshShell();
            string shortcutAddress = (string)shell.SpecialFolders.Item(ref shDesktop) + @"\Emoticoner.lnk";
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddress);
            shortcut.WorkingDirectory = dst;
            shortcut.Description = "Emoticoner desctop shortcut";
            //shortcut.Hotkey = "Ctrl+Shift+N";
            shortcut.TargetPath = dst + @"\Emoticoner.exe";
            shortcut.Save();
        }

        private void Register(string path)
        {
            Reg.Write("DisplayName", "Emoticoner");
            Reg.Write("UninstallString", "path_to_deinstaller");
            Reg.Write("Path", textBoxPath.Text + @"\Emoticoner");
        }

        private bool Install()
        {
            string dst = textBoxPath.Text;
            dst += @"\Emoticoner";
            try
            {
                string cur = Directory.GetCurrentDirectory().ToString();
                if (!Directory.Exists(dst)) {
                    Directory.CreateDirectory(dst);
                }
                System.IO.File.Copy(cur + @"\data\" + "Emoticoner.exe", dst + @"\" + "Emoticoner.exe", true);

                string doc = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Emoticoner";
                if (!Directory.Exists(doc))
                {
                    Directory.CreateDirectory(doc);
                }
                System.IO.File.Copy(cur + @"\data\" + "Emoticons.xml", doc + @"\" + "Emoticons.xml", true);

               /* Reg.Write("HotKeyMod", "1");
                Reg.Write("HotKeyKey", "e");*/
            }
            catch (Exception e){
                MessageBox.Show(e.Message);
                return false;
            }
            return true;
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}

