namespace KPL
{
    partial class Authorization
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
            this.BTNlogin = new System.Windows.Forms.Button();
            this.TBnameUser = new System.Windows.Forms.TextBox();
            this.TBpasswordUser = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.viewPassword = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // BTNlogin
            // 
            this.BTNlogin.Location = new System.Drawing.Point(49, 198);
            this.BTNlogin.Name = "BTNlogin";
            this.BTNlogin.Size = new System.Drawing.Size(75, 23);
            this.BTNlogin.TabIndex = 2;
            this.BTNlogin.Text = "Вход";
            this.BTNlogin.UseVisualStyleBackColor = true;
            this.BTNlogin.Click += new System.EventHandler(this.BTNlogin_Click);
            // 
            // TBnameUser
            // 
            this.TBnameUser.Location = new System.Drawing.Point(108, 97);
            this.TBnameUser.Name = "TBnameUser";
            this.TBnameUser.Size = new System.Drawing.Size(100, 20);
            this.TBnameUser.TabIndex = 0;
            // 
            // TBpasswordUser
            // 
            this.TBpasswordUser.Location = new System.Drawing.Point(108, 123);
            this.TBpasswordUser.Name = "TBpasswordUser";
            this.TBpasswordUser.Size = new System.Drawing.Size(100, 20);
            this.TBpasswordUser.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Логин";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Пароль";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(230, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(9, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "l";
            // 
            // viewPassword
            // 
            this.viewPassword.AutoSize = true;
            this.viewPassword.Location = new System.Drawing.Point(108, 151);
            this.viewPassword.Name = "viewPassword";
            this.viewPassword.Size = new System.Drawing.Size(116, 17);
            this.viewPassword.TabIndex = 6;
            this.viewPassword.Text = "Просмотр пароля";
            this.viewPassword.UseVisualStyleBackColor = true;
            this.viewPassword.CheckedChanged += new System.EventHandler(this.viewPassword_CheckedChanged);
            // 
            // Authorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 229);
            this.Controls.Add(this.viewPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TBpasswordUser);
            this.Controls.Add(this.TBnameUser);
            this.Controls.Add(this.BTNlogin);
            this.Name = "Authorization";
            this.Text = "Авторизация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTNlogin;
        private System.Windows.Forms.TextBox TBnameUser;
        private System.Windows.Forms.TextBox TBpasswordUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox viewPassword;
    }
}