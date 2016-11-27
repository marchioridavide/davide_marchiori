using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        private bool _altF4Pressed;
        
        public static string pathhtml;
        public bool cssexist = false;
        public static string pathcss;
        public static string dir;
        public static string dircss;
        public static bool fileopen = false;
        public Form2()
        {
           
            InitializeComponent();
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox2.Cursor = Cursors.Hand;
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!System.IO.Directory.Exists(@"C:\htmlcsseditor"))
            {
                System.IO.Directory.CreateDirectory(@"C:\htmlcsseditor");
            }
            if (!System.IO.Directory.Exists(@"C:\htmlcsseditor\"+textBox3.Text))
            {
                System.IO.Directory.CreateDirectory(@"C:\htmlcsseditor\" + textBox3.Text);
            }
            pathcss = textBox3.Text;
            dircss = @"C:\htmlcsseditor\"+textBox3.Text+"\\" + pathcss + ".css";

            


            pathhtml = textBox3.Text;

            dir = @"C:\htmlcsseditor\" + textBox3.Text + "\\" + pathhtml + ".html";

            if (textBox3.Text != "")
            {
                using (System.IO.File.Create(dir)) { };
                this.Hide();
                using (System.IO.File.Create(dircss)) { };
                this.Hide();
            }
            else
            {
                MessageBox.Show("enter the name of the project");
            }
            

            
            
            
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            dir = openFileDialog1.FileName ;
            dircss = openFileDialog1.FileName.Replace(".html",".css") ;
            fileopen = true;
            this.Hide();
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_altF4Pressed)
            {
                if (e.CloseReason == CloseReason.UserClosing)
                    e.Cancel = true;
                _altF4Pressed = false;
            }
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            
             if (e.Alt && e.KeyCode == Keys.F4)
                  _altF4Pressed = true;

        }
        
    }
}
