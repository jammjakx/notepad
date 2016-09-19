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
        string FilenameWithPath = "";

        public Form1()
        {
            InitializeComponent();
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
        }

        private void TitleAsterix()

        {
            string Asterix = this.Text;

            string check_string = "*";

            bool b = Asterix.Contains(check_string);

            if (!b)
            {
                this.Text = Asterix + "*";
            }


        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtMain.Clear();

            this.FilenameWithPath = "";

            SetTitle();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Shows the openFileDialog
            openFileDialog1.ShowDialog();
            //Reads the text file
            System.IO.StreamReader OpenFile = new System.IO.StreamReader(openFileDialog1.FileName);
            //Displays the text file in the textBox
            txtMain.Text = OpenFile.ReadToEnd();
            //Closes the proccess
            OpenFile.Close();

            this.FilenameWithPath = openFileDialog1.FileName;

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
            SetTitle();
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
            //sluit applicatie
            Application.Exit();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtMain.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtMain.Undo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtMain.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtMain.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtMain.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtMain.SelectAll();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void txtmain_keydown(object sender, KeyEventArgs e)
        {
            TitleAsterix();
        }
    }
}
