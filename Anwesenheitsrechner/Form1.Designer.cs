namespace Anwesenheitsrechner
{
    partial class Form1
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
            this.bt_addEntry = new System.Windows.Forms.Button();
            this.listView = new System.Windows.Forms.ListView();
            this.Datum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Standort = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sickdays = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.year_select = new System.Windows.Forms.ComboBox();
            this.month_select = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.stat_month_pre = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.stat_month_ho = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.bt_settings = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt_addEntry
            // 
            this.bt_addEntry.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_addEntry.Location = new System.Drawing.Point(34, 382);
            this.bt_addEntry.Name = "bt_addEntry";
            this.bt_addEntry.Size = new System.Drawing.Size(146, 40);
            this.bt_addEntry.TabIndex = 0;
            this.bt_addEntry.Text = "Anwesenheit eintragen";
            this.bt_addEntry.UseVisualStyleBackColor = true;
            this.bt_addEntry.Click += new System.EventHandler(this.button1_Click);
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
            this.listView.Location = new System.Drawing.Point(34, 57);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(752, 235);
            this.listView.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.listView.TabIndex = 1;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
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
            // year_select
            // 
            this.year_select.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.year_select.FormattingEnabled = true;
            this.year_select.Items.AddRange(new object[] {
            "2024",
            "2025",
            "2026"});
            this.year_select.Location = new System.Drawing.Point(457, 17);
            this.year_select.Name = "year_select";
            this.year_select.Size = new System.Drawing.Size(130, 22);
            this.year_select.TabIndex = 2;
            // 
            // month_select
            // 
            this.month_select.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.month_select.FormattingEnabled = true;
            this.month_select.Items.AddRange(new object[] {
            "Januar",
            "Februar",
            "März",
            "April",
            "Mai",
            "Juni",
            "Juli",
            "August",
            "September",
            "Oktober",
            "November",
            "Dezember"});
            this.month_select.Location = new System.Drawing.Point(656, 17);
            this.month_select.Name = "month_select";
            this.month_select.Size = new System.Drawing.Size(130, 22);
            this.month_select.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(415, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "Jahr: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(604, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "Monat: ";
            // 
            // panel1
            // 
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
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
            this.panel1.Location = new System.Drawing.Point(492, 302);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel1.Size = new System.Drawing.Size(294, 123);
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
            this.label3.Location = new System.Drawing.Point(139, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Gesamt";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bt_vacation
            // 
            this.bt_vacation.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_vacation.Location = new System.Drawing.Point(34, 337);
            this.bt_vacation.Name = "bt_vacation";
            this.bt_vacation.Size = new System.Drawing.Size(146, 40);
            this.bt_vacation.TabIndex = 7;
            this.bt_vacation.Text = "Urlaub eintragen";
            this.bt_vacation.UseVisualStyleBackColor = true;
            this.bt_vacation.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel2
            // 
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel2.Controls.Add(this.stat_month_pre);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.stat_month_ho);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.label20);
            this.panel2.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(191, 301);
            this.panel2.Name = "panel2";
            this.panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel2.Size = new System.Drawing.Size(294, 123);
            this.panel2.TabIndex = 9;
            // 
            // stat_month_pre
            // 
            this.stat_month_pre.AutoSize = true;
            this.stat_month_pre.Location = new System.Drawing.Point(213, 90);
            this.stat_month_pre.Name = "stat_month_pre";
            this.stat_month_pre.Size = new System.Drawing.Size(25, 14);
            this.stat_month_pre.TabIndex = 8;
            this.stat_month_pre.Text = "0 %";
            this.stat_month_pre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(213, 69);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 14);
            this.label13.TabIndex = 7;
            this.label13.Text = "51 %";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // stat_month_ho
            // 
            this.stat_month_ho.AutoSize = true;
            this.stat_month_ho.Location = new System.Drawing.Point(111, 88);
            this.stat_month_ho.Name = "stat_month_ho";
            this.stat_month_ho.Size = new System.Drawing.Size(25, 14);
            this.stat_month_ho.TabIndex = 6;
            this.stat_month_ho.Text = "0 %";
            this.stat_month_ho.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(111, 67);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(31, 14);
            this.label15.TabIndex = 5;
            this.label15.Text = "49 %";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(20, 88);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(23, 14);
            this.label16.TabIndex = 4;
            this.label16.Text = "Ist:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(20, 67);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(33, 14);
            this.label17.TabIndex = 3;
            this.label17.Text = "Soll: ";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(213, 34);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(53, 14);
            this.label18.TabIndex = 2;
            this.label18.Text = "Standort";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(110, 34);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(75, 14);
            this.label19.TabIndex = 1;
            this.label19.Text = "Home-Office";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(138, 4);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(53, 19);
            this.label20.TabIndex = 0;
            this.label20.Text = "Monat";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bt_settings
            // 
            this.bt_settings.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_settings.Location = new System.Drawing.Point(34, 7);
            this.bt_settings.Name = "bt_settings";
            this.bt_settings.Size = new System.Drawing.Size(146, 40);
            this.bt_settings.TabIndex = 10;
            this.bt_settings.Text = "Einstellungen";
            this.bt_settings.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 436);
            this.Controls.Add(this.bt_settings);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.bt_vacation);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.month_select);
            this.Controls.Add(this.year_select);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.bt_addEntry);
            this.Font = new System.Drawing.Font("Bahnschrift SemiBold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Anwesenheitsrechner";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_addEntry;
        private System.Windows.Forms.ComboBox year_select;
        private System.Windows.Forms.ComboBox month_select;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
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
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label stat_month_pre;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label stat_month_ho;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button bt_settings;
    }
}

