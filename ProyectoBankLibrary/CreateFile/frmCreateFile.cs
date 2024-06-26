﻿using BankLibrary;
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
using System.Xml.Serialization;

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
            cliente.LastName = txtLastName.Text;
            cliente.saldo = double.Parse(txtBalance.Text, CultureInfo.InvariantCulture);

            int cuenta;
            if (int.TryParse(txtAccount.Text, out cuenta))
            {
                cliente.cuenta = cuenta;
                clientes.Add(cliente);
                btnserializarXml.Enabled = true;
                btnSerializarJson.Enabled = true;
                ClearTextBoxes();
                txtFirstName.Focus();
            }
            else
            {
                txtAccount.Text = "El campo contiene letras";
                txtAccount.SelectAll();
                txtAccount.Focus();
            }
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
                    MessageBox.Show("Nombre de archivo inválido", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        var jsonobjectserializer = new JsonObjectSerializer();
                        jsonobjectserializer.serializar(clientes, fileName);
                        btnSerializarJson.Enabled = false;
                        btnEnter.Enabled = true;
                        MessageBox.Show("Archivo serializado correctamente", string.Empty,
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnserializarXml_Click(object sender, EventArgs e)
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
                    MessageBox.Show("Nombre de archivo inválido", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        var xmlobjectserializer = new XmlObjectSerializer();
                        xmlobjectserializer.serializar(clientes, fileName);
                        btnSerializarJson.Enabled = false;
                        btnEnter.Enabled = true;

                        MessageBox.Show("Archivo serializado correctamente", string.Empty,
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
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

                if (result == DialogResult.OK)
                {
                    string fileName = fileChooser.FileName;

                    try
                    {
                        List<Cliente> listaClientes = _serializer.Deserializable<List<Cliente>>(fileName);

                        if (listaClientes != null && listaClientes.Count > 0)
                        {
                            dgvDeserializar.Rows.Clear();

                            foreach (Cliente cliente in listaClientes)
                            {
                                int rowIndex = dgvDeserializar.Rows.Add(
                                    cliente.cuenta.ToString(),
                                    cliente.firsName,
                                    cliente.LastName,
                                    cliente.saldo.ToString()
                                );
                            }
                        }
                        else
                        {
                            MessageBox.Show("El objeto deserializado es null o está vacío.", "Error",
                                             MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

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

        private void btnDeserializarXml_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileChooser = new OpenFileDialog())
            {
                DialogResult result = fileChooser.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string fileName = fileChooser.FileName;

                    try
                    {
                        List<Cliente> listaClientes;
                        XmlSerializer serializer = new XmlSerializer(typeof(List<Cliente>));
                        using (FileStream fs = new FileStream(fileName, FileMode.Open))
                        {
                            listaClientes = (List<Cliente>)serializer.Deserialize(fs);
                        }

                        if (listaClientes != null && listaClientes.Count > 0)
                        {
                            dgvDeserializar.Rows.Clear();

                            foreach (Cliente cliente in listaClientes)
                            {
                                int rowIndex = dgvDeserializar.Rows.Add(
                                    cliente.cuenta.ToString(),
                                    cliente.firsName,
                                    cliente.LastName,
                                    cliente.saldo.ToString()
                                );
                            }
                        }
                        else
                        {
                            MessageBox.Show("La lista de clientes está vacía.", "Error",
                                             MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        btnDeserializarXml.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error en leer al archivo",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}