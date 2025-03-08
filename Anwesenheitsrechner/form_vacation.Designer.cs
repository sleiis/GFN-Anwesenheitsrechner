namespace Anwesenheitsrechner
{
    partial class form_vacation
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
            this.mc_dateselect = new System.Windows.Forms.MonthCalendar();
            this.bt_cancel = new System.Windows.Forms.Button();
            this.bt_add = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mc_dateselect
            // 
            this.mc_dateselect.BackColor = System.Drawing.SystemColors.Control;
            this.mc_dateselect.Location = new System.Drawing.Point(89, 18);
            this.mc_dateselect.MaxSelectionCount = 14;
            this.mc_dateselect.MinDate = new System.DateTime(2024, 1, 1, 0, 0, 0, 0);
            this.mc_dateselect.Name = "mc_dateselect";
            this.mc_dateselect.TabIndex = 12;
            // 
            // bt_cancel
            // 
            this.bt_cancel.Location = new System.Drawing.Point(166, 201);
            this.bt_cancel.Name = "bt_cancel";
            this.bt_cancel.Size = new System.Drawing.Size(101, 23);
            this.bt_cancel.TabIndex = 11;
            this.bt_cancel.Text = "Abbrechen";
            this.bt_cancel.UseVisualStyleBackColor = true;
            this.bt_cancel.Click += new System.EventHandler(this.Button2_clicked);
            // 
            // bt_add
            // 
            this.bt_add.Location = new System.Drawing.Point(22, 201);
            this.bt_add.Name = "bt_add";
            this.bt_add.Size = new System.Drawing.Size(88, 23);
            this.bt_add.TabIndex = 10;
            this.bt_add.Text = "Hinzufügen";
            this.bt_add.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Datum: ";
            // 
            // form_vacation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 249);
            this.Controls.Add(this.mc_dateselect);
            this.Controls.Add(this.bt_cancel);
            this.Controls.Add(this.bt_add);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "form_vacation";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Urlaub eintragen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar mc_dateselect;
        private System.Windows.Forms.Button bt_cancel;
        private System.Windows.Forms.Button bt_add;
        private System.Windows.Forms.Label label1;
    }
}