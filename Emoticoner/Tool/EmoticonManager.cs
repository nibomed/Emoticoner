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
using Microsoft.VisualBasic;
using Emoticoner.Helpers;

namespace Emoticoner.Tool
{
    public partial class EmoticonManager : Form
    {
        public EmoticonDatabase database { set; get; }

        public List<Tag> Tags { set; get; }
        private List<bool> selected;

        private Color selectedTags;
        private Color unselectedTags;

        private ColorScheme colorScheme = new ColorScheme();

        private int id;
        private int prev_id;
        private EmoticonLayer historyEmoticonLayer;
        private EmoticonLayer previewEmoticonLayer;

        public EmoticonManager()
        {
            InitializeComponent();
            TopMost = true;

            listViewTags.MouseClick += listViewTagsMouseClickEventHandler;
            listViewTags.GotFocus += listViewTagsGotFocusHandler;

            BackColor = colorScheme.colorMainBG;
            tableLayoutPanelTags.BackColor = colorScheme.colorSectionBG;
            tableLayoutPanelDown.BackColor = colorScheme.colorSectionBG;
            tableLayoutPanelRoot.BackColor = colorScheme.colorMainBG;
            tableLayoutPanelLeftUp.BackColor = colorScheme.colorSectionBG;
            tableLayoutPanelLeftCenter.BackColor = colorScheme.colorSectionBG;
            tableLayoutPanelLeftBottom.BackColor = colorScheme.colorSectionBG;

            selectedTags = colorScheme.colorSelectedItem;
            unselectedTags = colorScheme.colorEmoticonLayerBG;
            listViewTags.BackColor = colorScheme.colorEmoticonLayerBG;

            buttonAddTag.BackColor = colorScheme.colorButton;
            buttonApply.BackColor = colorScheme.colorButton;
            buttonDeleteTag.BackColor = colorScheme.colorButton;
            buttonDeleteEmoticon.BackColor = colorScheme.colorWarning;
            id = prev_id = 0;
        }

        private void listViewTagsGotFocusHandler(object sender, EventArgs e)
        {
            textBoxEmoticonInput.Focus();
        }

        public void Init()
        {
            historyEmoticonLayer = new EmoticonLayer()
            {
                Anchor = MainForm.anchorFull,
                colorScheme = colorScheme,
                MinimalWidth = 80,
                MinimalHeight = 25,
                Font = MainForm.OurFont
            };
            tableLayoutPanelLeftCenter.Controls.Add(historyEmoticonLayer);

            /* Scroll magic */
            historyEmoticonLayer.HorizontalScroll.Maximum = 100;
            historyEmoticonLayer.HorizontalScroll.Visible = false;
            historyEmoticonLayer.HorizontalScroll.Enabled = false;
            historyEmoticonLayer.VerticalScroll.Maximum = 0;
            historyEmoticonLayer.VerticalScroll.Visible = false;
            historyEmoticonLayer.AutoScroll = true;
            database.Subscribe(historyEmoticonLayer, changeEmo);
            database.Subscribe(historyEmoticonLayer, addEmo);
            database.Subscribe(historyEmoticonLayer, deleteEmo);

            historyEmoticonLayer.Start();

            previewEmoticonLayer = new EmoticonLayer()
            {
                Anchor = MainForm.anchorFull,
                colorScheme = colorScheme,
                MinimalWidth = 80,
                MinimalHeight = 25,
                Font = MainForm.OurFont
            };
            tableLayoutPanelLeftBottom.Controls.Add(previewEmoticonLayer);

            previewEmoticonLayer.Start();

            setupTags();
        }

