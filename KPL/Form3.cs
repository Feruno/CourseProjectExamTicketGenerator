using MaterialSkin;
using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KPL
{
    public partial class Form3 : MaterialForm
    {

        public Form3()
        {
            InitializeComponent();
            var skinmanager = MaterialSkinManager.Instance;
            skinmanager.AddFormToManage(this);
            skinmanager.Theme = MaterialSkinManager.Themes.DARK;
            skinmanager.ColorScheme = new ColorScheme(Primary.Purple400, Primary.Purple600, Primary.Purple600, Accent.DeepPurple100, TextShade.BLACK);

        }

        private void mFBGen_Click(object sender, EventArgs e)
        {
            try
            {
            string myConnection = "server=localhost;user=root;database=Ticket_generator9;port=3306;password=1234;";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            myConn.Open();
            MySqlCommand cmd = new MySqlCommand("call GEN_Q_T(@i, @quantity_Ticket, @num_exam, @s_q_q_t)", myConn);

            MySqlParameter MC = new MySqlParameter();
            MC = cmd.Parameters.Add("@i", MySqlDbType.VarChar, 20);
            MC.Direction = ParameterDirection.Input;
            MC.Value = Convert.ToString(mSLTFNameDisc.Text);

            MySqlParameter QT = new MySqlParameter();
            QT = cmd.Parameters.Add("@quantity_Ticket", MySqlDbType.Int32);
            QT.Direction = ParameterDirection.Input;
            QT.Value = Convert.ToInt32(mSLTFQuantTik.Text);

            MySqlParameter NE = new MySqlParameter();
            NE = cmd.Parameters.Add("@num_exam", MySqlDbType.Int32);
            NE.Direction = ParameterDirection.Input;
            NE.Value = Convert.ToInt32(mSLTFExam.Text);

            MySqlParameter SQQT = new MySqlParameter();
            SQQT = cmd.Parameters.Add("@s_q_q_t", MySqlDbType.Int32);
            SQQT.Direction = ParameterDirection.Input;
            SQQT.Value = Convert.ToInt32(mSLTFQuantQuest.Text);

            cmd.ExecuteNonQuery();
                
                MessageBox.Show("Данные добавлены");   

            myConn.Close();
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        public void populateDVGResult() //
        {
            try
            {
                string myConnection = "server=localhost;user=root;database=Ticket_generator9;port=3306;password=1234;";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                string selectQuery = "SELECT * FROM ticket_generator9.result_t2";
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, myConnection);
                adapter.Fill(table);

            }
            catch
            {
                //MessageBox.Show("error");
            }
        }
        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Form1.SelfRef != null)
            {
                Form1.SelfRef.populateDVGResult();
            }
            
        }
    }
}
