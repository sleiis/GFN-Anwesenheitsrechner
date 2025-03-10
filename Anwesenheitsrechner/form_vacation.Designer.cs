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
            this.customSkin1 = new Anwesenheitsrechner.CustomUI.CustomSkin();
            this.customButton2 = new Anwesenheitsrechner.CustomUI.CustomButton();
            this.customButton1 = new Anwesenheitsrechner.CustomUI.CustomButton();
            this.mc_dateselect = new System.Windows.Forms.MonthCalendar();
            this.label1 = new Anwesenheitsrechner.CustomUI.CustomLabel();
            this.btnClose = new Anwesenheitsrechner.CustomUI.CustomClose();
            this.customSkin1.SuspendLayout();
            this.SuspendLayout();
            // 
            // customSkin1
            // 
            this.customSkin1.BackColor = System.Drawing.Color.White;
            this.customSkin1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(30)))), ((int)(((byte)(59)))));
            this.customSkin1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(58)))), ((int)(((byte)(60)))));
            this.customSkin1.Controls.Add(this.btnClose);
            this.customSkin1.Controls.Add(this.customButton2);
            this.customSkin1.Controls.Add(this.customButton1);
            this.customSkin1.Controls.Add(this.mc_dateselect);
            this.customSkin1.Controls.Add(this.label1);
            this.customSkin1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customSkin1.FlatColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(96)))), ((int)(((byte)(253)))));
            this.customSkin1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.customSkin1.HeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(43)))));
            this.customSkin1.HeaderMaximize = false;
            this.customSkin1.Location = new System.Drawing.Point(0, 0);
            this.customSkin1.Name = "customSkin1";
            this.customSkin1.Size = new System.Drawing.Size(305, 288);
            this.customSkin1.TabIndex = 13;
            this.customSkin1.Text = "Urlaub";
            // 
            // customButton2
            // 
            this.customButton2.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.customButton2.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.customButton2.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.customButton2.BorderRadius = 0;
            this.customButton2.BorderSize = 0;
            this.customButton2.FlatAppearance.BorderSize = 0;
            this.customButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.customButton2.ForeColor = System.Drawing.Color.White;
            this.customButton2.Location = new System.Drawing.Point(15, 237);
            this.customButton2.Name = "customButton2";
            this.customButton2.NotificationCount = 0;
            this.customButton2.Size = new System.Drawing.Size(130, 40);
            this.customButton2.TabIndex = 14;
            this.customButton2.Text = "customButton2";
            this.customButton2.TextColor = System.Drawing.Color.White;
            this.customButton2.UseVisualStyleBackColor = false;
            // 
            // customButton1
            // 
            this.customButton1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.customButton1.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.customButton1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.customButton1.BorderRadius = 0;
            this.customButton1.BorderSize = 0;
            this.customButton1.FlatAppearance.BorderSize = 0;
            this.customButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.customButton1.ForeColor = System.Drawing.Color.White;
            this.customButton1.Location = new System.Drawing.Point(163, 237);
            this.customButton1.Name = "customButton1";
            this.customButton1.NotificationCount = 0;
            this.customButton1.Size = new System.Drawing.Size(130, 40);
            this.customButton1.TabIndex = 13;
            this.customButton1.TextColor = System.Drawing.Color.White;
            this.customButton1.UseVisualStyleBackColor = false;
            // 
            // mc_dateselect
            // 
            this.mc_dateselect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(30)))), ((int)(((byte)(59)))));
            this.mc_dateselect.Location = new System.Drawing.Point(100, 63);
            this.mc_dateselect.MaxSelectionCount = 14;
            this.mc_dateselect.MinDate = new System.DateTime(2024, 1, 1, 0, 0, 0, 0);
            this.mc_dateselect.Name = "mc_dateselect";
            this.mc_dateselect.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Datum: ";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(43)))));
            this.btnClose.Font = new System.Drawing.Font("Marlett", 14F);
            this.btnClose.Form = this;
            this.btnClose.Location = new System.Drawing.Point(280, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(18, 18);
            this.btnClose.TabIndex = 15;
            this.btnClose.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(95)))), ((int)(((byte)(98)))));
            // 
            // form_vacation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 288);
            this.Controls.Add(this.customSkin1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(305, 288);
            this.MinimumSize = new System.Drawing.Size(305, 288);
            this.Name = "form_vacation";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Urlaub eintragen";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.customSkin1.ResumeLayout(false);
            this.customSkin1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar mc_dateselect;
        private CustomUI.CustomLabel label1;
        private CustomUI.CustomSkin customSkin1;
        private CustomUI.CustomButton bt_cancel;
        private CustomUI.CustomButton customButton2;
        private CustomUI.CustomButton customButton1;
        private CustomUI.CustomClose btnClose;
    }
}