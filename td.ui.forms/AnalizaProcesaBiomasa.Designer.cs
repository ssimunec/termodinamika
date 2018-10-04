namespace td.ui.forms
{
    partial class AnalizaProcesaBiomasa
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
            this.scintilla1 = new ScintillaNET.Scintilla();
            this.btnDodelaBz = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbZivotinje = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbBiomasa = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbAnaliza = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // scintilla1
            // 
            this.scintilla1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scintilla1.EdgeMode = ScintillaNET.EdgeMode.Line;
            this.scintilla1.Location = new System.Drawing.Point(15, 98);
            this.scintilla1.Name = "scintilla1";
            this.scintilla1.Size = new System.Drawing.Size(773, 340);
            this.scintilla1.TabIndex = 11;
            this.scintilla1.Click += new System.EventHandler(this.scintilla1_Click);
            // 
            // btnDodelaBz
            // 
            this.btnDodelaBz.Location = new System.Drawing.Point(464, 12);
            this.btnDodelaBz.Name = "btnDodelaBz";
            this.btnDodelaBz.Size = new System.Drawing.Size(99, 23);
            this.btnDodelaBz.TabIndex = 10;
            this.btnDodelaBz.Text = "Dodeli velicinu";
            this.btnDodelaBz.UseVisualStyleBackColor = true;
            this.btnDodelaBz.Click += new System.EventHandler(this.btnDodela_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Biomasa zivotinje";
            // 
            // cmbZivotinje
            // 
            this.cmbZivotinje.DisplayMember = "Labela";
            this.cmbZivotinje.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbZivotinje.FormattingEnabled = true;
            this.cmbZivotinje.Location = new System.Drawing.Point(138, 12);
            this.cmbZivotinje.Name = "cmbZivotinje";
            this.cmbZivotinje.Size = new System.Drawing.Size(320, 21);
            this.cmbZivotinje.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(464, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Dodeli velicinu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Biomasa";
            // 
            // cmbBiomasa
            // 
            this.cmbBiomasa.DisplayMember = "Labela";
            this.cmbBiomasa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBiomasa.FormattingEnabled = true;
            this.cmbBiomasa.Location = new System.Drawing.Point(138, 39);
            this.cmbBiomasa.Name = "cmbBiomasa";
            this.cmbBiomasa.Size = new System.Drawing.Size(320, 21);
            this.cmbBiomasa.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Substitucija";
            // 
            // cmbAnaliza
            // 
            this.cmbAnaliza.DisplayMember = "Labela";
            this.cmbAnaliza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnaliza.FormattingEnabled = true;
            this.cmbAnaliza.Location = new System.Drawing.Point(138, 69);
            this.cmbAnaliza.Name = "cmbAnaliza";
            this.cmbAnaliza.Size = new System.Drawing.Size(320, 21);
            this.cmbAnaliza.TabIndex = 16;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(464, 69);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 23);
            this.button2.TabIndex = 17;
            this.button2.Text = "Dodeli velicinu";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(569, 15);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(219, 77);
            this.button3.TabIndex = 18;
            this.button3.Text = "Analiziraj problem";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // AnalizaProcesaBiomasa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cmbAnaliza);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbBiomasa);
            this.Controls.Add(this.scintilla1);
            this.Controls.Add(this.btnDodelaBz);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbZivotinje);
            this.Name = "AnalizaProcesaBiomasa";
            this.Text = "AnalizaProcesaBiomasa";
            this.Load += new System.EventHandler(this.AnalizaProcesaBiomasa_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ScintillaNET.Scintilla scintilla1;
        private System.Windows.Forms.Button btnDodelaBz;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbZivotinje;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbBiomasa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbAnaliza;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}