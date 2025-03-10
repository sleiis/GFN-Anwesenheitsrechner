namespace Anwesenheitsrechner
{
    partial class form_Settings
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
            this.l_language = new System.Windows.Forms.Label();
            this.cb_language = new System.Windows.Forms.ComboBox();
            this.tb_websiteparse = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_parse = new System.Windows.Forms.Button();
            this.bt_save = new System.Windows.Forms.Button();
            this.bt_cancel = new System.Windows.Forms.Button();
            this.rb_web = new System.Windows.Forms.RadioButton();
            this.rb_php = new System.Windows.Forms.RadioButton();
            this.bt_cleardb = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // l_language
            // 
            this.l_language.AutoSize = true;
            this.l_language.Location = new System.Drawing.Point(12, 16);
            this.l_language.Name = "l_language";
            this.l_language.Size = new System.Drawing.Size(50, 13);
            this.l_language.TabIndex = 0;
            this.l_language.Text = "Sprache:";
            // 
            // cb_language
            // 
            this.cb_language.FormattingEnabled = true;
            this.cb_language.Items.AddRange(new object[] {
            "Deutsch"});
            this.cb_language.Location = new System.Drawing.Point(79, 13);
            this.cb_language.Name = "cb_language";
            this.cb_language.Size = new System.Drawing.Size(340, 21);
            this.cb_language.TabIndex = 1;
            // 
            // tb_websiteparse
            // 
            this.tb_websiteparse.Location = new System.Drawing.Point(15, 117);
            this.tb_websiteparse.Name = "tb_websiteparse";
            this.tb_websiteparse.Size = new System.Drawing.Size(403, 157);
            this.tb_websiteparse.TabIndex = 2;
            this.tb_websiteparse.Text = "";
            this.tb_websiteparse.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Parsen der Einträge von der Website";
            // 
            // bt_parse
            // 
            this.bt_parse.Location = new System.Drawing.Point(15, 280);
            this.bt_parse.Name = "bt_parse";
            this.bt_parse.Size = new System.Drawing.Size(403, 23);
            this.bt_parse.TabIndex = 4;
            this.bt_parse.Text = "Parse";
            this.bt_parse.UseVisualStyleBackColor = true;
            this.bt_parse.Click += new System.EventHandler(this.bt_parse_clicked);
            // 
            // bt_save
            // 
            this.bt_save.Location = new System.Drawing.Point(262, 53);
            this.bt_save.Name = "bt_save";
            this.bt_save.Size = new System.Drawing.Size(75, 23);
            this.bt_save.TabIndex = 5;
            this.bt_save.Text = "Speichern";
            this.bt_save.UseVisualStyleBackColor = true;
            this.bt_save.Click += new System.EventHandler(this.bt_save_clicked);
            // 
            // bt_cancel
            // 
            this.bt_cancel.Location = new System.Drawing.Point(343, 53);
            this.bt_cancel.Name = "bt_cancel";
            this.bt_cancel.Size = new System.Drawing.Size(75, 23);
            this.bt_cancel.TabIndex = 6;
            this.bt_cancel.Text = "Abbrechen";
            this.bt_cancel.UseVisualStyleBackColor = true;
            this.bt_cancel.Click += new System.EventHandler(this.bt_cancel_clicked);
            // 
            // rb_web
            // 
            this.rb_web.AutoSize = true;
            this.rb_web.Checked = true;
            this.rb_web.Location = new System.Drawing.Point(219, 91);
            this.rb_web.Name = "rb_web";
            this.rb_web.Size = new System.Drawing.Size(48, 17);
            this.rb_web.TabIndex = 7;
            this.rb_web.TabStop = true;
            this.rb_web.Text = "Web";
            this.rb_web.UseVisualStyleBackColor = true;
            this.rb_web.CheckedChanged += new System.EventHandler(this.rb_changed);
            // 
            // rb_php
            // 
            this.rb_php.AutoSize = true;
            this.rb_php.Location = new System.Drawing.Point(311, 91);
            this.rb_php.Name = "rb_php";
            this.rb_php.Size = new System.Drawing.Size(47, 17);
            this.rb_php.TabIndex = 8;
            this.rb_php.Text = "PHP";
            this.rb_php.UseVisualStyleBackColor = true;
            this.rb_php.CheckedChanged += new System.EventHandler(this.rb_changed);
            // 
            // bt_cleardb
            // 
            this.bt_cleardb.Location = new System.Drawing.Point(15, 52);
            this.bt_cleardb.Name = "bt_cleardb";
            this.bt_cleardb.Size = new System.Drawing.Size(99, 23);
            this.bt_cleardb.TabIndex = 9;
            this.bt_cleardb.Text = "Database leeren";
            this.bt_cleardb.UseVisualStyleBackColor = true;
            this.bt_cleardb.Click += new System.EventHandler(this.bt_cleardb_clicked);
            // 
            // form_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 313);
            this.Controls.Add(this.bt_cleardb);
            this.Controls.Add(this.rb_php);
            this.Controls.Add(this.rb_web);
            this.Controls.Add(this.bt_cancel);
            this.Controls.Add(this.bt_save);
            this.Controls.Add(this.bt_parse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_websiteparse);
            this.Controls.Add(this.cb_language);
            this.Controls.Add(this.l_language);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(447, 352);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(447, 352);
            this.Name = "form_Settings";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Einstellungen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label l_language;
        private System.Windows.Forms.ComboBox cb_language;
        private System.Windows.Forms.RichTextBox tb_websiteparse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_parse;
        private System.Windows.Forms.Button bt_save;
        private System.Windows.Forms.Button bt_cancel;
        private System.Windows.Forms.RadioButton rb_web;
        private System.Windows.Forms.RadioButton rb_php;
        private System.Windows.Forms.Button bt_cleardb;
    }
}