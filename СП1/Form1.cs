using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using СП1.warehouseDataSetTableAdapters;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace СП1
{
    public partial class text_editor : Form
    {
        public text_editor()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Открываем файл
                string filePath = openFileDialog1.FileName;
                string fileText = System.IO.File.ReadAllText(filePath);
                richTextBox1.Text = fileText;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog1.FileName;
                System.IO.File.WriteAllText(filePath, richTextBox1.Text);
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0)
            {
                richTextBox1.Copy();
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void findAndReplaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
        }

        private void boldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Bold);
            }
        }

        private void italicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Italic);
            }
        }

        private void underlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Underline);
            }
        }

        private void syntaxHighlightingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SyntaxHighlighting("C#");
        }

        private void SyntaxHighlighting(string v)
        {
            throw new NotImplementedException();
        }

        private void close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string findText = "текст для поиска";
            int startIndex = richTextBox1.SelectionStart + richTextBox1.SelectionLength;
            int index = richTextBox1.Text.IndexOf(findText, startIndex, StringComparison.OrdinalIgnoreCase);
            if (index >= 0)
            {
                richTextBox1.SelectionStart = index;
                richTextBox1.SelectionLength = findText.Length;
            }
            else
            {
                MessageBox.Show("Find");
            }
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string replaceText = "текст для замены";
            int startIndex = richTextBox1.SelectionStart + richTextBox1.SelectionLength;
            int index = richTextBox1.Text.IndexOf(replaceText, startIndex, StringComparison.OrdinalIgnoreCase);
            if (index >= 0)
            {
                richTextBox1.SelectionStart = index;
                richTextBox1.SelectedText = replaceText;
            }
            else
            {
                MessageBox.Show("Replace");
            }
        }


    }
}
   
