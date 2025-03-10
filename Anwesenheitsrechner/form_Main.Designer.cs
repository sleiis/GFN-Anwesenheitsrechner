namespace Anwesenheitsrechner
{
    partial class form_Main
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_Main));
            this.bt_addEntry = new System.Windows.Forms.Button();
            this.listView = new System.Windows.Forms.ListView();
            this.Datum = new System.Windows.Forms.ColumnHeader();
            this.Standort = new System.Windows.Forms.ColumnHeader();
            this.sickdays = new System.Windows.Forms.ColumnHeader();
            this.panel1 = new System.Windows.Forms.Panel();
            this.stat_total_pre = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.stat_total_ho = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bt_vacation = new System.Windows.Forms.Button();
            this.bt_settings = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt_addEntry
            // 
            this.bt_addEntry.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_addEntry.Location = new System.Drawing.Point(16, 376);
            this.bt_addEntry.Name = "bt_addEntry";
            this.bt_addEntry.Size = new System.Drawing.Size(146, 40);
            this.bt_addEntry.TabIndex = 0;
            this.bt_addEntry.Text = "Anwesenheit eintragen";
            this.bt_addEntry.UseVisualStyleBackColor = true;
            this.bt_addEntry.Click += new System.EventHandler(this.bt_addEntry_clicked);
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Datum,
            this.Standort,
            this.sickdays});
            this.listView.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.HideSelection = false;
            this.listView.LabelWrap = false;
            this.listView.Location = new System.Drawing.Point(16, 18);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(454, 235);
            this.listView.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.listView.TabIndex = 1;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // Datum
            // 
            this.Datum.Text = "Datum";
            this.Datum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Datum.Width = 215;
            // 
            // Standort
            // 
            this.Standort.Text = "Standort";
            this.Standort.Width = 335;
            // 
            // sickdays
            // 
            this.sickdays.Text = "Krankheitstag?";
            this.sickdays.Width = 224;
            // 
            // panel1
            // 
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.stat_total_pre);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.stat_total_ho);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(176, 287);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel1.Size = new System.Drawing.Size(294, 131);
            this.panel1.TabIndex = 6;
            // 
            // stat_total_pre
            // 
            this.stat_total_pre.AutoSize = true;
            this.stat_total_pre.Location = new System.Drawing.Point(213, 90);
            this.stat_total_pre.Name = "stat_total_pre";
            this.stat_total_pre.Size = new System.Drawing.Size(25, 14);
            this.stat_total_pre.TabIndex = 8;
            this.stat_total_pre.Text = "0 %";
            this.stat_total_pre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(213, 69);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 14);
            this.label10.TabIndex = 7;
            this.label10.Text = "51 %";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // stat_total_ho
            // 
            this.stat_total_ho.AutoSize = true;
            this.stat_total_ho.Location = new System.Drawing.Point(111, 88);
            this.stat_total_ho.Name = "stat_total_ho";
            this.stat_total_ho.Size = new System.Drawing.Size(25, 14);
            this.stat_total_ho.TabIndex = 6;
            this.stat_total_ho.Text = "0 %";
            this.stat_total_ho.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(111, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 14);
            this.label8.TabIndex = 5;
            this.label8.Text = "49 %";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 14);
            this.label7.TabIndex = 4;
            this.label7.Text = "Ist:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 14);
            this.label6.TabIndex = 3;
            this.label6.Text = "Soll: ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(213, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 14);
            this.label5.TabIndex = 2;
            this.label5.Text = "Standort";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(110, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 14);
            this.label4.TabIndex = 1;
            this.label4.Text = "Home-Office";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Gesamt";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bt_vacation
            // 
            this.bt_vacation.Enabled = false;
            this.bt_vacation.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_vacation.Location = new System.Drawing.Point(16, 331);
            this.bt_vacation.Name = "bt_vacation";
            this.bt_vacation.Size = new System.Drawing.Size(146, 40);
            this.bt_vacation.TabIndex = 7;
            this.bt_vacation.Text = "Urlaub eintragen";
            this.bt_vacation.UseVisualStyleBackColor = true;
            this.bt_vacation.Click += new System.EventHandler(this.bt_vacation_clicked);
            // 
            // bt_settings
            // 
            this.bt_settings.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_settings.Location = new System.Drawing.Point(16, 285);
            this.bt_settings.Name = "bt_settings";
            this.bt_settings.Size = new System.Drawing.Size(146, 40);
            this.bt_settings.TabIndex = 10;
            this.bt_settings.Text = "Einstellungen";
            this.bt_settings.UseVisualStyleBackColor = true;
            this.bt_settings.Click += new System.EventHandler(this.bt_settings_clicked);
            // 
            // form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 436);
            this.Controls.Add(this.bt_settings);
            this.Controls.Add(this.bt_vacation);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.bt_addEntry);
            this.Font = new System.Drawing.Font("Bahnschrift SemiBold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(502, 475);
            this.MinimumSize = new System.Drawing.Size(502, 475);
            this.Name = "form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GFN Anwesenheitsrechner";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_addEntry;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label stat_total_pre;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label stat_total_ho;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bt_vacation;
        public System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader Datum;
        private System.Windows.Forms.ColumnHeader Standort;
        private System.Windows.Forms.ColumnHeader sickdays;
        private System.Windows.Forms.Button bt_settings;
    }
}

