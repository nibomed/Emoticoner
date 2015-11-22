using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Emoticoner.Helpers;
using System.Windows.Forms;

namespace Emoticoner.Emoticons
{
    public class EmoticonEventArgs : EventArgs
    {
        public EmoticonEventArgs(Emoticon emoticon)
        {
            Emoticon = emoticon;
        }

        public EmoticonEventArgs()
        {
            Emoticon = Emoticon.None;
        }

        public Emoticon Emoticon { get; set; }
    }
    public class ChangeEmoticonEventArgs : EmoticonEventArgs { }
    public class DeleteEmoticonEventArgs : EmoticonEventArgs { }
    public class AddEmoticonEventArgs : EmoticonEventArgs { }

    public class EmoticonDatabase
    {
        List<Pair<object, Action<object, ChangeEmoticonEventArgs>>> changeEmoticonEventHandlers = new List<Pair<object, Action<object, ChangeEmoticonEventArgs>>>();
        List<Pair<object, Action<object, DeleteEmoticonEventArgs>>> deleteEmoticonEventHandlers = new List<Pair<object, Action<object, DeleteEmoticonEventArgs>>>();
        List<Pair<object, Action<object, AddEmoticonEventArgs>>> addEmoticonEventHandlers = new List<Pair<object, Action<object, AddEmoticonEventArgs>>>();

        internal void Subscribe(object sender, Action<object, ChangeEmoticonEventArgs> emoticonChangedHandler2)
        {
            changeEmoticonEventHandlers.Add(new Pair<object, Action<object, ChangeEmoticonEventArgs>>(sender, emoticonChangedHandler2));
        }
        internal void Subscribe(object sender, Action<object, DeleteEmoticonEventArgs> emoticonDeleteHandler2)
        {
            deleteEmoticonEventHandlers.Add(new Pair<object, Action<object, DeleteEmoticonEventArgs>>(sender, emoticonDeleteHandler2));
        }
        internal void Subscribe(object sender, Action<object, AddEmoticonEventArgs> emoticonAddHandler2)
        {
            addEmoticonEventHandlers.Add(new Pair<object, Action<object, AddEmoticonEventArgs>>(sender, emoticonAddHandler2));
        }

        private void changeEmoticonEvent(Emoticon e)
        {
            foreach (Pair<object, Action<object, ChangeEmoticonEventArgs>> pair in changeEmoticonEventHandlers)
            {
                pair.second(pair.first, new ChangeEmoticonEventArgs() { Emoticon = e });
            }
        }

        private void deleteEmoticonEvent(Emoticon e)
        {
            foreach (Pair<object, Action<object, DeleteEmoticonEventArgs>> pair in deleteEmoticonEventHandlers)
            {
                pair.second(pair.first, new DeleteEmoticonEventArgs() { Emoticon = e });
            }
        }

        private void addEmoticonEvent(Emoticon e)
        {
            foreach (Pair<object, Action<object, AddEmoticonEventArgs>> pair in addEmoticonEventHandlers)
            {
                pair.second(pair.first, new AddEmoticonEventArgs() { Emoticon = e });
            }
        }

        public class EmoticonFileItem
        {
            public string text;
            public List<string> tags;
            public EmoticonFileItem(Emoticon emo)
            {
                text = emo.Text;
                tags = new List<string>();
                foreach (Tag t in emo.Tags)
                {
                    tags.Add(t.Text);
                }
            }
            public EmoticonFileItem()
            {
            }
        };
             
        // TODO optimize all parts
        public List<Emoticon> emoticons { get; private set; }
        public List<Tag> tags { get; private set; }
        public void Load(string file)
        {
            emoticons = new List<Emoticon>();
            tags = new List<Tag>();
            List<EmoticonFileItem> fromFile = new List<EmoticonFileItem>();

            try
            {
                fromFile = Serializer.DeSerializeObject<List<EmoticonFileItem>>(file);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nFalls to empty set of data (T_T)");
                emoticons = new List<Emoticon>();
                return;
            }

            int id = 0;
            foreach (EmoticonFileItem efi in fromFile)
            {
                Emoticon emo = new Emoticon()
                {
                    Text = efi.text,
                    Id = id++
                };
                foreach (string stag in efi.tags)
                {
                    AddTag(stag);
                    Tag tag = GetTag(stag);
                    tag.Ref();
                    emo.Tags.Add(tag);
                }
                tags.OrderBy(t=> t.References);
                emoticons.Add(emo);
            }
        }

        private Tag GetTag(string text)
        {
            int i = tags.FindIndex(t => t.Text == text);
            if (i > -1)
            {
                return tags[i];
            }
            throw new Exception("No such tag");
        }

        private void AddTag(string text)
        {
            if (tags.FindIndex(t => t.Text == text) < 0)
            {
                tags.Add(new Tag() { Text = text });
            }
        }

        internal void ForceDelete(string text)
        {
            List<Emoticon> emo = emoticons.FindAll(e => e.Text == text);
            foreach (Emoticon e in emo)
            {
                Delete(e);
            }
        }

        private void Delete(Emoticon e)
        {
            // generate event here
            emoticons.Remove(e);
            deleteEmoticonEvent(e);
        }

        public void Save(string file)
        {
            List<EmoticonFileItem> toFile = new List<EmoticonFileItem>();
            foreach (Emoticon emo in emoticons)
            {
                toFile.Add(new EmoticonFileItem(emo));
            } 
            try
            {
                Serializer.SerializeObject(toFile, file);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nFalls to empty set of data");
                emoticons = new List<Emoticon>();
            }
        }

        public Emoticon GetEmoticon(Predicate<Emoticon> p)
        {

            List<Emoticon> t = emoticons.FindAll(p);
            if (t.Count > 1)
            {
                throw (new Exception("Corrutped Database, more that one emoticon with same unique propertie in DB"));
            }
            else if (t.Count < 1)
            {
                return Emoticon.None;
            }
            else
            {
                return t[0];
            }
        }

        public List<Emoticon> GetAll(Predicate<Emoticon> p)
        {
            return emoticons.FindAll(p);
        }

        public int GetEmptyIndex()
        {
            int res = 1;
            while (GetEmoticon(e => e.Id == res) != Emoticon.None)
            {
                res++;
            }
            return res;
        }

        public bool Add(Emoticon emo)
        {
            if (ContainsEmoticon(e => e.Text == emo.Text))
            {
                return false;
            }
            
            Emoticon toAdd = new Emoticon()
            {
                Text = emo.Text,
                Id = GetEmptyIndex(),
                Tags = emo.Tags
            };
            emoticons.Add(toAdd);
            addEmoticonEvent( toAdd);
            return true;
        }

        public void Merge(Emoticon emo)
        {
            if (Add(emo))
            {
                return;
            }
            Emoticon inDatabase;
            inDatabase = GetEmoticon(e => e.Text == emo.Text);
            if (inDatabase == Emoticon.None)
            {
                throw new Exception("EmoticonDatabase say 'You can't be here'");
            }

            if (emo.Tags != null)
            {
                inDatabase.Tags.Concat(emo.Tags);
            }
        }

        public void ForceAdd(Emoticon emo)
        {
            if (Add(emo))
            {
                return;
            }

            Emoticon inDatabase = GetEmoticon(e => e.Text == emo.Text);
            inDatabase.Tags = emo.Tags;
            changeEmoticonEvent(inDatabase);
        }

        public bool ContainsEmoticon(Predicate<Emoticon> p)
        {
            return (emoticons.FindIndex(p) > -1);
        }
    }
}
