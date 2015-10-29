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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            updateComboBox();
        }

        private void updateComboBox()
        {
            List<Emoticon> emoList = emoticonDatabase.GetAll(p => p.id != -100);
            for (int i = 0; i < emoList.Count; i++)
            {
                comboBoxEmoticon.Items.Add(emoList[i].text);
            }
        }

        private void updateIdInfo(int num)
        {
            LabelId.Text = "id:" + num.ToString();
        }

        private void buttonSaveClick(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
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
            addEmoticon();
        }

        private void addEmoticon()
        {
            if (comboBoxEmoticon.Text != "")
            {
                if (emoticonDatabase.Add(new Emoticon() { text = comboBoxEmoticon.Text }))
                {
                    labelInfo.Text = comboBoxEmoticon.Text + " succesfull added to DB";
                    comboBoxEmoticon.Text = "";
                }
                else
                {
                    labelInfo.Text = comboBoxEmoticon.Text + " FAIL to add, already exist in database";
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
            updateId();

        }

        private void updateId()
        {
            Emoticon emo = emoticonDatabase.GetByText(comboBoxEmoticon.Text);
            if (emo == Emoticon.None)
            {
                LabelId.Text = "id: " + emoticonDatabase.GetEmptyIndex().ToString() + " (new)";
            }
            else
            {
                LabelId.Text = "id: " + emo.id.ToString();
            }
        }

        private void updateExample()
        {
            emoticonLayer.Clear();
            emoticonLayer.AddEmoticon(new Emoticon() { text = comboBoxEmoticon.Text });
            emoticonLayer.UpdateElement();
        }

        private void comboBoxEmoticon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                addEmoticon();
            }
        }
    }
}
