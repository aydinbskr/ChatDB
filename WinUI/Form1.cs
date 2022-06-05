using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business;
using DataObjects;
using System.Drawing.Drawing2D;

namespace WinUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bsMember bsmem = new bsMember();
            try
            {
                doMember member = bsmem.Login(textBox1.Text, textBox2.Text);
                if (member == null)
                {
                    //yeniden denettir veya kapat
                }
                else
                {
                    frmMessages f = new frmMessages();
                    f.Tag = member;
                    f.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                //errorProvider1.SetError(textBox1, ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            this.CreateGraphics().FillRectangle(new LinearGradientBrush(this.ClientRectangle, Color.Black, Color.White, 45), this.ClientRectangle);
        }
    }
}
