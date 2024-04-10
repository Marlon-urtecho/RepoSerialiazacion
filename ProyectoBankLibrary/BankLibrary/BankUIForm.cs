using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankLibrary
{
    public partial class BankUIForm : Form
    {
        protected int TextBoxCount { get; set; } = 4;

        public enum TextBoxIndices { Account, First, Last, Balance}
        public BankUIForm()
        {
            InitializeComponent();
        }

        public void CrearTextBoxes()
        {
            foreach (Control guiControl in Controls)
            {
                (guiControl as TextBox)?.Clear();
            }
        }

        public void SetTextBoxValues(string[] values)
        {
            if(values.Length != TextBoxCount)
            {
                throw (new ArgumentException(
                    $"There must be: {TextBoxCount} strings in the array"
                    , nameof(values)));
            }
            else
            {
                txtAccount.Text = values[(int)TextBoxIndices.Account];
                txtFirstName.Text = values[(int)TextBoxIndices.First];
                txtLastName.Text = values[(int)TextBoxIndices.Last];
                txtBalance.Text = values[(int)TextBoxIndices.Balance];
            }
        }

        public string[] GetTextBoxValues() 
        {
            return new string[]
            {
                txtAccount.Text,
                txtFirstName.Text,
                txtLastName.Text,
                txtBalance.Text
            };
        }
    }
}
