using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Xml;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        System.IO.StreamWriter file;
        string dir;
        string dircss;
        public Form1()
        {

            InitializeComponent();
            new Form2().ShowDialog();
            textBox1.ScrollBars = ScrollBars.Both;
            textBox1.WordWrap = false;
            textBox2.ScrollBars = ScrollBars.Both;
            textBox2.WordWrap = false;
            pictureBox4.Cursor = Cursors.Hand;
            pictureBox5.Cursor = Cursors.Hand;
            pictureBox3.Cursor = Cursors.Hand;

        }




        /// <summary>
        /// if an old file is opened, the program loads the content and write them into textboxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            if (!System.IO.Directory.Exists(@"C:\htmlcsseditor"))
            {
                System.IO.Directory.CreateDirectory(@"C:\htmlcsseditor");
            }
            this.dir = Form2.dir;
            this.dircss = Form2.dircss;
             if (Form2.fileopen&&dir.Contains(@"C:\htmlcsseditor"))
            {
                textBox1.Text = "";
                textBox1.Text = File.ReadAllText(dir.Replace(".html",".txt"));
                textBox2.Text = File.ReadAllText(dircss);
            }
             else if (Form2.fileopen && !dir.Contains(@"C:\htmlcsseditor"))
            {
                textBox1.Text = File.ReadAllText(dir);
                try
                {
                    textBox2.Text = File.ReadAllText(dircss);
                }
                catch
                {
                    textBox2.Enabled = false;
                }
            }
        }






        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            HTMLchanged();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            CSSchanged();
        }




        /// <summary>
        /// it will be created a .txt file because the program doesn't have to write <html></html> and <link> tags when a file is loaded
        /// also this won't delete html and css files and they can be found in "C:\htmlcsseditor\NameOfTheProject"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (dir.Contains(@"C:\htmlcsseditor"))
            {
                string rec = dir.Replace(".html", ".txt");
                using (System.IO.File.Create(rec)) { };
                File.WriteAllText(rec, textBox1.Text);
            }
            pictureBox4.BackColor = Color.Blue;
        }





        /// <summary>
        /// if the user wants to quit without saving the html and css files will be removed 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (pictureBox4.BackColor != Color.Blue)
            {
                if (MessageBox.Show("Do you want to exit ? All unsaved progress will be lost", "htmlcsseditor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
            
        }






        /// <summary>
        /// try to open a bigger browser
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", dir);
            }
            catch { }
        }



        #region htmlcsschangedfunctions
        /// <summary>
        /// rewrite the html and css file while the textbox text is changed.
        /// every time the html textbox text is modified the program needs to add the tags <html></html> and the <link>
        /// </summary>
        private void HTMLchanged()
        {
            System.IO.File.WriteAllText(dir, string.Empty);
            file = new System.IO.StreamWriter(dir);
            if (dir.Contains(@"C:\htmlcsseditor"))
            {
                file.WriteLine("<html><link href=\"" + dircss + "\" rel=\"stylesheet\" type=\"text/css\">" + textBox1.Text + "</html>");
            }
            else if (!dir.Contains(@"C:\htmlcsseditor"))
            {
                file.WriteLine(textBox1.Text );
            }
            file.Close();
            webBrowser1.Navigate(dir);
            pictureBox4.BackColor = Color.Transparent;
        }
        /// <summary>
        /// when the css textbox text is changed the program doesn't need to add the html tags because the html file will be the same
        /// </summary>
        private void CSSchanged()
        {
            System.IO.File.WriteAllText(dircss, string.Empty);
            file = new System.IO.StreamWriter(dircss);
            file.WriteLine(textBox2.Text);
            file.Close();
            webBrowser1.Navigate(dir);
            pictureBox4.BackColor = Color.Transparent;
        }
        #endregion

    
      


    }
}
