namespace td.ui.forms.Karnoov
{
    partial class JednaVrednost
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
            this.txtP = new System.Windows.Forms.TextBox();
            this.txtP_C = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblJedinica = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtP
            // 
            this.txtP.Location = new System.Drawing.Point(171, 40);
            this.txtP.Name = "txtP";
            this.txtP.ReadOnly = true;
            this.txtP.Size = new System.Drawing.Size(148, 20);
            this.txtP.TabIndex = 11;
            // 
            // txtP_C
            // 
            this.txtP_C.Location = new System.Drawing.Point(17, 40);
            this.txtP_C.Name = "txtP_C";
            this.txtP_C.Size = new System.Drawing.Size(148, 20);
            this.txtP_C.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Naziv velicine";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(258, 77);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 22);
            this.button3.TabIndex = 16;
            this.button3.Text = "Odustani";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(152, 77);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 22);
            this.button2.TabIndex = 15;
            this.button2.Text = "Prihvati";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(52, 77);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 22);
            this.button1.TabIndex = 14;
            this.button1.Text = "Provera";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblJedinica
            // 
            this.lblJedinica.AutoSize = true;
            this.lblJedinica.Location = new System.Drawing.Point(325, 43);
            this.lblJedinica.Name = "lblJedinica";
            this.lblJedinica.Size = new System.Drawing.Size(13, 13);
            this.lblJedinica.TabIndex = 17;
            this.lblJedinica.Text = "[]";
            // 
            // JednaVrednost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 118);
            this.Controls.Add(this.lblJedinica);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtP);
            this.Controls.Add(this.txtP_C);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "JednaVrednost";
            this.Text = "JednaVrednost";
            this.Load += new System.EventHandler(this.JednaVrednost_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtP;
        private System.Windows.Forms.TextBox txtP_C;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label lblJedinica;
    }
}