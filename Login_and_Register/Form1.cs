using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Login_and_Register
{
    public partial class Form1 : Form
    {
        string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"D:\\Login_and_Register\\Registration Database.accdb\"";
        private OleDbConnection conn;
        public Form1()
        {
            InitializeComponent();
            conn = new OleDbConnection(connectionString);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register reg = new Register();
            reg.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            string Email = emailTxt.Text;
            string Password = passTxt.Text;
            OleDbCommand com = new OleDbCommand("Select Password FROM Register WHERE Email  ='" + Email + "'", conn);
            string pass = com.ExecuteScalar().ToString();

            if(Password == pass)
            {
                Dashboard Dash = new Dashboard();
                MessageBox.Show("Success", "Login Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Dash.ShowDialog();
                
            }
            else
            {
                MessageBox.Show("Error", "Login Error, wrong password", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            conn.Close();
        }

        private void PasswordIcon_Click(object sender, EventArgs e)
        {
            if (passTxt.UseSystemPasswordChar)
            {
                passTxt.UseSystemPasswordChar = false;
            }
            else
            {
                passTxt.UseSystemPasswordChar = true;
            }
        }
    }
}
