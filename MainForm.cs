using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MKLibCS.Collections;

namespace UserDictEditor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        static readonly Encoding Encoding = Encoding.GetEncoding("GB2312");

        IEnumerable<WordInfo> LoadFile(string fileName)
        {
            using (StreamReader reader = new StreamReader(fileName, Encoding))
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line == "")
                        continue;
                    yield return new WordInfo(line);
                }
        }

        const string FinalFileName = "custom.dic";
        const string NewFileName = "new.dic";

        void LoadFiles()
        {
            var custom = LoadFile(FinalFileName).ToList();
            foreach (var word in LoadFile(NewFileName))
            {
                var match = custom.Find(w => w.SameWord(word));
                if (match != null)
                {
                    custom.Remove(match);
                    if (word.Count == match.Count)
                        pageUnc.AddWord(word);
                    else
                        pageInc.AddWord(word);
                }
                else
                    pageNew.AddWord(word);
            }
            foreach (var word in custom)
                pageUnc.AddWord(word);
        }

        void Reload()
        {
            pageNew.Clear();
            pageInc.Clear();
            pageUnc.Clear();
            LoadFiles();
            tabControl1.TabPages[0].Text = "New";
            tabControl1.TabPages[1].Text = "Increased";
            tabControl1.TabPages[2].Text = "Unchanged";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadFiles();
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reload();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        bool Changed { get { return pageNew.Changed || pageInc.Changed || pageUnc.Changed; } }
        IEnumerable<WordInfo> SortedWords
        {
            get
            {
                return WordInfo.Sorted(
                    CollectionsUtil.Combine(
                        pageNew.Words,
                        pageInc.Words,
                        pageUnc.Words
                        ));
            }
        }

        void SaveFile(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName, false, Encoding))
                foreach (var word in SortedWords)
                    writer.WriteLine(word.FileString);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Changed)
                return;
            SaveFile(NewFileName);
            Reload();
        }

        private void commitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile(NewFileName);
            SaveFile(FinalFileName);
            Reload();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Changed)
                return;
            e.Cancel = true;
        }

        private void pageNew_UpdateWords(object sender, EventArgs e)
        {
            tabControl1.TabPages[0].Text = "New" + (pageNew.Changed ? "*" : "");
        }

        private void pageInc_UpdateWords(object sender, EventArgs e)
        {
            tabControl1.TabPages[1].Text = "Increased" + (pageInc.Changed ? "*" : "");
        }

        private void pageUnc_UpdateWords(object sender, EventArgs e)
        {
            tabControl1.TabPages[2].Text = "Unchanged" + (pageUnc.Changed ? "*" : "");
        }
    }
}
