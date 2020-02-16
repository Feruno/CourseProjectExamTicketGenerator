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
using Word = Microsoft.Office.Interop.Word;
//using Microsoft.Office.Interop.Word;
using System.Reflection;
using MaterialSkin.Controls;
using MaterialSkin;
using System.IO;
using System.Text;

namespace KPL
{
    public partial class Form1 : MaterialForm
    {
        private Word.Application thisApplication = null;
        private Word.Document thisDocument = null;

        MySqlConnection myConn = new MySqlConnection("server=localhost;user=root;database=Ticket_generator9;password=1234;");        
        MySqlCommand command;
        DataSet ds = new DataSet(); 
        
        public Form1()

        {
           InitializeComponent();
           SelfRef = this;
           var skinmanager = MaterialSkinManager.Instance;
           skinmanager.AddFormToManage(this);
           skinmanager.Theme = MaterialSkinManager.Themes.DARK;
           skinmanager.ColorScheme = new ColorScheme(Primary.Purple400, Primary.Purple600, Primary.Purple600, Accent.DeepPurple100, TextShade.BLACK);
        }
        public static Form1 SelfRef
        {
            get;
            set;
        }

        public void coonnect()//сделать нормальный коннект (убрать повтор строк подключения) пока не получилось
        {
            string myConnection = "server=localhost;user=root;database=Ticket_generator9;password=1234;";
            MySqlConnection myConn = new MySqlConnection(myConnection);           
                        
        }       

