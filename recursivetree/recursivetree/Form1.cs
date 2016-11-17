using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace recursivetree
{
    public partial class Form1 : Form
    {
        Pen p;
        Graphics g;
        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.Black;
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            p = new Pen(Color.Black);
            g = this.CreateGraphics();
            
        }
        

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            drawTree(700, 650, (float)numericUpDown4.Value, (int)numericUpDown1.Value, (float)numericUpDown5.Value, (float)numericUpDown2.Value, (float)numericUpDown3.Value);
        }
        private void drawTree(float x1, float y1, double theta, int depth, double dtheta, float scale, float length)
        {
           
                if (depth != 0)
                {

                    float x2 = (float)(x1 + (Math.Cos(theta * Math.PI/180.0)  *length));     //si calcolano le x e le y trasformando l'angolo in radianti
                    float y2 = (float)(y1 + (Math.Sin(theta * Math.PI/180.0)  *length));     //scale rappresenta la scala, il che serve a diminuire la lunghezza dei rami ogni man mano che la funzione viene eseguita
                                                                                                   //se scale è un valore inferiore rispetto a depth  diventa minore di 0, ciò significa che "andrà indietro"

                    p.Color = Color.FromArgb(91, 148, 239);
                    g.DrawLine(p, x1, y1, x2, y2);
                    drawTree(x2, y2, theta - dtheta, depth - 1, dtheta,scale,length*scale);             
                    drawTree(x2, y2, theta + dtheta, depth - 1, dtheta,scale, length*scale);

                }

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Invalidate();
        }

        
        private void numericUpDown2_ValueChanged_1(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            Invalidate();
        }


    }
}
