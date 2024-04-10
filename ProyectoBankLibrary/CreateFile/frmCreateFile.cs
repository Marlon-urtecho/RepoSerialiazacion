using BankLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateFile
{
    public partial class frmCreateFile : BankUIForm
    {
        private FileRepository? _fileRepository;

        List<Cliente> clientes = new List<Cliente>();

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
            Cliente cliente = new Cliente
            {

                cliente.firsName = txtFirstName.Text
                cliente.cuenta = txtAccount.Text
                cliente.LastName = txtLastName.Text
                cliente.saldo = txtBalance.Text

            };

            clientes.Add(cliente);

            
            btnserializarXml.Enabled = true;
            btnSerializarJson.Enabled = true;
            ClearTextBoxes();
            txtFirstName.Focus();


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

        private void btnSerializarJson_Click(object sender, EventArgs e)
        {
            // crea un cuadro de diálogo que permite al usuario guardar el archivo
            DialogResult result;
            string fileName;

            using (var fileChooser = new SaveFileDialog())
            {
                fileChooser.CheckFileExists = false; // permite al usuario crear el archivo
                result = fileChooser.ShowDialog();
                fileName = fileChooser.FileName; // nombre del archivo en el que
                                                 // se van a guardar los datos
            }

            // se asegura de que el usuario haga clic en "Guardar"
            if (result == DialogResult.OK)
            {
                // muestra error si no obtiene el nombre del archivo especificado
                if (string.IsNullOrEmpty(fileName))
                {
                    MessageBox.Show("Nombre de archivo inválido", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // guarda el archivo mediante el objeto EmpresaRepository
                    try
                    {
                        var jsonobjectserializer = new JsonObjectSerializer();
                        jsonobjectserializer.serializar(clientes, fileName);

                        // deshabilita el botón "Serializar lista" y habilita el botón "Insertar"
                        btnSerializarJson.Enabled = false;
                        btnEnter.Enabled = true;

                        // notifica al usuario que el archivo ha sido serializado
                        MessageBox.Show("Archivo serializado correctamente", string.Empty,
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        // notifica al usuario si el archivo existe
                        MessageBox.Show(ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnserializarXml_Click(object sender, EventArgs e)
        {
            // crea un cuadro de diálogo que permite al usuario guardar el archivo
            DialogResult result;
            string fileName;

            using (var fileChooser = new SaveFileDialog())
            {
                fileChooser.CheckFileExists = false; // permite al usuario crear el archivo
                result = fileChooser.ShowDialog();
                fileName = fileChooser.FileName; // nombre del archivo en el que
                                                 // se van a guardar los datos
            }

            // se asegura de que el usuario haga clic en "Guardar"
            if (result == DialogResult.OK)
            {
                // muestra error si no obtiene el nombre del archivo especificado
                if (string.IsNullOrEmpty(fileName))
                {
                    MessageBox.Show("Nombre de archivo inválido", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // guarda el archivo mediante el objeto EmpresaRepository
                    try
                    {
                        var xmlobjectserializer = new XmlObjectSerializer();
                        xmlobjectserializer.serializar(clientes, fileName);

                        // deshabilita el botón "Serializar lista" y habilita el botón "Insertar"
                        btnSerializarJson.Enabled = false;
                        btnEnter.Enabled = true;

                        // notifica al usuario que el archivo ha sido serializado
                        MessageBox.Show("Archivo serializado correctamente", string.Empty,
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        // notifica al usuario si el archivo existe
                        MessageBox.Show(ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private List<Cliente> btnDeserializarJson_Click(object sender, EventArgs e)
        {
            string strJson = OpenFileEmpresaJson(rutaArchivo);
            if (strJson.Substring(0, 5) != "Falla ")
                return JsonConvert.DeserializeObject<List<Cliente>>(strJson);
            else
            {
                var lista = new List<Cliente>();
                var empresa = new Cliente();
                empresa.Nombre = strJson;
                lista.Add(empresa);
                return lista;
            }
        }

        private string OpenFileEmpresaJson(object rutaArchivo)
        {
            try
            {
                string json = "";
                using (var fs = new FileStream(rutaArchivo, FileMode.Open, FileAccess.Read))
                {
                    using (var sr = new StreamReader(fs))
                    {
                        json = sr.ReadToEnd();
                    }
                }
                return json;
            }
            catch (Exception ex)
            {

                return "Falla: " + ex.Message;
            }
        }
    }
}