        private void button1_Click(object sender, EventArgs e) // проверка соединения с баzой данных
        {
            try
            {
                
                string myConnection = "server=localhost;user=root;database=Ticket_generator9;port=3306;password=1234;";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();

                myDataAdapter.SelectCommand = new MySqlCommand("select * database.Ticket_generator9 ; ", myConn);
                MySqlCommandBuilder cd = new MySqlCommandBuilder(myDataAdapter);
                myConn.Open();
                DataSet ds = new DataSet();
                MessageBox.Show("connect");
                myConn.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
        public void populateDVG()//отображение таблицы вопросы в dataGridView
        {
            string myConnection = "server=localhost;user=root;database=Ticket_generator9;port=3306;password=1234;";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            string selectQuery = "Select * from Question ";
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter( selectQuery, myConnection);
            adapter.Fill(table);
            dataGridViewQuestion.DataSource = table;
        }
        public void populateDVGCpec()//отображение таблицы специальности в dataGridView
        {
            string myConnection = "server=localhost;user=root;database=Ticket_generator9;port=3306;password=1234;";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            string selectQuery = "Select * from specialties ";
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, myConnection);
            adapter.Fill(table);
            dataGridViewCpec.DataSource = table;
        }
        public void populateDVGGroups()//отображение таблицы специальности в dataGridView
        {
            string myConnection = "server=localhost;user=root;database=Ticket_generator9;port=3306;password=1234;";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            string selectQuery = "Select * from Groups ";
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, myConnection);
            adapter.Fill(table);
            dataGridViewGroups.DataSource = table;
        }
        public void populateDVGTeacher()//отображение таблицы учителя в dataGridView
        {
            string myConnection = "server=localhost;user=root;database=Ticket_generator9;port=3306;password=1234;";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            string selectQuery = "Select * from teacher ";
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, myConnection);
            adapter.Fill(table);
            dataGridViewTeacher.DataSource = table;
        }
        public void populateDVGDisc()//отображение  таблицы дисциплины в dataGridView
        {
            string myConnection = "server=localhost;user=root;database=Ticket_generator9;port=3306;password=1234;";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            string selectQuery = "Select * from discipline ";
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, myConnection);
            adapter.Fill(table);
            dataGridViewDisc.DataSource = table;
        }
        public void populateDVGExam()//отображение таблицы кзамены в dataGridView
        {
            string myConnection = "server=localhost;user=root;database=Ticket_generator9;port=3306;password=1234;";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            string selectQuery = "Select * from exam ";
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, myConnection);
            adapter.Fill(table);
            dataGridViewExam.DataSource = table;
        }
        
        public void populateDVGCyclic_comm()//отображение таблицы цикловая комиссия в dataGridView
        {
            try
            { 
            string myConnection = "server=localhost;user=root;database=Ticket_generator9;port=3306;password=1234;";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            string selectQuery = "Select * from Cyclic_commission ";
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, myConnection);
            adapter.Fill(table);
            dataGridViewCyclic_comm.DataSource = table;
            }
            catch
            {
                MessageBox.Show("errormmm");
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
                dataGridViewResult.DataSource = table;

            }
            catch
            {
                //MessageBox.Show("error");
            }
        }
        public void populateDVGResult2() //
        {
            try
            {
                string myConnection = "server=localhost;user=root;database=Ticket_generator9;port=3306;password=1234;";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                string selectQuery = "call ticket_generator9.gent5()";
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, myConnection);
                adapter.Fill(table);
                //dataGridViewResult1.DataSource = table;

            }
            catch
            {
                MessageBox.Show("errormain");
            }
        }




        public void myopConn()
        {
            if(myConn.State == ConnectionState.Closed)
            {
                myConn.Open();
            }
        }
        public void mycloseConn()
        {
            if(myConn.State == ConnectionState.Open)
            {
                myConn.Close();
            }
        }
        public void executeMyquery(string query)
        {
            try
            {
                myopConn();
                command = new MySqlCommand(query, myConn);
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Выполнено");

                }
                else
                {
                    MessageBox.Show("Ошибка");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                mycloseConn();
            }
        }

        private void DobavlenieBTN_Click(object sender, EventArgs e)//добавление записей в таблицу вопросы (Issues)
        {
            string insertQuery = "INSERT INTO Question(Question_type, Question,Code_discipline) VALUES('" + CBissuesTypeQ.Text + "' , '" + TBquestion.Text + "' , '" + TBissuesCodeDisc.Text + "' )";
            executeMyquery(insertQuery);
            populateDVG();
        }

        private void ChangeBTN_Click(object sender, EventArgs e)//изменение записей  таблицы вопросы (Issues)
        {
            try
            {string updateQuery = "UPDATE Question SET Question_type='" + CBissuesTypeQ.Text+ "',Question='" + TBquestion.Text+ "' ,Code_discipline='" + TBissuesCodeDisc.Text + "'where id_Question=" + int.Parse(textBoxIDQuest.Text);
            executeMyquery(updateQuery);
            populateDVG();
            }
            catch
            {
                MessageBox.Show("Ошибка, для изменения выберите строку");
            }
        }
        private void DropBTN_Click(object sender, EventArgs e)//удаление записей из таблицы вопросы (Issues)
        {
            try
            {string deleteQuery = "DELETE FROM Question where id_Question= " + int.Parse(textBoxIDQuest.Text);
            executeMyquery(deleteQuery);
            populateDVG();
            }
            catch
            {
                MessageBox.Show("Ошибка, для удаления выберите строку");
            }
        }        
        private void Form1_Load(object sender, EventArgs e) // отображение таблиц в dataGridView
        {
            populateDVG(); // таблица вопросов
            populateDVGCpec(); // таблица специальностей
            populateDVGGroups(); // таблица групп
            populateDVGTeacher();// таблица учителей
            populateDVGDisc();// таблица дисциплин
            populateDVGExam();//таблицы exam            
            populateDVGCyclic_comm();//таблицы цикловая комиссия
            cpec.Text = dataGridViewCpec.RowCount.ToString();
            populateDVGResult();
            textBox1.Text = Convert.ToString( dataGridViewResult.RowCount);

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxIDQuest.Text = dataGridViewQuestion.CurrentRow.Cells[0].Value.ToString();//отображение ID
            CBissuesTypeQ.Text = dataGridViewQuestion.CurrentRow.Cells[1].Value.ToString();
            TBquestion.Text = dataGridViewQuestion.CurrentRow.Cells[2].Value.ToString();
        }
        private void dataGridViewCpec_MouseClick(object sender, MouseEventArgs e)
        {
            IDspec.Text = dataGridViewCpec.CurrentRow.Cells[0].Value.ToString(); //отображение ID
            
        }
        private void dataGridViewGroups_MouseClick(object sender, MouseEventArgs e)
        {
            IDgroups.Text = dataGridViewGroups.CurrentRow.Cells[0].Value.ToString(); //отображение ID
        }
        private void dataGridViewTeacher_MouseClick(object sender, MouseEventArgs e)
        {
            TBidTeacher.Text = dataGridViewTeacher.CurrentRow.Cells[0].Value.ToString(); //отображение ID
        }
        private void dataGridViewDisc_MouseClick(object sender, MouseEventArgs e)
        {
            TBIDDisc.Text = dataGridViewDisc.CurrentRow.Cells[0].Value.ToString();//отображение ID
        }
        private void dataGridViewExam_MouseClick(object sender, MouseEventArgs e)
        {
            IDExam.Text = dataGridViewExam.CurrentRow.Cells[0].Value.ToString(); //отображение ID
        }
        
        private void dataGridViewCyclic_comm_MouseClick(object sender, MouseEventArgs e)
        {
            TBidcyclic_comm.Text = dataGridViewCyclic_comm.CurrentRow.Cells[0].Value.ToString(); //отображение ID
        }
        
        /*
        private void Validating(object sender, System.ComponentModel.CancelEventArgs e)//обработка ограничений
        {

        }
        */
        /// <summary>
        /// /Таблица "специальности"
        /// </summary>


        private void BTNdobSpec_Click(object sender, EventArgs e)//добавление записей в таблицу специальности  (specialties)
        {
            string insertQuery = "INSERT INTO specialties( Name_specialty, num_Specialty) VALUES('" + TBnamespec.Text + "' , '" + TBnum_Specialty.Text + "')";
            executeMyquery(insertQuery);
            populateDVGCpec();

        }
        private void BTNchangeSpec_Click(object sender, EventArgs e)
        {
            try
            {
                string updateQuery = "UPDATE specialties SET Name_specialty='" + TBnamespec.Text + "', num_Specialty='" + TBnum_Specialty.Text + "' where id_Specialty=" + int.Parse(IDspec.Text);
            executeMyquery(updateQuery);
            populateDVGCpec();
            }
            catch
            {
                MessageBox.Show("Ошибка, для изменения выберите строку");
            }

        }


        private void BTNdropCpec_Click(object sender, EventArgs e)//удаление записей из таблицы специальности  (specialties)
        {
            try
            {
                string deleteQuery = "DELETE FROM specialties where id_Specialty= " + int.Parse(IDspec.Text);
            executeMyquery(deleteQuery);
            populateDVGCpec();

            }
            catch
            {
                MessageBox.Show("Ошибка, для удаление выберите строку");
            }
            
        }

        

        private void IDGroups_TextChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Таблица группы
        /// </summary>

        private void BTNdobGroups_Click(object sender, EventArgs e)
        {
            string insertQuery = "INSERT INTO Groups(Specialty_code, code_group) VALUES('" + MTBgroupsSpecialty_code.Text+ "','" + MTBgroupsCode.Text+"')";
            executeMyquery(insertQuery);
            populateDVGGroups();
        }
        private void BTNchangeGroups_Click_1(object sender, EventArgs e)
        {
            try
            {
                string updateQuery = "UPDATE Groups SET  Specialty_code= '" + MTBgroupsSpecialty_code.Text + "',code_group= '" + MTBgroupsCode.Text + "' where id_Group=" + int.Parse(IDgroups.Text);
            executeMyquery(updateQuery);
            populateDVGGroups();

            }
            catch
            {
                MessageBox.Show("Ошибка, для изменения выберите строку");
            }
        }
        /*
        private void BTNchangeGroups_Click(object sender, EventArgs e)
        {
            string updateQuery = "UPDATE Groups SET course='" + CBgroupsCorse.Text + "',bnumber_students='" + TBgroupsNumStudent.Text + "', Semester_number= '" + TBgroupsNumSemestra.Text + "' where Groups_code=" + int.Parse(IDgroups.Text);
            executeMyquery(updateQuery);
            populateDVGGroups();
        }
        */
        private void BTNdropGroups_Click(object sender, EventArgs e)
        {
            try
            {
                string deleteQuery = "DELETE FROM Groups where id_Group= " + int.Parse(IDgroups.Text);
            executeMyquery(deleteQuery);
            populateDVGGroups();

            }
            catch
            {
                MessageBox.Show("Ошибка, для удаления выберите строку");
            }
            
        }
        /// <summary>
        /// Таблица учителя
        /// </summary>
        
        private void BTNdobTeacher_Click(object sender, EventArgs e)
        {
            string insertQuery = "INSERT INTO teacher(midl_name, first_name, last_name) VALUES('" + TBfamTeacher.Text + "' , '" + TBnameTeacher.Text + "' , '" + TBochestTeacher.Text + "')";
            executeMyquery(insertQuery);
            populateDVGTeacher();
        }

        private void BTNchangeTeacher_Click(object sender, EventArgs e)
        {
            try
            {
                string updateQuery = "UPDATE teacher SET midl_name='" + TBfamTeacher.Text + "',first_name='" + TBnameTeacher.Text + "', last_name= '" + TBochestTeacher.Text + "' where id_Teacher=" + int.Parse(TBidTeacher.Text);
            executeMyquery(updateQuery);
            populateDVGTeacher();

            }
            catch
            {
                MessageBox.Show("Ошибка, для изменения выберите строку");
            }
            
        }

        private void BTNdropTeacher_Click(object sender, EventArgs e)
        {
            try
            {
                string deleteQuery = "DELETE FROM teacher where id_Teacher= " + int.Parse(TBidTeacher.Text);
                executeMyquery(deleteQuery);
                populateDVGTeacher();

            }
            catch
            {
                MessageBox.Show("Ошибка, для удаления выберите строку");
            }
           
        }
        /// <summary>
        /// Таблица дисциплины
        /// </summary>

        private void BTNdobDisc_Click(object sender, EventArgs e)
        {
            string insertQuery = "INSERT INTO discipline(Name_discipline) VALUES('" + TBdiscNameDisc.Text+ "')";
            executeMyquery(insertQuery);
            populateDVGDisc();
        }
        private void BTNchangeDisc_Click(object sender, EventArgs e)
        {
            try
            {
                string updateQuery = "UPDATE discipline SET Name_discipline='" + TBdiscNameDisc.Text + "' where id_discipline =" + int.Parse(TBIDDisc.Text);
                executeMyquery(updateQuery);
                populateDVGDisc();

            }
            catch
            {
                MessageBox.Show("Ошибка, для изменения выберите строку");
            }
        }

        private void BTNdropDisc_Click(object sender, EventArgs e)
        {
            try
            {
                string deleteQuery = "DELETE FROM discipline where id_discipline = " + int.Parse(TBIDDisc.Text);
                executeMyquery(deleteQuery);
                populateDVGDisc();

            }
            catch
            {
                MessageBox.Show("Ошибка, для удаления выберите строку");
            }
        }
        /// <summary>
        /// Таблица exam
        /// </summary>

        private void BTNdobExam_Click(object sender, EventArgs e)
        {
            string insertQuery = "INSERT INTO exam(date_,course,semestr, code_cpec, code_disc, code_teacher) VALUES('" + MTBExam.Text + "' , '" + CBexamCourse.Text + "' , '" + TBexamNumSemestr.Text + "', '" + TBexamcode_cpec.Text + "', '" + TBexamcode_disc.Text + "', '" + TBexamcode_teacher.Text + "' )";
            executeMyquery(insertQuery);
            populateDVGExam();
        }
        private void BTNchangeExam_Click(object sender, EventArgs e)
        {
            try
            {string updateQuery = "UPDATE exam SET course='" + CBexamCourse.Text + "',date_='" + MTBExam.Text + "' ,semestr='" + TBexamNumSemestr.Text + "',code_cpec='" + TBexamcode_cpec.Text + "',code_disc='" + TBexamcode_disc.Text + "',code_teacher='" + TBexamcode_teacher.Text + "' where id_exam=" + int.Parse(IDExam.Text);
            executeMyquery(updateQuery);
            populateDVGExam();
            }
            catch
            {
                MessageBox.Show("Ошибка, для изменения выберите строку");
            }
        }

        private void BTNdropExam_Click(object sender, EventArgs e)
        {
            try
            {string deleteQuery = "DELETE FROM exam where id_exam= " + int.Parse(IDExam.Text);
            executeMyquery(deleteQuery);
            populateDVGDisc();

            }
            catch
            {
                MessageBox.Show("Ошибка, для удаления выберите строку");
            }
        }
        /// <summary>
        /// / таблица билетов
        /// </summary>
        //private IEnumerable<object> dict;
        
        /// <summary>
        /// / таблица цикловая комиссия
        /// </summary>
        /// 
        private void BTNdobcyclic_comm_Click(object sender, EventArgs e)
        {
            string insertQuery = "INSERT INTO Cyclic_commission(Name_commission,Chairmans_Name) VALUES('" + TBnameComm.Text + "' , '" + TBnameCrew.Text + "')";
            executeMyquery(insertQuery);

            populateDVGCyclic_comm();
        }

        private void BTNchangeCyclic_comm_Click(object sender, EventArgs e)
        {
            try
            {string updateQuery = "UPDATE Cyclic_commission SET Name_commission='" + TBnameComm.Text + "', Chairmans_Name= '" + TBnameCrew.Text + "' where Code_Cyclic_commission=" + int.Parse(TBidcyclic_comm.Text);
            executeMyquery(updateQuery);               
            populateDVGCyclic_comm();

            }
            catch
            {
                MessageBox.Show("Ошибка, для изменения выберите строку");
            }
        }

        private void BTNdropCyclic_comm_Click(object sender, EventArgs e)
        {
            try
            {string deleteQuery = "DELETE FROM Cyclic_commission where Code_Cyclic_commission= " + int.Parse(TBidcyclic_comm.Text);
            executeMyquery(deleteQuery);
            populateDVGCyclic_comm();

            }
            catch
            {
                MessageBox.Show("Ошибка, для удаления выберите строку");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private readonly string FileName = @"D:\shablonsp.dotx"; //shablonspNEW
        private  string shab = @"D:\shablonspNEW.dotx";

        private void BTNgen3_Click(object sender, EventArgs e)
        {
            try
            {
                string selectQuery = "Select * from Question";
                executeMyquery(selectQuery);
                populateDVGResult();

            }
            catch
            {
                MessageBox.Show("Ошибка заполнения билета печать невозможна");
            }
        }
       
        public void BTNPrint_Click(object sender, EventArgs e) // Кнопка генерации билета
        {

            

        }
        private void BTNprintGen_Click(object sender, EventArgs e)// кнопка печати сгенерированного билета
        {
           // var namespec = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            //int q2 dataGridViewResult.SelectedRows[2].Cells[3].Value();


            try
            {
                var q1 = dataGridViewResult.Rows[1].Cells[0].Value.ToString();
                var namespec = dataGridViewResult.Rows[1].Cells[2].Value.ToString();
                ////var spec = dataGridViewResult.CurrentRow.Cells[16].Value.ToString();
                var numTik = dataGridViewResult.Rows[1].Cells[4].Value.ToString();
                var q2 = dataGridViewResult.Rows[2].Cells[0].Value.ToString();
                var q3 = dataGridViewResult.Rows[3].Cells[0].Value.ToString();
               // var q4 = dataGridViewResult.Rows[4].Cells[1].Value.ToString();
               // var q5 = dataGridViewResult.Rows[5].Cells[1].Value.ToString();
                var wordApp = new Word.Application();
                wordApp.Visible = false;

            try
            {


                    var worddocument = wordApp.Documents.Open(FileName);
                    var range = worddocument.Content;
                    range.Copy();/*
                    Object start = Type.Missing;
                    Object end = Type.Missing;
                    Word.Range rng = worddocument.Range(ref start, ref end);
                    rng.Select();
                    string quantity = worddocument.Characters.Count.ToString();// общие количество символов в документе 
                    MessageBox.Show("Characters:"  + worddocument.Characters.Count.ToString());


                    Object unit = Word.WdUnits.wdCharacter;
                    Object count = quantity;
                    rng.MoveStart(ref unit, ref count);
                    */
                    //string bookmarkName = "T";
                    //object rStart = 0;
                    //object rEnd = worddocument.Content.End;
                    //Word.Document worddocument2 = wordApp.ActiveDocument;
                    //worddocument2.Bookmarks.Add("{T}", rEnd);

                    //Word.Bookmark bookm =
                    //worddocument.Range(ref rStart, ref rEnd).InsertAfter("Новая строка");



                    ReplaceWordStop("{namespec}", namespec, worddocument);
                //ReplaceWordSHAB("{T}", _table, worddocument);
                //ReplaceBookmarkText(worddocument, ref "T", textBox1.Text);
                ReplaceWordStop("{numTik}", numTik, worddocument);
                ReplaceWordStop("{q1}", q1, worddocument);
                ReplaceWordStop("{q2}", q2, worddocument);
                ReplaceWordStop("{q3}", q3, worddocument);
                    //ReplaceWordStop("{q4}", q4, worddocument);
                    //ReplaceWordStop("{q5}", q5, worddocument);
                    //wordApp.Selection.Bookmarks 
                    Object start = Type.Missing;
                    Object end = Type.Missing;
                    Word.Range rng = worddocument.Range(ref start, ref end);
                    rng.Select();
                    string quantity = worddocument.Characters.Count.ToString();// общие количество символов в документе 
                    MessageBox.Show("Characters:" + worddocument.Characters.Count.ToString());


                    Object unit = Word.WdUnits.wdCharacter;
                    Object count = quantity;
                    rng.MoveStart(ref unit, ref count);
                    rng.Paste();
                    worddocument.SaveAs(@"D:\ticket.docx");

                wordApp.Visible = true;
            }
            catch
            {
                MessageBox.Show("ошибка печати");
            }
            }
            catch
            {
                MessageBox.Show("oh");
            }
                        
        }
        private void ReplaceBookmarkText(Microsoft.Office.Interop.Word.Document worddocument, ref string bookmarkName, string text)
        {
            var range = worddocument.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: bookmarkName, ReplaceWith: text);
        }

        private void ReplaceWordSHAB(string v, object name, Word.Document worddocumentSHAB)
        {
            var range = worddocumentSHAB.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: v, ReplaceWith: name);
        }
        private void ReplaceWordStop(string v, string name, Word.Document worddocument) 
        {
            //throw new NotImplementedException();
            
            var range = worddocument.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: v, ReplaceWith: name);
        }
        private void tabControl1VOP_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        /*
        private void TBSpecialty_code_KeyPress(object sender, KeyPressEventArgs e)/// я не помню что это ААА!!!!!!!!!!1
        {
            if (!(Char.IsDigit(e.KeyChar)))
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
        }
        */
        private void MFBform2_Click(object sender, EventArgs e)// отображение формы с данными для генерации билета
        {
            Form3 form = new Form3();

            form.ShowDialog();
        }

                
        private void mFBTEST_Click(object sender, EventArgs e)
        {
            string myConnection = "server=localhost;user=root;database=Ticket_generator9;port=3306;password=1234;";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            myConn.Open();

            //string selectQuery = "Select * from Question ";
            MySqlDataAdapter adapterQuestion = new MySqlDataAdapter("SELECT * FROM ticket_generator9.result_t2", myConn);
            DataSet Ticket_generator9 = new DataSet("Ticket_generator9");
            
            DataTable table = new DataTable();
            adapterQuestion.FillSchema(Ticket_generator9, SchemaType.Source, "result_t2");
            adapterQuestion.Fill(Ticket_generator9, "result_t2");

            DataTable tbQuestion;

            tbQuestion = Ticket_generator9.Tables["result_t2"];

            foreach(DataRow drCurrent in tbQuestion.Rows)
            {
                listBox1.Items.Add(                    
                    drCurrent["Name_discipline"].ToString()  + " " +
                    drCurrent["Question"].ToString()

                    );

            }
           
            //dataGridViewQuestion.DataSource = table;
        }
        
        private void TESTb_Click(object sender, EventArgs e)
        {

            TextWriter writer = new StreamWriter(@"D:\TEST.txt");
            foreach (var item in listBox1.Items)
                writer.WriteLine(item.ToString());
            writer.WriteLine("------------------");
            writer.Close();
            

            /*
            var wordapp = new Word.Application();
            Word.Document doc = wordapp.Documents.Add();
            Visible = false;
            Word.Range rng = doc.Range();
            
            for (int i = 0; i <5; i++) { 
            rng.Text = "GGWP";
            Word.Table tableWD = doc.Tables.Add( rng, 4, 2);
            tableWD.Borders.Enable = 1;

            int qc = 0;
            int qw = 0;
            
            foreach (Word.Row rowWD in tableWD.Rows)
            {
                
                rowWD.Range.Text = dataGridViewResult.Rows[qw].Cells[qc].Value.ToString();
                qw = +1;
                foreach (Word.Cell cellWD in rowWD.Cells)
                {
                    if (cellWD.RowIndex == 1)
                    {
                        cellWD.Range.Text = dataGridViewResult.Rows[0].Cells[2].Value.ToString();
                        cellWD.Range.Bold = 1;
                        cellWD.Range.Font.Name = "verdana";
                        cellWD.Range.Font.Size = 10;

                        cellWD.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                        cellWD.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                    }
                    else
                    {
                        //cellWD.Range.Text = (cellWD.RowIndex - 2 + cellWD.ColumnIndex).ToString();
                    }
                }
            }
            }
            Visible = true;
            doc.Save();
            */
            //wordapp.Documents.Open();
        }
        private void BookmarkInsertFile()
        {

            /*
            var WDAP = new Word.Application();

            var worddocument = WDAP.Documents.Open(shab);
            //Word.Bookmark bookM =
            //worddocument.Bookmarks BM = worddocument.Content 

            string FileName = "C:\\Sales.docx";
            object ConfirmConversions = false;
            object Link = false;
            object Attachment = false;

            bookmark1.InsertFile(FileName, ref missing, ref ConfirmConversions,
                ref Link, ref Attachment);*/
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }
    }

}
