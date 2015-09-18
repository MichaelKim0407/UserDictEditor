using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserDictEditor
{
    partial class WordList : UserControl
    {
        public WordList()
        {
            InitializeComponent();
            label1.Text = string.Format(WordInfo.DisplayFormat, "Pinyin", "Word            ", "Count");
        }

        ListBox.ObjectCollection Items { get { return listBox1.Items; } }
        public int SelectedIndex
        {
            get { return listBox1.SelectedIndex; }
            set { listBox1.SelectedIndex = value; }
        }
        public WordInfo SelectedItem { get { return listBox1.SelectedItem as WordInfo; } }

        public WordInfo this[int index]
        {
            get { return Items[index] as WordInfo; }
        }

        int IndexOf(WordInfo word)
        {
            return Items.IndexOf(word);
        }

        int IndexToInsert(WordInfo word)
        {
            for (int i = 0; i < Items.Count; i++)
                if (word.Compare(this[i]) < 0)
                    return i;
            return Items.Count;
        }

        public void Clear()
        {
            Items.Clear();
        }

        public void Add(WordInfo word, bool select = false)
        {
            var i = IndexToInsert(word);
            Items.Insert(i, word);
            if (select)
                listBox1.SelectedIndex = i;
        }

        public void Remove(int index)
        {
            Items.RemoveAt(index);
        }

        public void RemoveSelected()
        {
            Remove(SelectedIndex);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedIndex != -1)
                OnSelectItem(sender, e);
            else
                OnDeselectItem(sender, e);
        }

        public event EventHandler SelectItem;
        private void OnSelectItem(object sender, EventArgs e)
        {
            if (SelectItem != null)
                SelectItem(sender, e);
        }

        public event EventHandler DeselectItem;
        private void OnDeselectItem(object sender, EventArgs e)
        {
            if (DeselectItem != null)
                DeselectItem(sender, e);
        }

        public bool Empty { get { return Items.Count == 0; } }
        public IEnumerable<WordInfo> Words { get { return Items.Cast<WordInfo>(); } }
    }
}
