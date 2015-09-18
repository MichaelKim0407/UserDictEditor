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
    partial class Page : UserControl
    {
        public Page()
        {
            InitializeComponent();
            button1.Left = (wordList1.Right + wordList2.Left) / 2 - button1.Width / 2;
            button1.Top = Height / 2 - 25;
            button2.Left = (wordList1.Right + wordList2.Left) / 2 - button2.Width / 2;
            button2.Top = Height / 2 + 25;
        }

        public void Clear()
        {
            wordList1.Clear();
            wordList2.Clear();
        }

        public void AddWord(WordInfo word)
        {
            wordList1.Add(word);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            wordList2.Add(wordList1.SelectedItem, true);
            wordList1.RemoveSelected();
            OnUpdateWords(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            wordList1.Add(wordList2.SelectedItem, true);
            wordList2.RemoveSelected();
            OnUpdateWords(sender, e);
        }

        private void wordList1_SelectItem(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void wordList1_DeselectItem(object sender, EventArgs e)
        {
            button1.Enabled = false;
        }

        private void wordList2_SelectItem(object sender, EventArgs e)
        {
            button2.Enabled = true;
        }

        private void wordList2_DeselectItem(object sender, EventArgs e)
        {
            button2.Enabled = false;
        }

        public bool Changed { get { return !wordList2.Empty; } }
        public IEnumerable<WordInfo> Words { get { return wordList1.Words; } }

        public event EventHandler UpdateWords;
        private void OnUpdateWords(object sender, EventArgs e)
        {
            if (UpdateWords != null)
                UpdateWords(sender, e);
        }
    }
}
