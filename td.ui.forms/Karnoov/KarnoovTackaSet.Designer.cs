﻿namespace td.ui.forms.Karnoov
{
    partial class KarnoovTackaSet
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
            this.lblNazivTacke = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtP_C = new System.Windows.Forms.TextBox();
            this.txtT_C = new System.Windows.Forms.TextBox();
            this.txtV_C = new System.Windows.Forms.TextBox();
            this.txtV = new System.Windows.Forms.TextBox();
            this.txtT = new System.Windows.Forms.TextBox();
            this.txtP = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblNazivTacke
            // 
            this.lblNazivTacke.AutoSize = true;
            this.lblNazivTacke.Location = new System.Drawing.Point(15, 9);
            this.lblNazivTacke.Name = "lblNazivTacke";
            this.lblNazivTacke.Size = new System.Drawing.Size(41, 13);
            this.lblNazivTacke.TabIndex = 0;
            this.lblNazivTacke.Text = "Tacka:";
            this.lblNazivTacke.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Pritisak:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Temperatura:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Zapremina:";
            // 
            // txtP_C
            // 
            this.txtP_C.Location = new System.Drawing.Point(91, 48);
            this.txtP_C.Name = "txtP_C";
            this.txtP_C.Size = new System.Drawing.Size(183, 20);
            this.txtP_C.TabIndex = 5;
            this.txtP_C.Leave += new System.EventHandler(this.textBox_Change);
            // 
            // txtT_C
            // 
            this.txtT_C.Location = new System.Drawing.Point(91, 74);
            this.txtT_C.Name = "txtT_C";
            this.txtT_C.Size = new System.Drawing.Size(183, 20);
            this.txtT_C.TabIndex = 6;
            this.txtT_C.Leave += new System.EventHandler(this.textBox_Change);
            // 
            // txtV_C
            // 
            this.txtV_C.Location = new System.Drawing.Point(91, 100);
            this.txtV_C.Name = "txtV_C";
            this.txtV_C.Size = new System.Drawing.Size(183, 20);
            this.txtV_C.TabIndex = 7;
            this.txtV_C.Leave += new System.EventHandler(this.textBox_Change);
            // 
            // txtV
            // 
            this.txtV.Location = new System.Drawing.Point(330, 101);
            this.txtV.Name = "txtV";
            this.txtV.ReadOnly = true;
            this.txtV.Size = new System.Drawing.Size(179, 20);
            this.txtV.TabIndex = 10;
            // 
            // txtT
            // 
            this.txtT.Location = new System.Drawing.Point(330, 75);
            this.txtT.Name = "txtT";
            this.txtT.ReadOnly = true;
            this.txtT.Size = new System.Drawing.Size(179, 20);
            this.txtT.TabIndex = 9;
            // 
            // txtP
            // 
            this.txtP.Location = new System.Drawing.Point(330, 49);
            this.txtP.Name = "txtP";
            this.txtP.ReadOnly = true;
            this.txtP.Size = new System.Drawing.Size(179, 20);
            this.txtP.TabIndex = 8;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(199, 148);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "Prihvati";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(330, 148);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 13;
            this.button3.Text = "Odustani";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(515, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "[ K ]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(515, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "[ Pa ]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(515, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "[ m^3 ]";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(280, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "[ m^3 ]";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(280, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "[ Pa ]";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(280, 77);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "[ K ]";
            // 
            // KarnoovTackaSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 183);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtV);
            this.Controls.Add(this.txtT);
            this.Controls.Add(this.txtP);
            this.Controls.Add(this.txtV_C);
            this.Controls.Add(this.txtT_C);
            this.Controls.Add(this.txtP_C);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblNazivTacke);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KarnoovTackaSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Podesavanja tacke";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtP_C;
        private System.Windows.Forms.TextBox txtT_C;
        private System.Windows.Forms.TextBox txtV_C;
        private System.Windows.Forms.TextBox txtV;
        private System.Windows.Forms.TextBox txtT;
        private System.Windows.Forms.TextBox txtP;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        public System.Windows.Forms.Label lblNazivTacke;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}