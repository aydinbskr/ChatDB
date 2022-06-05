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

namespace WinUI
{
    public partial class frmMessages : Form
    {
        public frmMessages()
        {
            InitializeComponent();
        }

        private void frmMessages_FormClosing(object sender, FormClosingEventArgs e)
        {
            new bsMember().LogOut(member);
            Application.Exit();
        }

        private void txtMesaj_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                try
                {
                    new bsMessage().InsertMessage(null, member.Id.Value, txtMesaj.Text);
                }
                catch
                {
                    Application.Exit();
                }
                txtMesaj.Text = "";

                //mesajları al
                MesajlariGetir();
            }
        }

        private void MesajlariGetir()
        {
            List<doMessage> mesajlarim = new bsMessage().GetAllMessage(null, null, null, null, null, null, DateTime.Now.Subtract(new TimeSpan(0, 5, 0)));

            rtbGenel.Text = "";
            //foreach (doMessage item in mesajlarim)
            //{
            //    rtbGenel.Text += item.FromName + " : " + item.Body + Environment.NewLine;
            //}
            for (int i = mesajlarim.Count - 1; i >= 0; i--)
            {
                doMessage item = mesajlarim[i];
                rtbGenel.Text += item.FromName + " : " + item.Body + Environment.NewLine;
            }
        }

        doMember member = null;
        List<int> privateAcilmislar = new List<int>();

        private void frmMessages_Load(object sender, EventArgs e)
        {
            member = this.Tag as doMember;
            MesajlariGetir();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MesajlariGetir();
            if (lstKullanicilar.DataSource == null)
                return;
            List<doMember> onlineKullanicilar = lstKullanicilar.DataSource as List<doMember>;
            foreach (doMember uye in onlineKullanicilar)
            {
                if (uye.Id.Value != member.Id.Value && !privateAcilmislar.Contains(uye.Id.Value))
                {
                    if (new bsMessage().GetPrivateMessagesBetween(member.Id.Value, uye.Id.Value).Count > 0)
                    {
                        frmPrivateChat f = new frmPrivateChat();
                        privateAcilmislar.Add(uye.Id.Value);
                        doMember[] chatciler = new doMember[2];
                        chatciler[0] = member;
                        chatciler[1] = uye;
                        f.Tag = chatciler;
                        f.Show();
                    }
                }
            }
        }

        private void OnlineKullanicilariGetir()
        {
            List<doMember> uyeler = new bsMember().OnlineKullanicilariGetir();

            lstKullanicilar.DataSource = uyeler;
            lstKullanicilar.DisplayMember = "Username";
        }

        private void lstKullanicilar_DoubleClick(object sender, EventArgs e)
        {
            //çünkü çift tıkladığım adam için bir private pencere açılmış oluyor
            privateAcilmislar.Add((lstKullanicilar.SelectedItem as doMember).Id.Value);

            frmPrivateChat frm = new frmPrivateChat();
            doMember[] chatciler = new doMember[2];
            chatciler[0] = member; //chat i yapan 0. eleman
            chatciler[1] = lstKullanicilar.SelectedItem as doMember; //
            //kim için private chat açıyorsak o kişiyi tag'e koymamız lazım
            frm.Tag = chatciler; // seçili adam çift tıkladığınız chat yapmak istediğiniz kişi
            frm.Show();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            OnlineKullanicilariGetir();
        }
    }
}
