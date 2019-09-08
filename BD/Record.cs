using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BD
{
    public partial class Record : Form
    {
        public Record()
        {
            InitializeComponent();
        }
        private Random Ran;
        private List<string> Data = new List<string>();
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (dateTimePicker.Value.ToString()!=null && comboBoxTime.SelectedItem !=null && comboBoxPat.SelectedItem != null && comboBoxDoc.SelectedItem != null && comboBoxProcedure.SelectedItem != null && comboBoxDep.SelectedItem != null)
            {
                int ran = Ran.Next(1, 10000);
                //MessageBox.Show(ran.ToString());
                if (DBConnect.Contains(String.Format("SELECT Data FROM Records WHERE ID_Record = {0}", ran)) == true) {
                    while (DBConnect.Contains(String.Format("SELECT Data FROM Records WHERE ID_Record = {0}", ran)) == true)
                    {
                        ran = Ran.Next(1, 10000);
                    }
                }

                try
                {
                    DataTable table1 = DBConnect.ShowDB(String.Format("SELECT ID_Procedure FROM [Procedure] WHERE Name = '{0}'", comboBoxProcedure.SelectedItem.ToString()));
                    int ID_Procedure = Convert.ToInt32(table1.Rows[0]["ID_Procedure"]);

                    DataTable table2 = DBConnect.ShowDB(String.Format("SELECT ID_Pat FROM Patients"));
                    int ID_Patient = Convert.ToInt32(table2.Rows[comboBoxPat.SelectedIndex]["ID_Pat"]);

                    DataTable tableD = DBConnect.ShowDB(String.Format("SELECT ID_Dep FROM Department"));
                    int ID_Dep = Convert.ToInt32(tableD.Rows[comboBoxDep.SelectedIndex]["ID_Dep"]);

                    DataTable table3 = DBConnect.ShowDB(String.Format("SELECT ID_Doc FROM Doctors WHERE ID_Dep = {0}",ID_Dep));
                    int ID_Doc = Convert.ToInt32(table3.Rows[comboBoxDoc.SelectedIndex]["ID_Doc"]);

                    DBConnect.InsertDeleteDB(String.Format("INSERT INTO Records (ID_Record, ID_Procedure, [Time], Data, Status,ID_Doc, ID_Pat) VALUES ({0},{1},'{2}','{3}','{4}',{5},{6})", ran, ID_Procedure, comboBoxTime.SelectedItem.ToString(), dateTimePicker.Value.ToShortDateString(), "Ожидание", ID_Doc, ID_Patient));
                    DBConnect.InsertDeleteDB(String.Format("INSERT INTO Report (ID_Record, Payment, Comment) VALUES ({0},'{1}','{2}')", ran, "Не оплачено",""));
                    this.Close();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
               
            }
            else {
                MessageBox.Show("Заполнены не все поля.");
            }
        }


        private void Record_Load(object sender, EventArgs e)
        {
            Ran = new Random((int)DateTime.Now.Ticks);

            comboBoxDep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxProcedure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxPat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            DataTable table = DBConnect.ShowDB("SELECT Name FROM Department");
            List<string> sList = new List<string>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                sList.Add((table.Rows[i]["Name"]).ToString());
            }
            comboBoxDep.DataSource = sList;

            DataTable tableP = DBConnect.ShowDB("SELECT Surname, Name, Patronymic, ID_Pat FROM Patients");
            List<string> sListP = new List<string>();
            for (int i = 0; i < tableP.Rows.Count; i++)
            {
                sListP.Add(String.Format((tableP.Rows[i]["Surname"]).ToString() + " " + (tableP.Rows[i]["Name"]).ToString() + " " + (tableP.Rows[i]["Patronymic"]).ToString()+" " + (tableP.Rows[i]["ID_Pat"]).ToString()));
            }
            comboBoxPat.DataSource = sListP;

            
        }

        private void comboBoxDep_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxProcedure.DataSource = null;
            comboBoxDoc.DataSource = null;
            DataTable table1 = DBConnect.ShowDB(String.Format("SELECT ID_Dep FROM Department WHERE Name = '{0}'", comboBoxDep.SelectedItem.ToString()));
            int ID_D = Convert.ToInt32(table1.Rows[0]["ID_Dep"]);

            DataTable table2 = DBConnect.ShowDB(String.Format("SELECT Name FROM [Procedure] WHERE ID_Dep = {0}",ID_D));
            List<string> sList = new List<string>();
            for (int i = 0; i < table2.Rows.Count; i++)
            {
                sList.Add((table2.Rows[i]["Name"]).ToString());
            }
            comboBoxProcedure.DataSource = sList;

            DataTable table3 = DBConnect.ShowDB(String.Format("SELECT Surname, Name, Patronymic, [Position] FROM Doctors WHERE ID_Dep = {0}", ID_D));
            List<string> sList2 = new List<string>();
            for (int i = 0; i < table3.Rows.Count; i++)
            {
                sList2.Add(String.Format((table3.Rows[i]["Surname"]).ToString()+ " " + (table3.Rows[i]["Name"]).ToString() + " " + (table3.Rows[i]["Patronymic"]).ToString()+" " + (table3.Rows[i]["Position"]).ToString()));
            }
            comboBoxDoc.DataSource = sList2;
        }

        private void dateTimePicker_Enter(object sender, EventArgs e)
        {
            dateTimePicker.MinDate = DateTime.Today;
        }
       private List<string> sListTime = new List<string>();
        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (Data.Count != 0)
            {
                Data.Clear();
                comboBoxTime.DataSource = null;
                sListTime.Clear();
            }
            string text = comboBoxDoc.SelectedItem.ToString();
            
            string[] str = text.Split((string[])null, StringSplitOptions.RemoveEmptyEntries);
            string pos = "";
            for (int i = 3; i < str.Count(); i++) {
                pos +=  str[i];
                if (i < str.Count() - 1) { pos += " "; }
            }
            
            DataTable tableDoc = DBConnect.ShowDB(String.Format("SELECT ID_Doc FROM Doctors WHERE (Surname = '{0}')AND(Name = '{1}')AND(Patronymic = '{2}')AND([Position] LIKE '%{3}%')", str[0],str[1],str[2],pos));
            //MessageBox.Show(tableDoc.Rows.Count.ToString());
            if (tableDoc.Rows.Count != 0)
            {
                int ID_Doc = Convert.ToInt32(tableDoc.Rows[0]["ID_Doc"]);
                 DataTable tableTime = DBConnect.ShowDB(String.Format("SELECT [Time] FROM Records WHERE (ID_Doc = {0}) AND (Data = DateValue('{1}')) ", ID_Doc, dateTimePicker.Value.ToShortDateString()));
               // MessageBox.Show("dsfsdfs");
                //DataTable tableTime = DBConnect.ShowDB(String.Format("SELECT [Time] FROM Records WHERE (ID_Doc = 8721) AND (Data = DateValue('08.12.2017')) "/*, ID_Doc, dateTimePicker.Value.ToShortDateString()*/));
                // MessageBox.Show(tableTime.Rows.Count.ToString());
                for (int i = 0; i < tableTime.Rows.Count; i++)
                {
                    sListTime.Add(Convert.ToDateTime(tableTime.Rows[i]["Time"]).ToShortTimeString());
                }
            }




            // comboBoxTime.DataSource = sListTime;

            if ((dateTimePicker.Value.ToShortDateString() == DateTime.Now.ToShortDateString()) && (DateTime.Now.Hour > Convert.ToDateTime("8:00").Hour))
            {
                DateTime dateTime = Convert.ToDateTime(DateTime.Today.ToShortDateString() + "," + DateTime.Now.ToShortTimeString());
                var interval = new TimeSpan(0, 30, 0);
                if ((dateTime.Minute / interval.Minutes) == 0)
                {
                    string newTime = (dateTime.Hour.ToString() + ":" + interval.Minutes.ToString());
                    dateTime = Convert.ToDateTime(DateTime.Today.ToShortDateString() + "," + newTime);
                }
                else
                {
                    dateTime = dateTime.AddHours(1);
                    dateTime = dateTime.AddMinutes(-dateTime.Minute);
                    dateTime = Convert.ToDateTime(DateTime.Today.ToShortDateString() + "," + dateTime.ToShortTimeString());
                }

                while (dateTime != Convert.ToDateTime(dateTimePicker.Value.ToShortDateString() + "," + "20:00"))
                {
                    if (sListTime.Contains(dateTime.ToShortTimeString()) == false) Data.Add(dateTime.ToShortTimeString());
                    dateTime = dateTime + interval;
                }
                comboBoxTime.DataSource = Data;
            }
            else
            {
                DateTime dateTime = Convert.ToDateTime(dateTimePicker.Value.ToShortDateString() + "," + "8:00");
                var interval = new TimeSpan(0, 30, 0);
                while (dateTime != Convert.ToDateTime(dateTimePicker.Value.ToShortDateString() + "," + "20:00"))
                {
                    if (sListTime.Contains(dateTime.ToShortTimeString()) == false) Data.Add(dateTime.ToShortTimeString());
                    dateTime = dateTime + interval;
                }
                comboBoxTime.DataSource = Data;
            }

        }
    }
}
