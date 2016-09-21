using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace notepad
{
    public partial class Form1 : Form
    {
        bool IsChanged = false;
        string FilenameWithPath = "";

        public Form1()
        {
            InitializeComponent();
            this.IsChanged = false;
            SetTitle();
        }

       private void Form1_Load(object sender, EventArgs e)
       {
            
        }

        private void SetTitle()
        {
            if (FilenameWithPath == null | FilenameWithPath == "")
            {
                this.Text = "Nieuw document - C# Kladblok";
            }
            else
            {
                string OnlyFilename = System.IO.Path.GetFileNameWithoutExtension(FilenameWithPath);
                this.Text = OnlyFilename + " - C# Kladblok";
            }

            // if IsChanged then add * to filename
            if (IsChanged) this.Text = this.Text + "*";
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //messagebox asking if you wish to save youre current file with yes or no buttons
            DialogResult res = MessageBox.Show("Wilt u eerst het bestand opslaan?", "Bevestiging", MessageBoxButtons.YesNo);
            txtMain.Clear();

            this.FilenameWithPath = "";

            this.IsChanged = false;
            SetTitle();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //messagebox asking if you wish to save youre current file
            DialogResult res = MessageBox.Show("Wilt u eerst het bestand opslaan?", "Bevestiging", MessageBoxButtons.YesNo);
            //Shows the openFileDialog
            openFileDialog1.ShowDialog();
            //Reads the text file
            System.IO.StreamReader OpenFile = new System.IO.StreamReader(openFileDialog1.FileName);
            //Displays the text file in the textBox
            txtMain.Text = OpenFile.ReadToEnd();
            //Closes the proccess
            OpenFile.Close();

            this.FilenameWithPath = openFileDialog1.FileName;
            //*
            this.IsChanged = false;
            SetTitle();

            txtMain.Text = System.IO.File.ReadAllText(FilenameWithPath);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Determines the text file to save to
            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(openFileDialog1.FileName);
            //Writes the text to the file
            SaveFile.WriteLine(txtMain.Text);
            //Closes the proccess
            SaveFile.Close();
            //*
            this.IsChanged = false;
            SetTitle();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Open the saveFileDialog
            saveFileDialog1.ShowDialog();
            //Determines the text file to save to
            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(saveFileDialog1.FileName);
            //Writes the text to the file
            SaveFile.WriteLine(txtMain.Text);
            //Closes the proccess
            SaveFile.Close();
            //*
            this.IsChanged = false;
            SetTitle();
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Toggle WordWrap on/off
            if (this.txtMain.WordWrap)
            {
                this.txtMain.WordWrap = false;
            }
            else
            {
                this.txtMain.WordWrap = true;
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Declare prntDoc as a new PrintDocument
            System.Drawing.Printing.PrintDocument prntDoc = new System.Drawing.Printing.PrintDocument();
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //close programm
            Application.Exit();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //undo last made change
            txtMain.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //undo last change
            txtMain.Undo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //cut selected text
            txtMain.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //copy selected text
            txtMain.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //paste cut/copied text
            txtMain.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //select all text inside the file
            txtMain.SelectAll();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void txtmain_keydown(object sender, KeyEventArgs e)
        {
            //when a change is made add the * 
            this.IsChanged = true;
            SetTitle();
        }
    }
}