        private void changeEmo(object sender, ChangeEmoticonEventArgs obj)
        {
            historyEmoticonLayer.AddEmoticon(obj.Emoticon);
            historyEmoticonLayer.UpdateElement();
        }
        private void addEmo(object sender, AddEmoticonEventArgs obj)
        {
            historyEmoticonLayer.AddEmoticon(obj.Emoticon);
            historyEmoticonLayer.UpdateElement();
        }
        private void deleteEmo(object sender, DeleteEmoticonEventArgs obj)
        {
            historyEmoticonLayer.AddEmoticon(obj.Emoticon);
            historyEmoticonLayer.UpdateElement();
        }

        private void setupTags()
        {
            Tags = database.tags;
            Tags.OrderByDescending(t => t.References);
            selected = new List<bool>();
            foreach (Tag tag in Tags)
            {
                registerTag(tag);
            }
        }

        private void registerTag(Tag tag)
        {
            string sufix = "                                     ";
            listViewTags.Items.Add(tag.Text + sufix);
            selected.Add(false);
        }

        private void listViewTagsMouseClickEventHandler(object sender, MouseEventArgs e)
        {
            pickItems();
        }

        private void pickItems()
        {
            var idx = listViewTags.SelectedIndices;
            foreach (int i in idx)
            {
                selected[i] = !selected[i];
                if (selected[i])
                {
                    listViewTags.Items[i].BackColor = selectedTags;
                }
                else
                {
                    listViewTags.Items[i].BackColor = unselectedTags;
                }
            }
            textBoxEmoticonInput.Focus();
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

        private void buttonAddTagClickHandler(object sender, EventArgs e)
        {
            // TODO: remove Basic, style window
            string input = Interaction.InputBox("Input Tag name", "New Tag");
            if (Tags.FindIndex(t => t.Text == input) > -1)
            {
                MessageBox.Show("Tag " + input + " already exist");
                return;
            }
            Tag toAdd = new Tag() { Text = input };
            Tags.Add(toAdd);
            registerTag(toAdd);
        }

        private void buttonDeleteTagClickHandler(object sender, EventArgs e)
        {
            MessageBox.Show("Don't work now...");
        }

        private void textBoxEmotionInputTextChangedHandler(object sender, EventArgs e)
        {
            string text = textBoxEmoticonInput.Text;
            Emoticon emoticon = database.GetEmoticon(f => f.text == text);
            id = emoticon.id;
            if (emoticon != Emoticon.None || prev_id != id)
            {
                for (int i = 0; i < Tags.Count; i++)
                {
                    if (emoticon.HaveTag(Tags[i]))
                    {
                        listViewTags.Items[i].BackColor = selectedTags;
                    }
                    else
                    {
                        listViewTags.Items[i].BackColor = unselectedTags;
                    }
                }
            }
            prev_id = id;

            List<Emoticon> tmp = new List<Emoticon>() { };
            tmp.Add(new Emoticon() { text = textBoxEmoticonInput.Text });
            previewEmoticonLayer.SetEmoticons(tmp);
            previewEmoticonLayer.UpdateElement();
        }

        private void buttonApplyClickHandler(object sender, EventArgs e)
        {
            emmoticonAdd();
        }

        private void emmoticonAdd()
        {
            Emoticon toAdd = new Emoticon()
            {
                text = textBoxEmoticonInput.Text,
                id = database.GetEmptyIndex()
            };

            for (int i = 0; i < Tags.Count; i++)
            {
                if (selected[i])
                {
                    toAdd.tags.Add(Tags[i]);
                }
            }

            database.ForceAdd(toAdd);
            database.Save("Emoticons.xml");
            prev_id = -1;
            textBoxEmoticonInput.Text = "";
        }

        private void buttonDeleteEmoticonClickHandler(object sender, EventArgs e)
        {
            database.ForceDelete(textBoxEmoticonInput.Text);
            database.Save("Emoticons.xml");
            textBoxEmoticonInput.Text = "";
        }

        private void visibleChangeHandler(object sender, EventArgs e)
        {
            textBoxEmoticonInput.Focus();
        }

        private void textBoxEmoticonInputKeyPressHandler(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                emmoticonAdd();
            }
        }
    }
}
