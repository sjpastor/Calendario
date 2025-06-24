namespace Calendario
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtAnno = new System.Windows.Forms.NumericUpDown();
            this.panelSuperior = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelHerramientas = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAnno)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtAnno);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 42);
            this.panel1.TabIndex = 13;
            // 
            // txtAnno
            // 
            this.txtAnno.Font = new System.Drawing.Font("Open Sans", 10F, System.Drawing.FontStyle.Bold);
            this.txtAnno.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtAnno.Location = new System.Drawing.Point(402, 9);
            this.txtAnno.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.txtAnno.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.txtAnno.Name = "txtAnno";
            this.txtAnno.Size = new System.Drawing.Size(120, 26);
            this.txtAnno.TabIndex = 0;
            this.txtAnno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAnno.Value = new decimal(new int[] {
            2025,
            0,
            0,
            0});
            // 
            // panelSuperior
            // 
            this.panelSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSuperior.Location = new System.Drawing.Point(0, 42);
            this.panelSuperior.Name = "panelSuperior";
            this.panelSuperior.Size = new System.Drawing.Size(800, 32);
            this.panelSuperior.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 74);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 32);
            this.panel2.TabIndex = 15;
            // 
            // panelHerramientas
            // 
            this.panelHerramientas.Location = new System.Drawing.Point(-245, 204);
            this.panelHerramientas.Name = "panelHerramientas";
            this.panelHerramientas.Size = new System.Drawing.Size(1290, 10);
            this.panelHerramientas.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Linen;
            this.label1.Location = new System.Drawing.Point(71, 337);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(817, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelHerramientas);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelSuperior);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtAnno)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown txtAnno;
        private System.Windows.Forms.Panel panelSuperior;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelHerramientas;
        private System.Windows.Forms.Label label1;
    }
}