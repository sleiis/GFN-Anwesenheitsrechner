namespace Anwesenheitsrechner
{
    partial class form_addedit
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
            this.label1 = new System.Windows.Forms.Label();
            this.bt_add = new System.Windows.Forms.Button();
            this.bt_cancel = new System.Windows.Forms.Button();
            this.mc_dateselect = new System.Windows.Forms.MonthCalendar();
            this.label2 = new System.Windows.Forms.Label();
            this.rb_pre = new System.Windows.Forms.RadioButton();
            this.rb_ho = new System.Windows.Forms.RadioButton();
            this.cb_sickday = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Datum: ";
            // 
            // bt_add
            // 
            this.bt_add.Location = new System.Drawing.Point(12, 305);
            this.bt_add.Name = "bt_add";
            this.bt_add.Size = new System.Drawing.Size(88, 23);
            this.bt_add.TabIndex = 4;
            this.bt_add.Text = "Hinzufügen";
            this.bt_add.UseVisualStyleBackColor = true;
            this.bt_add.Click += new System.EventHandler(this.bt_add_clicked);
            // 
            // bt_cancel
            // 
            this.bt_cancel.Location = new System.Drawing.Point(156, 305);
            this.bt_cancel.Name = "bt_cancel";
            this.bt_cancel.Size = new System.Drawing.Size(101, 23);
            this.bt_cancel.TabIndex = 5;
            this.bt_cancel.Text = "Abbrechen";
            this.bt_cancel.UseVisualStyleBackColor = true;
            this.bt_cancel.Click += new System.EventHandler(this.bt_cancel_clicked);
            // 
            // mc_dateselect
            // 
            this.mc_dateselect.BackColor = System.Drawing.SystemColors.Control;
            this.mc_dateselect.Location = new System.Drawing.Point(79, 51);
            this.mc_dateselect.MaxSelectionCount = 1;
            this.mc_dateselect.MinDate = new System.DateTime(2024, 1, 1, 0, 0, 0, 0);
            this.mc_dateselect.Name = "mc_dateselect";
            this.mc_dateselect.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 253);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Arbeitsort: ";
            // 
            // rb_pre
            // 
            this.rb_pre.AutoSize = true;
            this.rb_pre.Checked = true;
            this.rb_pre.Location = new System.Drawing.Point(102, 241);
            this.rb_pre.Name = "rb_pre";
            this.rb_pre.Size = new System.Drawing.Size(65, 17);
            this.rb_pre.TabIndex = 7;
            this.rb_pre.TabStop = true;
            this.rb_pre.Text = "Standort";
            this.rb_pre.UseVisualStyleBackColor = true;
            this.rb_pre.CheckedChanged += new System.EventHandler(this.rb_Location_changed);
            // 
            // rb_ho
            // 
            this.rb_ho.AutoSize = true;
            this.rb_ho.Location = new System.Drawing.Point(102, 265);
            this.rb_ho.Name = "rb_ho";
            this.rb_ho.Size = new System.Drawing.Size(84, 17);
            this.rb_ho.TabIndex = 8;
            this.rb_ho.TabStop = true;
            this.rb_ho.Text = "Home-Office";
            this.rb_ho.UseVisualStyleBackColor = true;
            this.rb_ho.CheckedChanged += new System.EventHandler(this.rb_Location_changed);
            // 
            // cb_sickday
            // 
            this.cb_sickday.AutoSize = true;
            this.cb_sickday.Location = new System.Drawing.Point(26, 17);
            this.cb_sickday.Name = "cb_sickday";
            this.cb_sickday.Size = new System.Drawing.Size(97, 17);
            this.cb_sickday.TabIndex = 9;
            this.cb_sickday.Text = "Krankheitstag?";
            this.cb_sickday.UseVisualStyleBackColor = true;
            this.cb_sickday.CheckedChanged += new System.EventHandler(this.changed_sickday);
            // 
            // form_addedit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 347);
            this.ControlBox = false;
            this.Controls.Add(this.cb_sickday);
            this.Controls.Add(this.rb_ho);
            this.Controls.Add(this.rb_pre);
            this.Controls.Add(this.mc_dateselect);
            this.Controls.Add(this.bt_cancel);
            this.Controls.Add(this.bt_add);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(291, 386);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(291, 386);
            this.Name = "form_addedit";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Eintrag hinzufügen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_add;
        private System.Windows.Forms.Button bt_cancel;
        private System.Windows.Forms.MonthCalendar mc_dateselect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rb_pre;
        private System.Windows.Forms.RadioButton rb_ho;
        private System.Windows.Forms.CheckBox cb_sickday;

    }
}