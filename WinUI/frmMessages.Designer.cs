namespace WinUI
{
    partial class frmMessages
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.rtbGenel = new System.Windows.Forms.RichTextBox();
            this.txtMesaj = new System.Windows.Forms.TextBox();
            this.lstKullanicilar = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lstKullanicilar);
            this.splitContainer1.Size = new System.Drawing.Size(539, 316);
            this.splitContainer1.SplitterDistance = 400;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.rtbGenel);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.txtMesaj);
            this.splitContainer2.Size = new System.Drawing.Size(400, 316);
            this.splitContainer2.SplitterDistance = 284;
            this.splitContainer2.TabIndex = 0;
            // 
            // rtbGenel
            // 
            this.rtbGenel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.rtbGenel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbGenel.Location = new System.Drawing.Point(0, 0);
            this.rtbGenel.Name = "rtbGenel";
            this.rtbGenel.Size = new System.Drawing.Size(400, 284);
            this.rtbGenel.TabIndex = 0;
            this.rtbGenel.Text = "";
            // 
            // txtMesaj
            // 
            this.txtMesaj.BackColor = System.Drawing.Color.SteelBlue;
            this.txtMesaj.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMesaj.Location = new System.Drawing.Point(0, 0);
            this.txtMesaj.Name = "txtMesaj";
            this.txtMesaj.Size = new System.Drawing.Size(400, 20);
            this.txtMesaj.TabIndex = 0;
            this.txtMesaj.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMesaj_KeyPress);
            // 
            // lstKullanicilar
            // 
            this.lstKullanicilar.BackColor = System.Drawing.Color.SteelBlue;
            this.lstKullanicilar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstKullanicilar.FormattingEnabled = true;
            this.lstKullanicilar.Location = new System.Drawing.Point(0, 0);
            this.lstKullanicilar.Name = "lstKullanicilar";
            this.lstKullanicilar.Size = new System.Drawing.Size(135, 316);
            this.lstKullanicilar.TabIndex = 0;
            this.lstKullanicilar.DoubleClick += new System.EventHandler(this.lstKullanicilar_DoubleClick);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 5000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // frmMessages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkKhaki;
            this.ClientSize = new System.Drawing.Size(539, 316);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmMessages";
            this.Text = "frmMessages";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMessages_FormClosing);
            this.Load += new System.EventHandler(this.frmMessages_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TextBox txtMesaj;
        private System.Windows.Forms.ListBox lstKullanicilar;
        private System.Windows.Forms.RichTextBox rtbGenel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
    }
}