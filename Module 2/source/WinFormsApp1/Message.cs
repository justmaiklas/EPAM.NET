using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary1;

namespace WinFormsApp1
{
    public partial class Message : Form
    {
        public Message()
        {
            InitializeComponent();
        }

        private void messageCloseBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Message_Load(object sender, EventArgs e)
        {

            helloLabel.Text = HelloConcatenation.FormatHelloMessage(Main.NameInputText);
        }
    }
}
