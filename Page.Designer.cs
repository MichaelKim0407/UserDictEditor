namespace UserDictEditor
{
    partial class Page
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.wordList2 = new UserDictEditor.WordList();
            this.wordList1 = new UserDictEditor.WordList();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(465, 342);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Remove ->";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(465, 394);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "<- Add";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // wordList2
            // 
            this.wordList2.Dock = System.Windows.Forms.DockStyle.Right;
            this.wordList2.Location = new System.Drawing.Point(594, 0);
            this.wordList2.Name = "wordList2";
            this.wordList2.Size = new System.Drawing.Size(400, 673);
            this.wordList2.TabIndex = 1;
            this.wordList2.SelectItem += new System.EventHandler(this.wordList2_SelectItem);
            this.wordList2.DeselectItem += new System.EventHandler(this.wordList2_DeselectItem);
            // 
            // wordList1
            // 
            this.wordList1.Dock = System.Windows.Forms.DockStyle.Left;
            this.wordList1.Location = new System.Drawing.Point(0, 0);
            this.wordList1.Name = "wordList1";
            this.wordList1.Size = new System.Drawing.Size(400, 673);
            this.wordList1.TabIndex = 0;
            this.wordList1.SelectItem += new System.EventHandler(this.wordList1_SelectItem);
            this.wordList1.DeselectItem += new System.EventHandler(this.wordList1_DeselectItem);
            // 
            // Page
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.wordList2);
            this.Controls.Add(this.wordList1);
            this.Name = "Page";
            this.Size = new System.Drawing.Size(994, 673);
            this.ResumeLayout(false);

        }

        #endregion

        private WordList wordList1;
        private WordList wordList2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}
