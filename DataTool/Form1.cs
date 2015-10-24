using Emoticoner.Emoticons;
using Emoticoner.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataTool
{
    public partial class Form1 : Form
    {
        EmoticonDatabase emoticonDatabase;
        EmoticonLayer emoticonLayer;
        ColorScheme colorScheme;
        public Form1()
        {
            InitializeComponent();
            emoticonDatabase = new EmoticonDatabase();
            colorScheme = new ColorScheme();
            emoticonLayer = new EmoticonLayer()
            {
                Location = new Point(0, 0),
                colorScheme = colorScheme,
                MinimalWidth = 80,
                MinimalHeight = 25,
                Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))),
                Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left)
            };
            emoticonLayer.Init();
            emoticonLayer.UpdateElement();
            tableLayoutPanel3.Controls.Add(emoticonLayer, 0, 3);
        }

        private void buttonOpenClick(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    emoticonDatabase.Load(openFileDialog1.FileName);
                    updateIdInfo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void updateIdInfo()
        {
            LabelId.Text = "id:" + emoticonDatabase.GetEmptyIndex().ToString();
        }

        private void buttonSaveClick(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    emoticonDatabase.Save(saveFileDialog1.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonAddClick(object sender, EventArgs e)
        {
            if (textBoxEmoticon.Text != "")
            {
                if (emoticonDatabase.Add(new Emoticon() { text = textBoxEmoticon.Text }))
                {
                    updateIdInfo();
                    labelInfo.Text = textBoxEmoticon.Text + " succesfull added to DB";
                    textBoxEmoticon.Text = "";
                }
                else
                {
                    labelInfo.Text = textBoxEmoticon.Text + " FAIL to add, already exist in database";
                }
            }
            else
            {
                labelInfo.Text = "Input something before add";
            }
        }

        private void layerEmoticonTextChangedHandler(object sender, EventArgs e)
        {
            updateExample();
        }

        private void updateExample()
        {
            emoticonLayer.Clear();
            emoticonLayer.AddEmoticon(new Emoticon() { text = textBoxEmoticon.Text });
            emoticonLayer.UpdateElement();
        }
    }
}
