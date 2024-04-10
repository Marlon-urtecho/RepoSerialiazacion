namespace ReadSequentialAccessFile
{
    partial class frmReadSequentialAccessFile
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
            btnOpen = new Button();
            btnNext = new Button();
            SuspendLayout();
            // 
            // btnOpen
            // 
            btnOpen.Location = new Point(12, 160);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(211, 34);
            btnOpen.TabIndex = 8;
            btnOpen.Text = "Abrir Archivo";
            btnOpen.UseVisualStyleBackColor = true;
            btnOpen.Click += btnOpen_Click;
            // 
            // btnNext
            // 
            btnNext.Enabled = false;
            btnNext.Location = new Point(244, 160);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(211, 34);
            btnNext.TabIndex = 9;
            btnNext.Text = "Siguiente Registro";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // frmReadSequentialAccessFile
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(473, 212);
            Controls.Add(btnNext);
            Controls.Add(btnOpen);
            Name = "frmReadSequentialAccessFile";
            Text = "frmReadSequentialAccessFile";
            Controls.SetChildIndex(btnOpen, 0);
            Controls.SetChildIndex(btnNext, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnOpen;
        private Button btnNext;
    }
}