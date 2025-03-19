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
            this.Datum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Standort = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sickdays = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.l_hint = new System.Windows.Forms.Label();
            this.stat_total_pre = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.stat_total_ho = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bt_settings = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.l_sickdays_warning = new System.Windows.Forms.Label();
            this.l_sickdays_total = new System.Windows.Forms.Label();
            this.l_sickdays_now = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt_addEntry
            // 
            this.bt_addEntry.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_addEntry.Location = new System.Drawing.Point(16, 355);
            this.bt_addEntry.Name = "bt_addEntry";
            this.bt_addEntry.Size = new System.Drawing.Size(103, 40);
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
            this.listView.Size = new System.Drawing.Size(556, 235);
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
            this.panel1.Controls.Add(this.l_hint);
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
            this.panel1.Location = new System.Drawing.Point(125, 259);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel1.Size = new System.Drawing.Size(237, 136);
            this.panel1.TabIndex = 6;
            // 
            // l_hint
            // 
            this.l_hint.AutoSize = true;
            this.l_hint.ForeColor = System.Drawing.Color.Red;
            this.l_hint.Location = new System.Drawing.Point(11, 109);
            this.l_hint.Name = "l_hint";
            this.l_hint.Size = new System.Drawing.Size(0, 14);
            this.l_hint.TabIndex = 10;
            // 
            // stat_total_pre
            // 
            this.stat_total_pre.AutoSize = true;
            this.stat_total_pre.Location = new System.Drawing.Point(131, 90);
            this.stat_total_pre.Name = "stat_total_pre";
            this.stat_total_pre.Size = new System.Drawing.Size(25, 14);
            this.stat_total_pre.TabIndex = 8;
            this.stat_total_pre.Text = "0 %";
            this.stat_total_pre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(131, 69);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 14);
            this.label10.TabIndex = 7;
            this.label10.Text = "51 %";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // stat_total_ho
            // 
            this.stat_total_ho.AutoSize = true;
            this.stat_total_ho.Location = new System.Drawing.Point(46, 88);
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
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(46, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 14);
            this.label8.TabIndex = 5;
            this.label8.Text = "49 %";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 14);
            this.label7.TabIndex = 4;
            this.label7.Text = "Ist:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 14);
            this.label6.TabIndex = 3;
            this.label6.Text = "Soll: ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(131, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 14);
            this.label5.TabIndex = 2;
            this.label5.Text = "Standort";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 34);
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
            this.label3.Location = new System.Drawing.Point(31, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Standort / Homeoffice";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bt_settings
            // 
            this.bt_settings.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_settings.Location = new System.Drawing.Point(16, 307);
            this.bt_settings.Name = "bt_settings";
            this.bt_settings.Size = new System.Drawing.Size(103, 40);
            this.bt_settings.TabIndex = 10;
            this.bt_settings.Text = "Einstellungen";
            this.bt_settings.UseVisualStyleBackColor = true;
            this.bt_settings.Click += new System.EventHandler(this.bt_settings_clicked);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.l_sickdays_warning);
            this.panel2.Controls.Add(this.l_sickdays_total);
            this.panel2.Controls.Add(this.l_sickdays_now);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(368, 259);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(204, 136);
            this.panel2.TabIndex = 11;
            // 
            // l_sickdays_warning
            // 
            this.l_sickdays_warning.AutoSize = true;
            this.l_sickdays_warning.Location = new System.Drawing.Point(14, 109);
            this.l_sickdays_warning.Name = "l_sickdays_warning";
            this.l_sickdays_warning.Size = new System.Drawing.Size(0, 13);
            this.l_sickdays_warning.TabIndex = 17;
            // 
            // l_sickdays_total
            // 
            this.l_sickdays_total.AutoSize = true;
            this.l_sickdays_total.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9F, System.Drawing.FontStyle.Bold);
            this.l_sickdays_total.Location = new System.Drawing.Point(130, 87);
            this.l_sickdays_total.Name = "l_sickdays_total";
            this.l_sickdays_total.Size = new System.Drawing.Size(25, 14);
            this.l_sickdays_total.TabIndex = 16;
            this.l_sickdays_total.Text = "0 %";
            // 
            // l_sickdays_now
            // 
            this.l_sickdays_now.AutoSize = true;
            this.l_sickdays_now.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9F, System.Drawing.FontStyle.Bold);
            this.l_sickdays_now.Location = new System.Drawing.Point(52, 87);
            this.l_sickdays_now.Name = "l_sickdays_now";
            this.l_sickdays_now.Size = new System.Drawing.Size(25, 14);
            this.l_sickdays_now.TabIndex = 15;
            this.l_sickdays_now.Text = "0 %";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9F, System.Drawing.FontStyle.Bold);
            this.label14.Location = new System.Drawing.Point(130, 67);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(37, 14);
            this.label14.TabIndex = 14;
            this.label14.Text = "< 10 %";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(52, 66);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(37, 14);
            this.label13.TabIndex = 13;
            this.label13.Text = "< 10 %";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(14, 87);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(23, 14);
            this.label11.TabIndex = 12;
            this.label11.Text = "Ist:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(14, 66);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(33, 14);
            this.label12.TabIndex = 11;
            this.label12.Text = "Soll: ";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(130, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 14);
            this.label9.TabIndex = 2;
            this.label9.Text = "gesamt";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(52, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "momentan";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.label1.Location = new System.Drawing.Point(48, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Krankentage";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 411);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.bt_settings);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.bt_addEntry);
            this.Font = new System.Drawing.Font("Bahnschrift SemiBold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 450);
            this.MinimumSize = new System.Drawing.Size(600, 450);
            this.Name = "form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GFN Anwesenheitsrechner";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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
        public System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader Datum;
        private System.Windows.Forms.ColumnHeader Standort;
        private System.Windows.Forms.ColumnHeader sickdays;
        private System.Windows.Forms.Button bt_settings;
        private System.Windows.Forms.Label l_hint;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label l_sickdays_warning;
        private System.Windows.Forms.Label l_sickdays_total;
        private System.Windows.Forms.Label l_sickdays_now;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
    }
}

