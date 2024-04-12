using BankLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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

        private readonly Iserializer _serializer;
        public frmCreateFile()
        {
            InitializeComponent();
            _serializer = new JsonObjectSerializer();
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
            Cliente cliente = new Cliente();

            cliente.firsName = txtFirstName.Text;
            cliente.cuenta = int.Parse(txtAccount.Text);
            cliente.LastName = txtLastName.Text;
            cliente.saldo = double.Parse(txtBalance.Text, CultureInfo.InvariantCulture);

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

        private void btnDeserializarJson_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileChooser = new OpenFileDialog())
            {
                DialogResult result = fileChooser.ShowDialog();


                // Se asegura de que el usuario haya hecho clic en "Abrir"
                if (result == DialogResult.OK)
                {
                   string fileName = fileChooser.FileName;
                    // Resto del código para deserializar el archivo utilizando el JsonSerializer...
                    try
                    {
                        // Deserializa el archivo utilizando el JsonSerializer
                        // Deserializa el archivo utilizando el JsonSerializer
                        List<Cliente> listaClientes = _serializer.Deserializable<List<Cliente>>(fileName);

                        if (listaClientes != null && listaClientes.Count > 0)
                        {
                            // Seleccionamos el primer cliente de la lista para mostrar sus datos en los TextBoxes
                            Cliente cliente = listaClientes[0];

                            // Asigna las propiedades del objeto a los TextBoxes correspondientes
                            txtAccount.Text = cliente.cuenta.ToString();
                            txtFirstName.Text = cliente.firsName;
                            txtLastName.Text = cliente.LastName;
                            txtBalance.Text = cliente.saldo.ToString();
                        }
                        else
                        {
                            // Si obj es null, muestra un mensaje de error o maneja la situación de acuerdo a tus necesidades
                            MessageBox.Show("El objeto deserializado es null.", "Error",
                                             MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        // Deshabilita el botón "Deserializar JSON" si es necesario
                        btnDeserializarJson.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error de archivo",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }
    }
}
