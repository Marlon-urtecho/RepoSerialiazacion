namespace BankLibrary
{
    partial class BankUIForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtAccount = new TextBox();
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            txtBalance = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 9);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(73, 19);
            label1.TabIndex = 0;
            label1.Text = "CUENTA";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 49);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(151, 19);
            label2.TabIndex = 1;
            label2.Text = "PRIMER NOMBRE";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 82);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(167, 19);
            label3.TabIndex = 2;
            label3.Text = "APELLIDO PATERNO";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 121);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(63, 19);
            label4.TabIndex = 3;
            label4.Text = "SALDO";
            // 
            // txtAccount
            // 
            txtAccount.Location = new Point(212, 6);
            txtAccount.Margin = new Padding(4, 4, 4, 4);
            txtAccount.Name = "txtAccount";
            txtAccount.Size = new Size(243, 26);
            txtAccount.TabIndex = 4;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(212, 46);
            txtFirstName.Margin = new Padding(4, 4, 4, 4);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(243, 26);
            txtFirstName.TabIndex = 5;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(212, 79);
            txtLastName.Margin = new Padding(4, 4, 4, 4);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(243, 26);
            txtLastName.TabIndex = 6;
            // 
            // txtBalance
            // 
            txtBalance.Location = new Point(212, 118);
            txtBalance.Margin = new Padding(4, 4, 4, 4);
            txtBalance.Name = "txtBalance";
            txtBalance.Size = new Size(243, 26);
            txtBalance.TabIndex = 7;
            // 
            // BankUIForm
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(473, 157);
            Controls.Add(txtBalance);
            Controls.Add(txtLastName);
            Controls.Add(txtFirstName);
            Controls.Add(txtAccount);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 4, 4, 4);
            Name = "BankUIForm";
            Text = "BankUIForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtAccount;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private TextBox txtBalance;
    }
}