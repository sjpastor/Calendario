namespace Calendario
{
    partial class CalendarioAnualView
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.monthCalendar9 = new System.Windows.Forms.MonthCalendar();
            this.monthCalendar10 = new System.Windows.Forms.MonthCalendar();
            this.monthCalendar11 = new System.Windows.Forms.MonthCalendar();
            this.monthCalendar12 = new System.Windows.Forms.MonthCalendar();
            this.monthCalendar8 = new System.Windows.Forms.MonthCalendar();
            this.mesAbril = new System.Windows.Forms.MonthCalendar();
            this.monthCalendar6 = new System.Windows.Forms.MonthCalendar();
            this.monthCalendar5 = new System.Windows.Forms.MonthCalendar();
            this.monthCalendar4 = new System.Windows.Forms.MonthCalendar();
            this.mesMarzo = new System.Windows.Forms.MonthCalendar();
            this.mesFebrero = new System.Windows.Forms.MonthCalendar();
            this.mesEnero = new System.Windows.Forms.MonthCalendar();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Evento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comentarios = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.lblHora = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 714);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1290, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 24);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 690);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
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
            this.splitContainer1.Panel1MinSize = 300;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Panel2MinSize = 300;
            this.splitContainer1.Size = new System.Drawing.Size(1287, 690);
            this.splitContainer1.SplitterDistance = 891;
            this.splitContainer1.TabIndex = 5;
            this.splitContainer1.SplitterMoving += new System.Windows.Forms.SplitterCancelEventHandler(this.splitContainer1_SplitterMoving);
            // 
            // monthCalendar9
            // 
            this.monthCalendar9.Font = new System.Drawing.Font("Open Sans", 10F);
            this.monthCalendar9.Location = new System.Drawing.Point(671, 434);
            this.monthCalendar9.Name = "monthCalendar9";
            this.monthCalendar9.TabIndex = 11;
            // 
            // monthCalendar10
            // 
            this.monthCalendar10.Font = new System.Drawing.Font("Open Sans", 10F);
            this.monthCalendar10.Location = new System.Drawing.Point(455, 434);
            this.monthCalendar10.Name = "monthCalendar10";
            this.monthCalendar10.TabIndex = 10;
            // 
            // monthCalendar11
            // 
            this.monthCalendar11.Font = new System.Drawing.Font("Open Sans", 10F);
            this.monthCalendar11.Location = new System.Drawing.Point(239, 434);
            this.monthCalendar11.Name = "monthCalendar11";
            this.monthCalendar11.TabIndex = 9;
            // 
            // monthCalendar12
            // 
            this.monthCalendar12.Font = new System.Drawing.Font("Open Sans", 10F);
            this.monthCalendar12.Location = new System.Drawing.Point(23, 434);
            this.monthCalendar12.Name = "monthCalendar12";
            this.monthCalendar12.TabIndex = 8;
            // 
            // monthCalendar8
            // 
            this.monthCalendar8.Font = new System.Drawing.Font("Open Sans", 10F);
            this.monthCalendar8.Location = new System.Drawing.Point(671, 254);
            this.monthCalendar8.Name = "monthCalendar8";
            this.monthCalendar8.TabIndex = 7;
            // 
            // mesAbril
            // 
            this.mesAbril.Font = new System.Drawing.Font("Open Sans", 10F);
            this.mesAbril.Location = new System.Drawing.Point(671, 74);
            this.mesAbril.Name = "mesAbril";
            this.mesAbril.TabIndex = 6;
            // 
            // monthCalendar6
            // 
            this.monthCalendar6.Font = new System.Drawing.Font("Open Sans", 10F);
            this.monthCalendar6.Location = new System.Drawing.Point(455, 254);
            this.monthCalendar6.Name = "monthCalendar6";
            this.monthCalendar6.TabIndex = 5;
            // 
            // monthCalendar5
            // 
            this.monthCalendar5.Font = new System.Drawing.Font("Open Sans", 10F);
            this.monthCalendar5.Location = new System.Drawing.Point(239, 254);
            this.monthCalendar5.Name = "monthCalendar5";
            this.monthCalendar5.TabIndex = 4;
            // 
            // monthCalendar4
            // 
            this.monthCalendar4.Font = new System.Drawing.Font("Open Sans", 10F);
            this.monthCalendar4.Location = new System.Drawing.Point(23, 254);
            this.monthCalendar4.Name = "monthCalendar4";
            this.monthCalendar4.TabIndex = 3;
            // 
            // mesMarzo
            // 
            this.mesMarzo.Font = new System.Drawing.Font("Open Sans", 10F);
            this.mesMarzo.Location = new System.Drawing.Point(455, 74);
            this.mesMarzo.Name = "mesMarzo";
            this.mesMarzo.TabIndex = 2;
            // 
            // mesFebrero
            // 
            this.mesFebrero.Font = new System.Drawing.Font("Open Sans", 10F);
            this.mesFebrero.Location = new System.Drawing.Point(239, 74);
            this.mesFebrero.Name = "mesFebrero";
            this.mesFebrero.TabIndex = 1;
            // 
            // mesEnero
            // 
            this.mesEnero.Font = new System.Drawing.Font("Open Sans", 10F);
            this.mesEnero.Location = new System.Drawing.Point(23, 74);
            this.mesEnero.Name = "mesEnero";
            this.mesEnero.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Fecha,
            this.Hora,
            this.Evento,
            this.Comentarios});
            this.dataGridView1.Location = new System.Drawing.Point(22, 74);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(295, 485);
            this.dataGridView1.TabIndex = 0;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Width = 60;
            // 
            // Fecha
            // 
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            // 
            // Hora
            // 
            this.Hora.HeaderText = "Hora";
            this.Hora.Name = "Hora";
            // 
            // Evento
            // 
            this.Evento.HeaderText = "Evento";
            this.Evento.Name = "Evento";
            // 
            // Comentarios
            // 
            this.Comentarios.HeaderText = "Comentarios";
            this.Comentarios.Name = "Comentarios";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1290, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.abrirToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.cerrarToolStripMenuItem,
            this.toolStripMenuItem1,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.nuevoToolStripMenuItem.Text = "Nuevo...";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.guardarToolStripMenuItem.Text = "Guardar";
            // 
            // cerrarToolStripMenuItem
            // 
            this.cerrarToolStripMenuItem.Name = "cerrarToolStripMenuItem";
            this.cerrarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cerrarToolStripMenuItem.Text = "Cerrar";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(3, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1287, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // lblHora
            // 
            this.lblHora.BackColor = System.Drawing.Color.LightCyan;
            this.lblHora.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHora.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHora.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblHora.ForeColor = System.Drawing.Color.Teal;
            this.lblHora.Location = new System.Drawing.Point(3, 49);
            this.lblHora.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(1287, 30);
            this.lblHora.TabIndex = 8;
            this.lblHora.Text = "label1";
            this.lblHora.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CalendarioAnualView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1290, 736);
            this.Controls.Add(this.lblHora);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Open Sans", 9F);
            this.ForeColor = System.Drawing.Color.Teal;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CalendarioAnualView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calendario anual";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.CalendarioView_SizeChanged);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
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
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora;
        private System.Windows.Forms.DataGridViewTextBoxColumn Evento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comentarios;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Label lblHora;
    }
}

