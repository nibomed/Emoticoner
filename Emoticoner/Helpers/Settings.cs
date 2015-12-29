using Emoticoner.Hooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Emoticoner.Helpers
{
    public class Settings
    {
        /* Move all general global path/register keys etc to some separate file */ 
        private static string Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Emoticoner\Settings.xml";
        /* TODO split into one class */
        public int ShortCutMod = (int)ModifierKeysEnum.Alt;
        public char ShortCutKey = 'e';
        /* make enum */
        public int Theme = 0;
        public SendMethod Method = SendMethod.SendKeys;

        public bool IsModifierConteins(int mod)
        {
            return (ShortCutMod & mod) > 0;
        }

        public bool Load(string path)
        {
            try
            {
                Settings tmp = Serializer.DeSerializeObject<Settings>(path);
                ShortCutMod = tmp.ShortCutMod;
                ShortCutKey = tmp.ShortCutKey;
                Theme = tmp.Theme;
                Method = tmp.Method;
            }
            catch
            {
                MessageBox.Show("Error occurred during load settings. Falls to default.");
                return false;
            }
            return true;
        }

        public bool Load()
        {
            try
            {
                Load(Path);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public void Save()
        {
            Save(Path);
        }

        public void Save(string path)
        {
            try
            {
                Serializer.SerializeObject(this, path);
            }
            catch
            {
                MessageBox.Show("Error occurred during save settings.");
            }
        }
    }
}
