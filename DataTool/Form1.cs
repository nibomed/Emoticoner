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
        bool newEmoticon = true;
        int currentId = 0;
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
            textBoxTags.ScrollBars = ScrollBars.Vertical;
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
            setupComboBox();
            updateAll();
        }

        private void setupComboBox()
        {
            List<Emoticon> emoList = emoticonDatabase.GetAll(p => p.id != -100);
            for (int i = 0; i < emoList.Count; i++)
            {
                comboBoxEmoticon.Items.Add(emoList[i].text);
            }
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
            String text = comboBoxEmoticon.Text;
            if (text != "")
            {
                Emoticon emo = new Emoticon() {
                    text = text,
                    id = currentId,
                    tags = textBoxTags.Lines.ToList()
                };
                emoticonDatabase.Merge(emo);

                if (!newEmoticon)
                {
                    labelInfo.Text = comboBoxEmoticon.Text + " merged to DB";
                }
                else
                {
                    labelInfo.Text = comboBoxEmoticon.Text + " added to DB";
                    comboBoxEmoticon.Items.Add(comboBoxEmoticon.Text);
                }
                comboBoxEmoticon.Text = "";
            }
            else
            {
                labelInfo.Text = "Input something before add";
            }
        }

        private void layerEmoticonTextChangedHandler(object sender, EventArgs e)
        {
            updateAll();
        }

        private void updateAll()
        {
            int oldId = currentId;
            updateExample();
            updateId();
            if (currentId != oldId)
            {
                updateTags();
            }
        }

        private void updateTags()
        {
            textBoxTags.Text = "";
            if (newEmoticon)
            {
                return;
            }
            Emoticon emo = emoticonDatabase.GetByText(comboBoxEmoticon.Text);
            if (emo.tags != null)
            {
                for (int i = 0; i < emo.tags.Count; i++)
                {
                    textBoxTags.Text += emo.tags[i] + "\r\n";
                }
            }
        }

        private void updateId()
        {
            Emoticon emo = emoticonDatabase.GetByText(comboBoxEmoticon.Text);
            LabelId.Text = "id: ";
            if (emo == Emoticon.None)
            {
                currentId = emoticonDatabase.GetEmptyIndex();
                LabelId.Text += "[new] ";
                newEmoticon = true;
            }
            else
            {
                currentId = emo.id;
                newEmoticon = false;
            }
            LabelId.Text += currentId.ToString();
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

        /* Default shortcut hooks */
        private void textBoxTagsKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Control & e.KeyCode == Keys.A)
            {
                textBoxTags.SelectAll();
            }
            else if (e.Control & e.KeyCode == Keys.Back)
            {
                SendKeys.SendWait("^+{LEFT}{BACKSPACE}");
            }
        }
    }
}
