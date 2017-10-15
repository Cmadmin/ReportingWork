namespace ReportingWork.Controls
{
    partial class ServerAndDbSelectorCtrl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.rdConnString = new System.Windows.Forms.RadioButton();
            this.rdConnStringWizard = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.txtCatalogue = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.ckIntegratedSecurity = new System.Windows.Forms.CheckBox();
            this.ckActiveResults = new System.Windows.Forms.CheckBox();
            this.ckPersistSecurityInfo = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Location = new System.Drawing.Point(216, 57);
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(748, 22);
            this.txtConnectionString.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Connection String";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Connection Wizard";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(216, 482);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 29);
            this.button1.TabIndex = 3;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rdConnString
            // 
            this.rdConnString.AutoSize = true;
            this.rdConnString.Location = new System.Drawing.Point(51, 60);
            this.rdConnString.Name = "rdConnString";
            this.rdConnString.Size = new System.Drawing.Size(17, 16);
            this.rdConnString.TabIndex = 4;
            this.rdConnString.TabStop = true;
            this.rdConnString.UseVisualStyleBackColor = true;
            this.rdConnString.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rdConnStringWizard
            // 
            this.rdConnStringWizard.AutoSize = true;
            this.rdConnStringWizard.Location = new System.Drawing.Point(51, 161);
            this.rdConnStringWizard.Name = "rdConnStringWizard";
            this.rdConnStringWizard.Size = new System.Drawing.Size(17, 16);
            this.rdConnStringWizard.TabIndex = 5;
            this.rdConnStringWizard.TabStop = true;
            this.rdConnStringWizard.UseVisualStyleBackColor = true;
            this.rdConnStringWizard.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(76, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Or";
            // 
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point(216, 188);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(331, 22);
            this.txtServerName.TabIndex = 7;
            // 
            // txtCatalogue
            // 
            this.txtCatalogue.Location = new System.Drawing.Point(216, 223);
            this.txtCatalogue.Name = "txtCatalogue";
            this.txtCatalogue.Size = new System.Drawing.Size(331, 22);
            this.txtCatalogue.TabIndex = 8;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(216, 383);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(198, 22);
            this.txtUserName.TabIndex = 9;
            // 
            // ckIntegratedSecurity
            // 
            this.ckIntegratedSecurity.AutoSize = true;
            this.ckIntegratedSecurity.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckIntegratedSecurity.Location = new System.Drawing.Point(216, 268);
            this.ckIntegratedSecurity.Name = "ckIntegratedSecurity";
            this.ckIntegratedSecurity.Size = new System.Drawing.Size(168, 21);
            this.ckIntegratedSecurity.TabIndex = 12;
            this.ckIntegratedSecurity.Text = "Integrated Security";
            this.ckIntegratedSecurity.UseVisualStyleBackColor = true;
            // 
            // ckActiveResults
            // 
            this.ckActiveResults.AutoSize = true;
            this.ckActiveResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckActiveResults.Location = new System.Drawing.Point(216, 308);
            this.ckActiveResults.Name = "ckActiveResults";
            this.ckActiveResults.Size = new System.Drawing.Size(215, 21);
            this.ckActiveResults.TabIndex = 13;
            this.ckActiveResults.Text = "Multiple Active Result Set";
            this.ckActiveResults.UseVisualStyleBackColor = true;
            // 
            // ckPersistSecurityInfo
            // 
            this.ckPersistSecurityInfo.AutoSize = true;
            this.ckPersistSecurityInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckPersistSecurityInfo.Location = new System.Drawing.Point(216, 345);
            this.ckPersistSecurityInfo.Name = "ckPersistSecurityInfo";
            this.ckPersistSecurityInfo.Size = new System.Drawing.Size(176, 21);
            this.ckPersistSecurityInfo.TabIndex = 14;
            this.ckPersistSecurityInfo.Text = "Persist Security Info";
            this.ckPersistSecurityInfo.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(102, 386);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "User Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(104, 424);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(216, 424);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(198, 22);
            this.txtPassword.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(104, 191);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 17);
            this.label6.TabIndex = 18;
            this.label6.Text = "Server";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(104, 226);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 17);
            this.label7.TabIndex = 19;
            this.label7.Text = "Database";
            // 
            // ServerAndDbSelectorCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ckPersistSecurityInfo);
            this.Controls.Add(this.ckActiveResults);
            this.Controls.Add(this.ckIntegratedSecurity);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.txtCatalogue);
            this.Controls.Add(this.txtServerName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rdConnStringWizard);
            this.Controls.Add(this.rdConnString);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtConnectionString);
            this.Name = "ServerAndDbSelectorCtrl";
            this.Size = new System.Drawing.Size(1126, 527);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton rdConnString;
        private System.Windows.Forms.RadioButton rdConnStringWizard;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtServerName;
        private System.Windows.Forms.TextBox txtCatalogue;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.CheckBox ckIntegratedSecurity;
        private System.Windows.Forms.CheckBox ckActiveResults;
        private System.Windows.Forms.CheckBox ckPersistSecurityInfo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}
