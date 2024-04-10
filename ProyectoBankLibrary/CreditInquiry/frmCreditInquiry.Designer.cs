namespace CreditInquiry
{
    partial class frmCreditInquiry
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
            txtDisplay = new TextBox();
            btnOpen = new Button();
            btnCredit = new Button();
            btnDebit = new Button();
            btnZero = new Button();
            btnExit = new Button();
            SuspendLayout();
            // 
            // txtDisplay
            // 
            txtDisplay.Location = new Point(12, 12);
            txtDisplay.Multiline = true;
            txtDisplay.Name = "txtDisplay";
            txtDisplay.Size = new Size(529, 201);
            txtDisplay.TabIndex = 0;
            // 
            // btnOpen
            // 
            btnOpen.Location = new Point(12, 232);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(101, 41);
            btnOpen.TabIndex = 1;
            btnOpen.Text = "Abrir archivo";
            btnOpen.UseVisualStyleBackColor = true;
            btnOpen.Click += btnOpen_Click;
            // 
            // btnCredit
            // 
            btnCredit.Enabled = false;
            btnCredit.Location = new Point(119, 232);
            btnCredit.Name = "btnCredit";
            btnCredit.Size = new Size(101, 41);
            btnCredit.TabIndex = 2;
            btnCredit.Text = "Saldos con credito";
            btnCredit.UseVisualStyleBackColor = true;
            btnCredit.Click += getBalances_Click;
            // 
            // btnDebit
            // 
            btnDebit.Enabled = false;
            btnDebit.Location = new Point(226, 232);
            btnDebit.Name = "btnDebit";
            btnDebit.Size = new Size(101, 41);
            btnDebit.TabIndex = 3;
            btnDebit.Text = "Saldos con debito";
            btnDebit.UseVisualStyleBackColor = true;
            btnDebit.Click += getBalances_Click;
            // 
            // btnZero
            // 
            btnZero.Enabled = false;
            btnZero.Location = new Point(333, 232);
            btnZero.Name = "btnZero";
            btnZero.Size = new Size(101, 41);
            btnZero.TabIndex = 4;
            btnZero.Text = "Saldos en cero";
            btnZero.UseVisualStyleBackColor = true;
            btnZero.Click += getBalances_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(440, 232);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(101, 41);
            btnExit.TabIndex = 5;
            btnExit.Text = "Salir";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // frmCreditInquiry
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(557, 292);
            Controls.Add(btnExit);
            Controls.Add(btnZero);
            Controls.Add(btnDebit);
            Controls.Add(btnCredit);
            Controls.Add(btnOpen);
            Controls.Add(txtDisplay);
            Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Name = "frmCreditInquiry";
            Text = "CONSULTA DE CREDITO";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtDisplay;
        private Button btnOpen;
        private Button btnCredit;
        private Button btnDebit;
        private Button btnZero;
        private Button btnExit;
    }
}