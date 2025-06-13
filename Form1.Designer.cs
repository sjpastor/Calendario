namespace Calendario
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelSuperior = new System.Windows.Forms.Panel();
            this.lblHora = new System.Windows.Forms.Label();
            this.cmsSuperior = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ampliarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panelHerramientas = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.mesEnero = new System.Windows.Forms.MonthCalendar();
            this.mesFebrero = new System.Windows.Forms.MonthCalendar();
            this.mesMarzo = new System.Windows.Forms.MonthCalendar();
            this.monthCalendar4 = new System.Windows.Forms.MonthCalendar();
            this.monthCalendar5 = new System.Windows.Forms.MonthCalendar();
            this.monthCalendar6 = new System.Windows.Forms.MonthCalendar();
            this.mesAbril = new System.Windows.Forms.MonthCalendar();
            this.monthCalendar8 = new System.Windows.Forms.MonthCalendar();
            this.monthCalendar9 = new System.Windows.Forms.MonthCalendar();
            this.monthCalendar10 = new System.Windows.Forms.MonthCalendar();
            this.monthCalendar11 = new System.Windows.Forms.MonthCalendar();
            this.monthCalendar12 = new System.Windows.Forms.MonthCalendar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtAnno = new System.Windows.Forms.NumericUpDown();
            this.panelSuperior.SuspendLayout();
            this.cmsSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAnno)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panelSuperior
            // 
            this.panelSuperior.Controls.Add(this.lblHora);
            this.panelSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSuperior.Location = new System.Drawing.Point(0, 0);
            this.panelSuperior.Name = "panelSuperior";
            this.panelSuperior.Size = new System.Drawing.Size(1290, 32);
            this.panelSuperior.TabIndex = 1;
            // 
            // lblHora
            // 
            this.lblHora.BackColor = System.Drawing.Color.LightCyan;
            this.lblHora.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHora.ContextMenuStrip = this.cmsSuperior;
            this.lblHora.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHora.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblHora.ForeColor = System.Drawing.Color.Teal;
            this.lblHora.Location = new System.Drawing.Point(0, 0);
            this.lblHora.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(1290, 30);
            this.lblHora.TabIndex = 5;
            this.lblHora.Text = "label1";
            this.lblHora.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblHora.Click += new System.EventHandler(this.lblHora_Click);
            this.lblHora.MouseEnter += new System.EventHandler(this.lblHora_MouseEnter);
            this.lblHora.MouseLeave += new System.EventHandler(this.lblHora_MouseLeave);
            // 
            // cmsSuperior
            // 
            this.cmsSuperior.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ampliarToolStripMenuItem,
            this.minimizarToolStripMenuItem,
            this.toolStripMenuItem1,
            this.cerrarToolStripMenuItem});
            this.cmsSuperior.Name = "cmsSuperior";
            this.cmsSuperior.Size = new System.Drawing.Size(128, 76);
            // 
            // ampliarToolStripMenuItem
            // 
            this.ampliarToolStripMenuItem.Name = "ampliarToolStripMenuItem";
            this.ampliarToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.ampliarToolStripMenuItem.Text = "Ampliar";
            this.ampliarToolStripMenuItem.Click += new System.EventHandler(this.ampliarToolStripMenuItem_Click);
            // 
            // cerrarToolStripMenuItem
            // 
            this.cerrarToolStripMenuItem.Name = "cerrarToolStripMenuItem";
            this.cerrarToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.cerrarToolStripMenuItem.Text = "Cerrar";
            this.cerrarToolStripMenuItem.Click += new System.EventHandler(this.cerrarToolStripMenuItem_Click);
            // 
            // minimizarToolStripMenuItem
            // 
            this.minimizarToolStripMenuItem.Name = "minimizarToolStripMenuItem";
            this.minimizarToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.minimizarToolStripMenuItem.Text = "Minimizar";
            this.minimizarToolStripMenuItem.Click += new System.EventHandler(this.minimizarToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(124, 6);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 714);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1290, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // panelHerramientas
            // 
            this.panelHerramientas.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHerramientas.Location = new System.Drawing.Point(0, 32);
            this.panelHerramientas.Name = "panelHerramientas";
            this.panelHerramientas.Size = new System.Drawing.Size(1290, 43);
            this.panelHerramientas.TabIndex = 3;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 75);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 639);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 75);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.monthCalendar9);
            this.splitContainer1.Panel1.Controls.Add(this.monthCalendar10);
            this.splitContainer1.Panel1.Controls.Add(this.monthCalendar11);
            this.splitContainer1.Panel1.Controls.Add(this.monthCalendar12);
            this.splitContainer1.Panel1.Controls.Add(this.monthCalendar8);
            this.splitContainer1.Panel1.Controls.Add(this.mesAbril);
            this.splitContainer1.Panel1.Controls.Add(this.monthCalendar6);
            this.splitContainer1.Panel1.Controls.Add(this.monthCalendar5);
            this.splitContainer1.Panel1.Controls.Add(this.monthCalendar4);
            this.splitContainer1.Panel1.Controls.Add(this.mesMarzo);
            this.splitContainer1.Panel1.Controls.Add(this.mesFebrero);
            this.splitContainer1.Panel1.Controls.Add(this.mesEnero);
            this.splitContainer1.Size = new System.Drawing.Size(1287, 639);
            this.splitContainer1.SplitterDistance = 933;
            this.splitContainer1.TabIndex = 5;
            // 
            // mesEnero
            // 
            this.mesEnero.Font = new System.Drawing.Font("Open Sans", 10F);
            this.mesEnero.Location = new System.Drawing.Point(43, 74);
            this.mesEnero.Name = "mesEnero";
            this.mesEnero.TabIndex = 0;
            // 
            // mesFebrero
            // 
            this.mesFebrero.Font = new System.Drawing.Font("Open Sans", 10F);
            this.mesFebrero.Location = new System.Drawing.Point(259, 74);
            this.mesFebrero.Name = "mesFebrero";
            this.mesFebrero.TabIndex = 1;
            // 
            // mesMarzo
            // 
            this.mesMarzo.Font = new System.Drawing.Font("Open Sans", 10F);
            this.mesMarzo.Location = new System.Drawing.Point(475, 74);
            this.mesMarzo.Name = "mesMarzo";
            this.mesMarzo.TabIndex = 2;
            // 
            // monthCalendar4
            // 
            this.monthCalendar4.Font = new System.Drawing.Font("Open Sans", 10F);
            this.monthCalendar4.Location = new System.Drawing.Point(43, 254);
            this.monthCalendar4.Name = "monthCalendar4";
            this.monthCalendar4.TabIndex = 3;
            // 
            // monthCalendar5
            // 
            this.monthCalendar5.Font = new System.Drawing.Font("Open Sans", 10F);
            this.monthCalendar5.Location = new System.Drawing.Point(259, 254);
            this.monthCalendar5.Name = "monthCalendar5";
            this.monthCalendar5.TabIndex = 4;
            // 
            // monthCalendar6
            // 
            this.monthCalendar6.Font = new System.Drawing.Font("Open Sans", 10F);
            this.monthCalendar6.Location = new System.Drawing.Point(475, 254);
            this.monthCalendar6.Name = "monthCalendar6";
            this.monthCalendar6.TabIndex = 5;
            // 
            // mesAbril
            // 
            this.mesAbril.Font = new System.Drawing.Font("Open Sans", 10F);
            this.mesAbril.Location = new System.Drawing.Point(691, 74);
            this.mesAbril.Name = "mesAbril";
            this.mesAbril.TabIndex = 6;
            // 
            // monthCalendar8
            // 
            this.monthCalendar8.Font = new System.Drawing.Font("Open Sans", 10F);
            this.monthCalendar8.Location = new System.Drawing.Point(691, 254);
            this.monthCalendar8.Name = "monthCalendar8";
            this.monthCalendar8.TabIndex = 7;
            // 
            // monthCalendar9
            // 
            this.monthCalendar9.Font = new System.Drawing.Font("Open Sans", 10F);
            this.monthCalendar9.Location = new System.Drawing.Point(691, 434);
            this.monthCalendar9.Name = "monthCalendar9";
            this.monthCalendar9.TabIndex = 11;
            // 
            // monthCalendar10
            // 
            this.monthCalendar10.Font = new System.Drawing.Font("Open Sans", 10F);
            this.monthCalendar10.Location = new System.Drawing.Point(475, 434);
            this.monthCalendar10.Name = "monthCalendar10";
            this.monthCalendar10.TabIndex = 10;
            // 
            // monthCalendar11
            // 
            this.monthCalendar11.Font = new System.Drawing.Font("Open Sans", 10F);
            this.monthCalendar11.Location = new System.Drawing.Point(259, 434);
            this.monthCalendar11.Name = "monthCalendar11";
            this.monthCalendar11.TabIndex = 9;
            // 
            // monthCalendar12
            // 
            this.monthCalendar12.Font = new System.Drawing.Font("Open Sans", 10F);
            this.monthCalendar12.Location = new System.Drawing.Point(43, 434);
            this.monthCalendar12.Name = "monthCalendar12";
            this.monthCalendar12.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtAnno);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(933, 42);
            this.panel1.TabIndex = 12;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1290, 736);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panelHerramientas);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panelSuperior);
            this.Font = new System.Drawing.Font("Open Sans", 9F);
            this.ForeColor = System.Drawing.Color.Teal;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelSuperior.ResumeLayout(false);
            this.cmsSuperior.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtAnno)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panelSuperior;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.ContextMenuStrip cmsSuperior;
        private System.Windows.Forms.ToolStripMenuItem ampliarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minimizarToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panelHerramientas;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.MonthCalendar mesEnero;
        private System.Windows.Forms.MonthCalendar monthCalendar9;
        private System.Windows.Forms.MonthCalendar monthCalendar10;
        private System.Windows.Forms.MonthCalendar monthCalendar11;
        private System.Windows.Forms.MonthCalendar monthCalendar12;
        private System.Windows.Forms.MonthCalendar monthCalendar8;
        private System.Windows.Forms.MonthCalendar mesAbril;
        private System.Windows.Forms.MonthCalendar monthCalendar6;
        private System.Windows.Forms.MonthCalendar monthCalendar5;
        private System.Windows.Forms.MonthCalendar monthCalendar4;
        private System.Windows.Forms.MonthCalendar mesMarzo;
        private System.Windows.Forms.MonthCalendar mesFebrero;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown txtAnno;
    }
}

