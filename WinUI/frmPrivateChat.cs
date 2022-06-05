using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataObjects;
using Business;

namespace WinUI
{
    public partial class frmPrivateChat : Form
    {
        public frmPrivateChat()
        {
            InitializeComponent();
        }

        doMember ben = null;
        doMember oteki = null;

        private void frmPrivateChat_Load(object sender, EventArgs e)
        {
            doMember[] chatciler = this.Tag as doMember[];
            ben = chatciler[0];
            oteki = chatciler[1];
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            rtbMesajlar.Clear();

            List<doMessage> mesajlar = new bsMessage().GetPrivateMessagesBetween(ben.Id.Value, oteki.Id.Value);

            foreach (doMessage mesaj in mesajlar)
            {
                rtbMesajlar.Text += mesaj.FromName + " : " + mesaj.Body + Environment.NewLine;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new bsMessage().InsertMessage(oteki.Id, ben.Id.Value, txtMesaj.Text);
        }
    }
}
