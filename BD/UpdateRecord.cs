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
    public partial class UpdateRecord : Form
    {
        private int ID_Record;
        private int ID_Department;
        private int ID_Procedure;
        private int ID_Doctors;
        private int ID_Patients;
        private string time;

        private List<string> Data = new List<string>();
        public UpdateRecord(int ID_R,/*int ID_D,*/ int ID_P, int ID_Doc, int ID_Pat)
        {
            InitializeComponent();
            ID_Record = ID_R;
           // ID_Department = ID_D;
            ID_Procedure = ID_P;
            ID_Doctors = ID_Doc;
            ID_Patients = ID_Pat;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (dateTimePicker.Value.ToString() != null && comboBoxTime.SelectedItem != null && comboBoxPat.SelectedItem != null && comboBoxDoc.SelectedItem != null && comboBoxProcedure.SelectedItem != null && comboBoxDep.SelectedItem != null && comboBoxStatus.SelectedItem != null)
            {
              
                try
                {
                    DataTable table1 = DBConnect.ShowDB(String.Format("SELECT ID_Procedure FROM [Procedure] WHERE Name = '{0}'", comboBoxProcedure.SelectedItem.ToString()));
                    int ID_procedure = Convert.ToInt32(table1.Rows[0]["ID_Procedure"]);

                    DataTable table2 = DBConnect.ShowDB(String.Format("SELECT ID_Pat FROM Patients"));
                    int ID_patient = Convert.ToInt32(table2.Rows[comboBoxPat.SelectedIndex]["ID_Pat"]);

                    DataTable tableD = DBConnect.ShowDB(String.Format("SELECT ID_Dep FROM Department"));
                    int ID_dep = Convert.ToInt32(tableD.Rows[comboBoxDep.SelectedIndex]["ID_Dep"]);

                    DataTable table3 = DBConnect.ShowDB(String.Format("SELECT ID_Doc FROM Doctors WHERE ID_Dep = {0}", ID_dep));
                    int ID_doc = Convert.ToInt32(table3.Rows[comboBoxDoc.SelectedIndex]["ID_Doc"]);
                    
                    DBConnect.InsertDeleteDB(String.Format("UPDATE Records SET ID_Procedure = {0}, [Time] = '{1}', Data = '{2}', Status = '{3}',ID_Doc ={4}, ID_Pat = {5} WHERE ID_Record = {6} ", ID_procedure, comboBoxTime.SelectedItem.ToString(), dateTimePicker.Value.ToShortDateString(), comboBoxStatus.SelectedItem.ToString(), ID_doc, ID_patient, ID_Record));
                    MessageBox.Show("Запись успешно изменена!");
                    this.Close();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                 
            }
            else
            {
                MessageBox.Show("Заполнены не все поля.");
            }
            
        }
        public void setValue() {
            DataTable table1 = DBConnect.ShowDB(String.Format("SELECT ID_Dep FROM Doctors WHERE ID_Doc = {0}", ID_Doctors));
            ID_Department = Convert.ToInt32(table1.Rows[0]["ID_Dep"]);

            DataTable tableD = DBConnect.ShowDB(String.Format("SELECT Name FROM Department WHERE ID_Dep = {0}", ID_Department));
            comboBoxDep.Text = tableD.Rows[0]["Name"].ToString();
            DataTable tableP = DBConnect.ShowDB(String.Format("SELECT Name FROM [Procedure] WHERE ID_Procedure = {0}", ID_Procedure));
            comboBoxProcedure.Text = tableP.Rows[0]["Name"].ToString();
            DataTable tableDoc = DBConnect.ShowDB(String.Format("SELECT Surname, Name, Patronymic FROM Doctors WHERE ID_Doc = {0}", ID_Doctors));
            comboBoxDoc.Text = String.Format(tableDoc.Rows[0]["Surname"].ToString()+" "+tableDoc.Rows[0]["Name"].ToString() + " " + tableDoc.Rows[0]["Patronymic"].ToString());
            DataTable tablePat = DBConnect.ShowDB(String.Format("SELECT Surname, Name, Patronymic FROM Patients WHERE ID_Pat = {0}", ID_Patients));
            comboBoxPat.Text = String.Format(tablePat.Rows[0]["Surname"].ToString() + " " + tablePat.Rows[0]["Name"].ToString() + " " + tablePat.Rows[0]["Patronymic"].ToString());
            DataTable tableT = DBConnect.ShowDB(String.Format("SELECT [Time], Data, Status FROM Records WHERE ID_Record = {0}", ID_Record));
            time = Convert.ToDateTime(tableT.Rows[0]["Time"]).ToShortTimeString();
            comboBoxTime.Text = time;
            comboBoxStatus.Text = tableT.Rows[0]["Status"].ToString();
            dateTimePicker.Value = Convert.ToDateTime(tableT.Rows[0]["Data"]);
        }
        private void UpdateRecord_Load(object sender, EventArgs e)
        {
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
                sListP.Add(String.Format((tableP.Rows[i]["Surname"]).ToString() + " " + (tableP.Rows[i]["Name"]).ToString() + " " + (tableP.Rows[i]["Patronymic"]).ToString() + " " + (tableP.Rows[i]["ID_Pat"]).ToString()));
            }
            comboBoxPat.DataSource = sListP;
            setValue();
            comboBoxDep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxProcedure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxPat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        private void comboBoxDep_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxProcedure.DataSource = null;
            comboBoxDoc.DataSource = null;
            DataTable table1 = DBConnect.ShowDB(String.Format("SELECT ID_Dep FROM Department WHERE Name = '{0}'", comboBoxDep.SelectedItem.ToString()));
            int ID_D = Convert.ToInt32(table1.Rows[0]["ID_Dep"]);

            DataTable table2 = DBConnect.ShowDB(String.Format("SELECT Name FROM [Procedure] WHERE ID_Dep = {0}", ID_D));
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
                sList2.Add(String.Format((table3.Rows[i]["Surname"]).ToString() + " " + (table3.Rows[i]["Name"]).ToString() + " " + (table3.Rows[i]["Patronymic"]).ToString() + " " + (table3.Rows[i]["Position"]).ToString()));
            }
            comboBoxDoc.DataSource = sList2;
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

            DataTable tableDoc = DBConnect.ShowDB(String.Format("SELECT ID_Doc FROM Doctors WHERE (Surname = '{0}')AND(Name = '{1}')AND(Patronymic = '{2}')AND([Position] = '{3}')", str[0], str[1], str[2], str[3]));
            if (tableDoc.Rows.Count != 0)
            {
                int ID_Doc = Convert.ToInt32(tableDoc.Rows[0]["ID_Doc"]);
                DataTable tableTime = DBConnect.ShowDB(String.Format("SELECT [Time] FROM Records WHERE (ID_Doc = {0}) AND (Data = DateValue('{1}')) ", ID_Doc, dateTimePicker.Value.ToShortDateString()));


                for (int i = 0; i < tableTime.Rows.Count; i++)
                {
                    sListTime.Add(Convert.ToDateTime(tableTime.Rows[i]["Time"]).ToShortTimeString());
                }
            }




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
                    if (sListTime.Contains(dateTime.ToShortTimeString()) == false)
                    {
                        Data.Add(dateTime.ToShortTimeString());
                    }
                    else
                    {
                        if (dateTime.ToShortTimeString() == time)
                        {
                            Data.Add(dateTime.ToShortTimeString());
                        }
                    }
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
                    if (sListTime.Contains(dateTime.ToShortTimeString()) == false) { Data.Add(dateTime.ToShortTimeString()); }
                    else
                    {
                        if (dateTime.ToShortTimeString() == time)
                        {
                            Data.Add(dateTime.ToShortTimeString());
                        }
                    }
                    dateTime = dateTime + interval;
                }
                comboBoxTime.DataSource = Data;
            }
        }

        private void dateTimePicker_Enter(object sender, EventArgs e)
        {
            dateTimePicker.MinDate = DateTime.Today;
        }
    }
}
