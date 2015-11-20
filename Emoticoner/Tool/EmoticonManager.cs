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
        private List<bool> isSelected;
        private List<bool> isSelectedLock;
        private bool isTagLocked = false;

        private Color colorSelectedTags;
        private Color colorUnselectedTags;

        private ColorScheme colorScheme = new ColorScheme();

        private int id;
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

            colorSelectedTags = colorScheme.colorSelectedItem;
            colorUnselectedTags = colorScheme.colorEmoticonLayerBG;
            listViewTags.BackColor = colorScheme.colorEmoticonLayerBG;

            buttonAddTag.BackColor = colorScheme.colorButton;
            buttonApply.BackColor = colorScheme.colorButton;
            buttonLockTag.BackColor = colorScheme.colorButton;
            buttonDeleteEmoticon.BackColor = colorScheme.colorWarning;
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
            isSelected = new List<bool>();
            isSelectedLock = new List<bool>();
            foreach (Tag tag in Tags)
            {
                registerTag(tag);
            }
        }

        private void registerTag(Tag tag)
        {
            string sufix = "                                     ";
            listViewTags.Items.Add(tag.Text + sufix);
            isSelected.Add(false);
            isSelectedLock.Add(false);
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
                isSelected[i] = !isSelected[i];
            }
            redrawTags();
            textBoxEmoticonInput.Focus();
        }

        private void redrawTags()
        {
            for (int i = 0; i < listViewTags.Items.Count; i++)
            {
                if (isSelected[i])
                {
                    listViewTags.Items[i].BackColor = colorSelectedTags;
                }
                else
                {
                    listViewTags.Items[i].BackColor = colorUnselectedTags;
                }
            }
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

        private void buttonLockTagClickHandler(object sender, EventArgs e)
        {
            if (isTagLocked)
            {
                isTagLocked = false;
                buttonLockTag.BackColor = colorScheme.colorButton;
            }
            else
            {
                isTagLocked = true;
                for (int i = 0; i < isSelected.Count; i++)
                {
                    isSelectedLock[i] = isSelected[i];
                }
                buttonLockTag.BackColor = colorScheme.colorWarning;
            }
        }

        private void textBoxEmotionInputTextChangedHandler(object sender, EventArgs e)
        {
            string text = textBoxEmoticonInput.Text;

            redrawPreview();
            if (!isTagLocked)
            {
                Emoticon emoticon = database.GetEmoticon(f => f.text == text);
                id = emoticon.id;
                for (int i = 0; i < Tags.Count; i++)
                {
                    if (emoticon.HaveTag(Tags[i]))
                    {
                        isSelected[i] = true;
                    }
                    else
                    {
                        isSelected[i] = false;
                    }
                }
                redrawTags();
            }
        }

        private void redrawPreview()
        {
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
                if (isSelected[i])
                {
                    toAdd.tags.Add(Tags[i]);
                }
            }

            database.ForceAdd(toAdd);
            database.Save("Emoticons.xml");
            resetInput();
        }

        private void buttonDeleteEmoticonClickHandler(object sender, EventArgs e)
        {
            database.ForceDelete(textBoxEmoticonInput.Text);
            database.Save("Emoticons.xml");
            resetInput();
        }

        private void resetInput()
        {
            textBoxEmoticonInput.Text = "";
            if (isTagLocked)
            {
                for (int i = 0; i < isSelected.Count; i++)
                {
                    isSelected[i] = isSelectedLock[i];
                }
            }
            else
            {
                for (int i = 0; i < isSelected.Count; i++)
                {
                    isSelected[i] = false;
                }
            }
            redrawTags();
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
