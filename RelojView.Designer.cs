namespace Calendario
{
    partial class RelojView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RelojView));
            this.panelBotones = new System.Windows.Forms.Panel();
            this.cmdSalir = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdFijar = new System.Windows.Forms.Button();
            this.lblHora = new System.Windows.Forms.Label();
            this.panelBotones.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBotones
            // 
            this.panelBotones.BackColor = System.Drawing.SystemColors.Info;
            this.panelBotones.Controls.Add(this.cmdSalir);
            this.panelBotones.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelBotones.Location = new System.Drawing.Point(0, 0);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Size = new System.Drawing.Size(33, 42);
            this.panelBotones.TabIndex = 2;
            // 
            // cmdSalir
            // 
            this.cmdSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdSalir.BackgroundImage")));
            this.cmdSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdSalir.Location = new System.Drawing.Point(1, 5);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(32, 30);
            this.cmdSalir.TabIndex = 0;
            this.cmdSalir.UseVisualStyleBackColor = true;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Info;
            this.panel1.Controls.Add(this.cmdFijar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(323, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(33, 42);
            this.panel1.TabIndex = 4;
            // 
            // cmdFijar
            // 
            this.cmdFijar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdFijar.Location = new System.Drawing.Point(1, 5);
            this.cmdFijar.Name = "cmdFijar";
            this.cmdFijar.Size = new System.Drawing.Size(32, 30);
            this.cmdFijar.TabIndex = 0;
            this.cmdFijar.UseVisualStyleBackColor = true;
            this.cmdFijar.Click += new System.EventHandler(this.cmdFijar_Click);
            // 
            // lblHora
            // 
            this.lblHora.BackColor = System.Drawing.SystemColors.Info;
            this.lblHora.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHora.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHora.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblHora.Location = new System.Drawing.Point(33, 0);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(290, 42);
            this.lblHora.TabIndex = 5;
            this.lblHora.Text = "label1";
            this.lblHora.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblHora.Click += new System.EventHandler(this.lblHora_Click);
            // 
            // RelojView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 42);
            this.Controls.Add(this.lblHora);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelBotones);
            this.Name = "RelojView";
            this.Text = "RelojForm";
            this.Load += new System.EventHandler(this.RelojView_Load);
            this.panelBotones.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.Button cmdSalir;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmdFijar;
        private System.Windows.Forms.Label lblHora;
    }
}