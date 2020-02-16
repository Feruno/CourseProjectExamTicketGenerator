using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using MaterialSkin.Controls;

namespace KPL
{
    public partial class Authorization : MaterialForm
    {
        MySqlConnection myConn = new MySqlConnection("server=localhost;user=root;database=Ticket_generator9;password=1234;");
       // MySqlCommand command;
        public Authorization()
        {
            InitializeComponent();
            TBpasswordUser.UseSystemPasswordChar = true ;
        }

        private void BTNlogin_Click(object sender, EventArgs e)
        {
            int i = 0;
            myConn.Open();
            MySqlCommand cmd = myConn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from login where username= '" +TBnameUser.Text+ "' and password='" +TBpasswordUser.Text+ "' ";
           // cmd.EndExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());

            if (i == 0)
            {
                label3.Text = "неверный пароль";
            }
            else
            {
                this.Hide();
                Form1 fm = new Form1();
                fm.Show();
            }
            myConn.Close();
        }

        private void viewPassword_CheckedChanged(object sender, EventArgs e)
        {
            if(viewPassword.Checked)
            {
                TBpasswordUser.UseSystemPasswordChar = false;
            }
            else
            {
                TBpasswordUser.UseSystemPasswordChar = true;
            }
        }
    }
}
