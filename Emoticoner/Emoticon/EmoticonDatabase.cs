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
            if (data.Any(f => f.id == id) == false)
            {
                return Emoticon.None;
            }

            return data.Find(f => f.id == id);
        }

        public List<Emoticon> GetAll(Predicate<Emoticon> p)
        {
            return data.FindAll(p);
        }

        public Emoticon GetByText(string text)
        {
            if (data.Any(f => f.text == text) == false)
            {
                return Emoticon.None;
            }

            return data.Find(f => f.text == text);
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
                data.Add(new Emoticon() { text = emo.text, id = GetEmptyIndex() });
                return true;
            }

            return false;
        }
    }
}
