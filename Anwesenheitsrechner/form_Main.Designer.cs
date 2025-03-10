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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_Main));
            this.panel1 = new Anwesenheitsrechner.CustomUI.CustomGroupBox();
            this.stat_total_pre = new Anwesenheitsrechner.CustomUI.CustomLabel();
            this.label10 = new Anwesenheitsrechner.CustomUI.CustomLabel();
            this.stat_total_ho = new Anwesenheitsrechner.CustomUI.CustomLabel();
            this.label8 = new Anwesenheitsrechner.CustomUI.CustomLabel();
            this.label7 = new Anwesenheitsrechner.CustomUI.CustomLabel();
            this.label6 = new Anwesenheitsrechner.CustomUI.CustomLabel();
            this.label5 = new Anwesenheitsrechner.CustomUI.CustomLabel();
            this.label4 = new Anwesenheitsrechner.CustomUI.CustomLabel();
            this.formSkin = new Anwesenheitsrechner.CustomUI.CustomSkin();
            this.listView = new System.Windows.Forms.DataGridView();
            this.Datum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Standort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sickdays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bt_settings = new Anwesenheitsrechner.CustomUI.CustomButton2();
            this.bt_vacation = new Anwesenheitsrechner.CustomUI.CustomButton2();
            this.btnClose = new Anwesenheitsrechner.CustomUI.CustomClose();
            this.customMini1 = new Anwesenheitsrechner.CustomUI.CustomMini();
            this.bt_addEntry = new Anwesenheitsrechner.CustomUI.CustomButton2();
            this.panel1.SuspendLayout();
            this.formSkin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(30)))), ((int)(((byte)(59)))));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(43)))));
            this.panel1.Controls.Add(this.stat_total_pre);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.stat_total_ho);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(176, 309);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel1.ShowText = true;
            this.panel1.Size = new System.Drawing.Size(326, 154);
            this.panel1.TabIndex = 6;
            this.panel1.Text = "Gesamt";
            // 
            // stat_total_pre
            // 
            this.stat_total_pre.AutoSize = true;
            this.stat_total_pre.BackColor = System.Drawing.Color.Transparent;
            this.stat_total_pre.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stat_total_pre.ForeColor = System.Drawing.Color.White;
            this.stat_total_pre.Location = new System.Drawing.Point(218, 103);
            this.stat_total_pre.Name = "stat_total_pre";
            this.stat_total_pre.Size = new System.Drawing.Size(34, 20);
            this.stat_total_pre.TabIndex = 8;
            this.stat_total_pre.Text = "0 %";
            this.stat_total_pre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DarkRed;
            this.label10.Location = new System.Drawing.Point(218, 82);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 20);
            this.label10.TabIndex = 7;
            this.label10.Text = "51 %";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // stat_total_ho
            // 
            this.stat_total_ho.AutoSize = true;
            this.stat_total_ho.BackColor = System.Drawing.Color.Transparent;
            this.stat_total_ho.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stat_total_ho.ForeColor = System.Drawing.Color.White;
            this.stat_total_ho.Location = new System.Drawing.Point(116, 101);
            this.stat_total_ho.Name = "stat_total_ho";
            this.stat_total_ho.Size = new System.Drawing.Size(34, 20);
            this.stat_total_ho.TabIndex = 6;
            this.stat_total_ho.Text = "0 %";
            this.stat_total_ho.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkRed;
            this.label8.Location = new System.Drawing.Point(116, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 20);
            this.label8.TabIndex = 5;
            this.label8.Text = "49 %";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(21, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "Ist:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(21, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 20);
            this.label6.TabIndex = 3;
            this.label6.Text = "Soll: ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(196, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Standort";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(93, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Home-Office";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // formSkin
            // 
            this.formSkin.BackColor = System.Drawing.Color.White;
            this.formSkin.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(30)))), ((int)(((byte)(59)))));
            this.formSkin.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(58)))), ((int)(((byte)(60)))));
            this.formSkin.Controls.Add(this.listView);
            this.formSkin.Controls.Add(this.bt_settings);
            this.formSkin.Controls.Add(this.bt_vacation);
            this.formSkin.Controls.Add(this.btnClose);
            this.formSkin.Controls.Add(this.customMini1);
            this.formSkin.Controls.Add(this.bt_addEntry);
            this.formSkin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formSkin.FlatColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(96)))), ((int)(((byte)(253)))));
            this.formSkin.Font = new System.Drawing.Font("Tahoma", 12F);
            this.formSkin.HeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(43)))));
            this.formSkin.HeaderMaximize = false;
            this.formSkin.Location = new System.Drawing.Point(0, 0);
            this.formSkin.Name = "formSkin";
            this.formSkin.Size = new System.Drawing.Size(502, 475);
            this.formSkin.TabIndex = 11;
            this.formSkin.Text = "GFN Anwesenheitsrechner";
            // 
            // listView
            // 
            this.listView.AllowUserToAddRows = false;
            this.listView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(43)))));
            this.listView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.listView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(30)))), ((int)(((byte)(59)))));
            this.listView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(43)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.listView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.listView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Datum,
            this.Standort,
            this.sickdays});
            this.listView.EnableHeadersVisualStyles = false;
            this.listView.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.listView.Location = new System.Drawing.Point(12, 44);
            this.listView.Name = "listView";
            this.listView.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(43)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(96)))), ((int)(((byte)(253)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.listView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.listView.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(43)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(96)))), ((int)(((byte)(253)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.listView.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.listView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listView.Size = new System.Drawing.Size(478, 259);
            this.listView.TabIndex = 11;
            // 
            // Datum
            // 
            this.Datum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Datum.HeaderText = "Datum";
            this.Datum.Name = "Datum";
            this.Datum.ReadOnly = true;
            // 
            // Standort
            // 
            this.Standort.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Standort.HeaderText = "Standort";
            this.Standort.Name = "Standort";
            this.Standort.ReadOnly = true;
            this.Standort.Width = 94;
            // 
            // sickdays
            // 
            this.sickdays.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.sickdays.HeaderText = "Krank";
            this.sickdays.Name = "sickdays";
            this.sickdays.ReadOnly = true;
            this.sickdays.Width = 74;
            // 
            // bt_settings
            // 
            this.bt_settings.BackColor = System.Drawing.Color.Transparent;
            this.bt_settings.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(96)))), ((int)(((byte)(253)))));
            this.bt_settings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_settings.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_settings.Location = new System.Drawing.Point(12, 321);
            this.bt_settings.Name = "bt_settings";
            this.bt_settings.Rounded = true;
            this.bt_settings.Size = new System.Drawing.Size(146, 40);
            this.bt_settings.TabIndex = 10;
            this.bt_settings.Text = "Einstellungen";
            this.bt_settings.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(252)))), ((int)(((byte)(255)))));
            this.bt_settings.Click += new System.EventHandler(this.bt_settings_clicked);
            // 
            // bt_vacation
            // 
            this.bt_vacation.BackColor = System.Drawing.Color.Transparent;
            this.bt_vacation.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(96)))), ((int)(((byte)(253)))));
            this.bt_vacation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_vacation.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_vacation.Location = new System.Drawing.Point(12, 367);
            this.bt_vacation.Name = "bt_vacation";
            this.bt_vacation.Rounded = true;
            this.bt_vacation.Size = new System.Drawing.Size(146, 40);
            this.bt_vacation.TabIndex = 7;
            this.bt_vacation.Text = "Urlaub eintragen";
            this.bt_vacation.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(252)))), ((int)(((byte)(255)))));
            this.bt_vacation.Click += new System.EventHandler(this.bt_vacation_clicked);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(43)))));
            this.btnClose.Font = new System.Drawing.Font("Marlett", 14F);
            this.btnClose.Form = this;
            this.btnClose.Location = new System.Drawing.Point(479, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(18, 18);
            this.btnClose.TabIndex = 3;
            this.btnClose.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(95)))), ((int)(((byte)(98)))));
            // 
            // customMini1
            // 
            this.customMini1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.customMini1.BackColor = System.Drawing.Color.White;
            this.customMini1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(43)))));
            this.customMini1.Font = new System.Drawing.Font("Marlett", 14F);
            this.customMini1.Location = new System.Drawing.Point(458, 4);
            this.customMini1.Name = "customMini1";
            this.customMini1.Size = new System.Drawing.Size(18, 18);
            this.customMini1.TabIndex = 2;
            this.customMini1.Text = "customMini1";
            this.customMini1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(203)))), ((int)(((byte)(31)))));
            // 
            // bt_addEntry
            // 
            this.bt_addEntry.BackColor = System.Drawing.Color.Transparent;
            this.bt_addEntry.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(96)))), ((int)(((byte)(253)))));
            this.bt_addEntry.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_addEntry.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_addEntry.Location = new System.Drawing.Point(12, 412);
            this.bt_addEntry.Name = "bt_addEntry";
            this.bt_addEntry.Rounded = true;
            this.bt_addEntry.Size = new System.Drawing.Size(146, 40);
            this.bt_addEntry.TabIndex = 0;
            this.bt_addEntry.Text = "Anwesenheit eintragen";
            this.bt_addEntry.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(252)))), ((int)(((byte)(255)))));
            this.bt_addEntry.Click += new System.EventHandler(this.bt_addEntry_clicked);
            // 
            // form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 475);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.formSkin);
            this.Font = new System.Drawing.Font("Bahnschrift SemiBold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(502, 475);
            this.MinimumSize = new System.Drawing.Size(502, 475);
            this.Name = "form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GFN Anwesenheitsrechner";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.Load += new System.EventHandler(this.form_Main_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.formSkin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomUI.CustomButton2 bt_addEntry;
        private CustomUI.CustomGroupBox panel1;
        private CustomUI.CustomLabel stat_total_pre;
        private CustomUI.CustomLabel label10;
        private CustomUI.CustomLabel stat_total_ho;
        private CustomUI.CustomLabel label8;
        private CustomUI.CustomLabel label7;
        private CustomUI.CustomLabel label6;
        private CustomUI.CustomLabel label5;
        private CustomUI.CustomLabel label4;
        private CustomUI.CustomButton2 bt_vacation;
        private CustomUI.CustomButton2 bt_settings;
        private CustomUI.CustomSkin formSkin;
        private CustomUI.CustomClose btnClose;
        private CustomUI.CustomMini customMini1;
        private System.Windows.Forms.DataGridView listView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Datum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Standort;
        private System.Windows.Forms.DataGridViewTextBoxColumn sickdays;
    }
}

