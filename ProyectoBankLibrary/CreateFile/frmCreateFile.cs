using BankLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateFile
{
    public partial class frmCreateFile : BankUIForm
    {
        private FileRepository? _fileRepository;
        public frmCreateFile()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult result;
            string fileName;

            using (var fileChooser = new SaveFileDialog())
            {
                fileChooser.CheckFileExists = false;
                result = fileChooser.ShowDialog();
                fileName = fileChooser.FileName;
            }

            if (result == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(fileName))
                {
                    MessageBox.Show("Nombre de archivo invalido",
                        "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        _fileRepository = new FileRepository(fileName);
                        _fileRepository?.OpenOrCreateFile();

                        btnSave.Enabled = false;
                        btnEnter.Enabled = true;
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show(ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            string[] values = GetTextBoxValues();

            if (!string.IsNullOrEmpty(values[(int)TextBoxIndices.Account]))
            {
                try
                {
                    int accountNumber =
                        int.Parse(values[(int)TextBoxIndices.Account]);

                    if (accountNumber > 0)
                    {
                        var record = new Record(accountNumber,
                            values[(int)TextBoxIndices.First],
                            values[(int)TextBoxIndices.Last],
                            decimal.Parse(values[(int)TextBoxIndices.Balance]));

                        _fileRepository?.WriteRecordToFile(record);
                    }
                    else
                    {
                        MessageBox.Show("Numero de cuenta invalido", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Formato Invalido", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            ClearTextBoxes();
        }

        private void ClearTextBoxes()
        {
            foreach (var c in this.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Text = "";
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                _fileRepository?.CloseFile();
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Application.Exit();
        }

        private void frmCreateFile_Load(object sender, EventArgs e)
        {

        }
    }
}
