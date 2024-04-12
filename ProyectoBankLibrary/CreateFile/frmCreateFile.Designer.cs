
namespace CreateFile
{
    partial class frmCreateFile
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
            btnSave = new Button();
            btnEnter = new Button();
            btnExit = new Button();
            btnSerializarJson = new Button();
            btnserializarXml = new Button();
            btnDeserializarJson = new Button();
            btnDeserializarXml = new Button();
            dgvDeserializar = new DataGridView();
            ClmNombre = new DataGridViewTextBoxColumn();
            clmPrimerNombre = new DataGridViewTextBoxColumn();
            clmApellido = new DataGridViewTextBoxColumn();
            clmSaldo = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvDeserializar).BeginInit();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Location = new Point(13, 481);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(256, 34);
            btnSave.TabIndex = 8;
            btnSave.Text = "Guardar como";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnEnter
            // 
            btnEnter.Location = new Point(275, 401);
            btnEnter.Name = "btnEnter";
            btnEnter.Size = new Size(180, 74);
            btnEnter.TabIndex = 9;
            btnEnter.Text = "Ingresar";
            btnEnter.UseVisualStyleBackColor = true;
            btnEnter.Click += btnEnter_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(275, 481);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(180, 34);
            btnExit.TabIndex = 10;
            btnExit.Text = "Salir";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnSerializarJson
            // 
            btnSerializarJson.Location = new Point(13, 401);
            btnSerializarJson.Name = "btnSerializarJson";
            btnSerializarJson.Size = new Size(115, 34);
            btnSerializarJson.TabIndex = 11;
            btnSerializarJson.Text = "Serializar Json";
            btnSerializarJson.UseVisualStyleBackColor = true;
            btnSerializarJson.Click += btnSerializarJson_Click;
            // 
            // btnserializarXml
            // 
            btnserializarXml.Location = new Point(13, 441);
            btnserializarXml.Name = "btnserializarXml";
            btnserializarXml.Size = new Size(115, 34);
            btnserializarXml.TabIndex = 12;
            btnserializarXml.Text = "Serializar Xml ";
            btnserializarXml.UseVisualStyleBackColor = true;
            btnserializarXml.Click += btnserializarXml_Click;
            // 
            // btnDeserializarJson
            // 
            btnDeserializarJson.Location = new Point(134, 401);
            btnDeserializarJson.Name = "btnDeserializarJson";
            btnDeserializarJson.Size = new Size(135, 34);
            btnDeserializarJson.TabIndex = 13;
            btnDeserializarJson.Text = "Deserializar Json";
            btnDeserializarJson.UseVisualStyleBackColor = true;
            btnDeserializarJson.Click += btnDeserializarJson_Click;
            // 
            // btnDeserializarXml
            // 
            btnDeserializarXml.Location = new Point(134, 441);
            btnDeserializarXml.Name = "btnDeserializarXml";
            btnDeserializarXml.Size = new Size(135, 34);
            btnDeserializarXml.TabIndex = 14;
            btnDeserializarXml.Text = "Deserializar Xml";
            btnDeserializarXml.UseVisualStyleBackColor = true;
            btnDeserializarXml.Click += btnDeserializarXml_Click;
            // 
            // dgvDeserializar
            // 
            dgvDeserializar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDeserializar.Columns.AddRange(new DataGridViewColumn[] { ClmNombre, clmPrimerNombre, clmApellido, clmSaldo });
            dgvDeserializar.Location = new Point(13, 151);
            dgvDeserializar.Name = "dgvDeserializar";
            dgvDeserializar.Size = new Size(442, 244);
            dgvDeserializar.TabIndex = 15;
            // 
            // ClmNombre
            // 
            ClmNombre.HeaderText = "Cuenta";
            ClmNombre.Name = "ClmNombre";
            // 
            // clmPrimerNombre
            // 
            clmPrimerNombre.HeaderText = "Primer Nombre";
            clmPrimerNombre.Name = "clmPrimerNombre";
            // 
            // clmApellido
            // 
            clmApellido.HeaderText = "Apellido";
            clmApellido.Name = "clmApellido";
            // 
            // clmSaldo
            // 
            clmSaldo.HeaderText = "Saldo";
            clmSaldo.Name = "clmSaldo";
            // 
            // frmCreateFile
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(467, 527);
            Controls.Add(dgvDeserializar);
            Controls.Add(btnDeserializarXml);
            Controls.Add(btnDeserializarJson);
            Controls.Add(btnserializarXml);
            Controls.Add(btnSerializarJson);
            Controls.Add(btnExit);
            Controls.Add(btnEnter);
            Controls.Add(btnSave);
            Name = "frmCreateFile";
            Text = "frmCreateFile";
            Load += frmCreateFile_Load;
            Controls.SetChildIndex(txtAccount, 0);
            Controls.SetChildIndex(txtFirstName, 0);
            Controls.SetChildIndex(txtLastName, 0);
            Controls.SetChildIndex(txtBalance, 0);
            Controls.SetChildIndex(btnSave, 0);
            Controls.SetChildIndex(btnEnter, 0);
            Controls.SetChildIndex(btnExit, 0);
            Controls.SetChildIndex(btnSerializarJson, 0);
            Controls.SetChildIndex(btnserializarXml, 0);
            Controls.SetChildIndex(btnDeserializarJson, 0);
            Controls.SetChildIndex(btnDeserializarXml, 0);
            Controls.SetChildIndex(dgvDeserializar, 0);
            ((System.ComponentModel.ISupportInitialize)dgvDeserializar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private Button btnSave;
        private Button btnEnter;
        private Button btnExit;
        private Button btnSerializarJson;
        private Button btnserializarXml;
        private Button btnDeserializarJson;
        private Button btnDeserializarXml;
        private DataGridView dgvDeserializar;
        private DataGridViewTextBoxColumn ClmNombre;
        private DataGridViewTextBoxColumn clmPrimerNombre;
        private DataGridViewTextBoxColumn clmApellido;
        private DataGridViewTextBoxColumn clmSaldo;
    }
}