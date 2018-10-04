namespace td.ui.forms
{
    partial class AnalizaProcesa
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
            this.cmbParametar = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDodela = new System.Windows.Forms.Button();
            this.scintilla1 = new ScintillaNET.Scintilla();
            this.SuspendLayout();
            // 
            // cmbParametar
            // 
            this.cmbParametar.DisplayMember = "Labela";
            this.cmbParametar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParametar.FormattingEnabled = true;
            this.cmbParametar.Location = new System.Drawing.Point(138, 12);
            this.cmbParametar.Name = "cmbParametar";
            this.cmbParametar.Size = new System.Drawing.Size(320, 21);
            this.cmbParametar.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Velicina za dodeljivanje:";
            // 
            // btnDodela
            // 
            this.btnDodela.Location = new System.Drawing.Point(464, 12);
            this.btnDodela.Name = "btnDodela";
            this.btnDodela.Size = new System.Drawing.Size(99, 23);
            this.btnDodela.TabIndex = 2;
            this.btnDodela.Text = "Dodeli velicinu";
            this.btnDodela.UseVisualStyleBackColor = true;
            this.btnDodela.Click += new System.EventHandler(this.btnDodela_Click);
            // 
            // scintilla1
            // 
            this.scintilla1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scintilla1.EdgeMode = ScintillaNET.EdgeMode.Line;
            this.scintilla1.Location = new System.Drawing.Point(15, 39);
            this.scintilla1.Name = "scintilla1";
            this.scintilla1.Size = new System.Drawing.Size(773, 399);
            this.scintilla1.TabIndex = 7;
            // 
            // AnalizaProcesa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.scintilla1);
            this.Controls.Add(this.btnDodela);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbParametar);
            this.Name = "AnalizaProcesa";
            this.Text = "AnalizaProcesa";
            this.Load += new System.EventHandler(this.AnalizaProcesa_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbParametar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDodela;
        private ScintillaNET.Scintilla scintilla1;
    }
}