
namespace MasterMech
{
    partial class UserPasswordChange
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
            this.lblCurrPass = new System.Windows.Forms.Label();
            this.txtCurrentPass = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblNewPass = new System.Windows.Forms.Label();
            this.lblConNewPass = new System.Windows.Forms.Label();
            this.txtNewPass = new System.Windows.Forms.TextBox();
            this.txtConfirmNPass = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCurrPass
            // 
            this.lblCurrPass.AutoSize = true;
            this.lblCurrPass.Location = new System.Drawing.Point(68, 52);
            this.lblCurrPass.Name = "lblCurrPass";
            this.lblCurrPass.Size = new System.Drawing.Size(135, 20);
            this.lblCurrPass.TabIndex = 0;
            this.lblCurrPass.Text = "Current Password";
            // 
            // txtCurrentPass
            // 
            this.txtCurrentPass.Location = new System.Drawing.Point(292, 49);
            this.txtCurrentPass.Name = "txtCurrentPass";
            this.txtCurrentPass.Size = new System.Drawing.Size(349, 26);
            this.txtCurrentPass.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(452, 229);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblNewPass
            // 
            this.lblNewPass.AutoSize = true;
            this.lblNewPass.Location = new System.Drawing.Point(68, 107);
            this.lblNewPass.Name = "lblNewPass";
            this.lblNewPass.Size = new System.Drawing.Size(113, 20);
            this.lblNewPass.TabIndex = 3;
            this.lblNewPass.Text = "New Password";
            // 
            // lblConNewPass
            // 
            this.lblConNewPass.AutoSize = true;
            this.lblConNewPass.Location = new System.Drawing.Point(68, 164);
            this.lblConNewPass.Name = "lblConNewPass";
            this.lblConNewPass.Size = new System.Drawing.Size(172, 20);
            this.lblConNewPass.TabIndex = 4;
            this.lblConNewPass.Text = "Confirm New Password";
            // 
            // txtNewPass
            // 
            this.txtNewPass.Location = new System.Drawing.Point(292, 104);
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.Size = new System.Drawing.Size(349, 26);
            this.txtNewPass.TabIndex = 5;
            // 
            // txtConfirmNPass
            // 
            this.txtConfirmNPass.Location = new System.Drawing.Point(292, 161);
            this.txtConfirmNPass.Name = "txtConfirmNPass";
            this.txtConfirmNPass.Size = new System.Drawing.Size(349, 26);
            this.txtConfirmNPass.TabIndex = 6;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(566, 229);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // UserPasswordChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(729, 302);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtConfirmNPass);
            this.Controls.Add(this.txtNewPass);
            this.Controls.Add(this.lblConNewPass);
            this.Controls.Add(this.lblNewPass);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtCurrentPass);
            this.Controls.Add(this.lblCurrPass);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserPasswordChange";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserPasswordChange";
            this.Load += new System.EventHandler(this.UserPasswordChange_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCurrPass;
        private System.Windows.Forms.TextBox txtCurrentPass;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblNewPass;
        private System.Windows.Forms.Label lblConNewPass;
        private System.Windows.Forms.TextBox txtNewPass;
        private System.Windows.Forms.TextBox txtConfirmNPass;
        private System.Windows.Forms.Button btnCancel;
    }
}