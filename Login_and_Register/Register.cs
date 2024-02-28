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

namespace Login_and_Register
{
    public partial class Register : Form
    {
        string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"D:\\Login_and_Register\\Registration Database.accdb\"";
        private OleDbConnection conn;
        public Register()
        {
            InitializeComponent();
            conn = new OleDbConnection(connectionString);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (PasswordTxt.Text != ConfirmTxt.Text)
                {
                    MessageBox.Show("Password does not match.");
                    return;
                }

                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();

                    OleDbCommand checkCommand = new OleDbCommand();
                    checkCommand.Connection = conn;
                    checkCommand.CommandText = "SELECT COUNT(*) FROM Register WHERE [Username] = ? OR Email = ?";
                    checkCommand.Parameters.AddWithValue("@username", UserTxt.Text);
                    checkCommand.Parameters.AddWithValue("@email", EmailTxt.Text);
                    int count = (int)checkCommand.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Username or email already exists.");
                        return;
                    }

                    OleDbCommand command = new OleDbCommand();
                    command.Connection = conn;
                    command.CommandText = "INSERT INTO Register ([Username], Email, [Password]) VALUES (?, ?, ?)";
                    command.Parameters.AddWithValue("@username", UserTxt.Text);
                    command.Parameters.AddWithValue("@email", EmailTxt.Text);
                    command.Parameters.AddWithValue("@password", PasswordTxt.Text);
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Registration successful!");
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }
    }
}
