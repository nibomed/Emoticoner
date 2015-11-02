using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Emoticoner.Helpers;
using System.Windows.Forms;

namespace Emoticoner.Emoticons
{
    public class EmoticonDatabase
    {
        // TODO optimize all parts
        private List<Emoticon> data = new List<Emoticon>();
        public void Load(string file)
        {
            try
            {
                data = Serializer.DeSerializeObject<List<Emoticon>>(file);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nFalls to empty set of data (T_T)");
                data = new List<Emoticon>();
            }
        }

        public void Save(string file)
        {
            try
            {
                Serializer.SerializeObject(data, file);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nFalls to empty set of data");
                data = new List<Emoticon>();
            }
        }

        public Emoticon GetById(int id)
        {
            if (Have(f => f.id == id))
            {
                return data.Find(f => f.id == id);
            }

            return Emoticon.None;
        }

        public List<Emoticon> GetAll(Predicate<Emoticon> p)
        {
            return data.FindAll(p);
        }

        public Emoticon GetByText(string text)
        {
            if (Have(f => f.text == text))
            {
                return data.Find(f => f.text == text);
            }

            return Emoticon.None;
        }

        public int Length()
        {
            return data.Count;
        }

        public int GetEmptyIndex()
        {
            int res = 0;
            while (GetById(res) != Emoticon.None)
            {
                res++;
            }

            return res;
        }

        public bool Add(Emoticon emo)
        {
            Emoticon inDatabase;
            inDatabase = GetByText(emo.text);
            if (inDatabase == Emoticon.None)
            {
                data.Add(emo);
                return true;
            }

            return false;
        }

        public void Merge(Emoticon emo)
        {
            if (Add(emo))
            {
                return;
            }
            Emoticon inDatabase;
            inDatabase = GetByText(emo.text);
            if (inDatabase == Emoticon.None)
            {
                throw new Exception("EmoticonDatabase say 'You can't be here'");
            }

            if (emo.tags != null)
            {
                inDatabase.tags.Concat(emo.tags);
                inDatabase.tags = inDatabase.tags.Distinct().ToList();
            }
        }

        public bool Have(Predicate<Emoticon> p)
        {
            return (data.FindIndex(p) > -1);
        }
    }
}
