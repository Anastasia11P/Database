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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        void UpdateI()
        {
            dataGridView.DataSource = DBConnect.ShowDB("SELECT * FROM Records");

            dataGridView.Columns[0].HeaderText = "Код записи";
            dataGridView.Columns[1].HeaderText = "Код услуги";
            dataGridView.Columns[2].HeaderText = "Время";
            dataGridView.Columns[3].HeaderText = "Дата";
            dataGridView.Columns[4].HeaderText = "Статус";
            dataGridView.Columns[5].HeaderText = "Код врача";
            dataGridView.Columns[6].HeaderText = "Код клиента";
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.dataGridView.Columns["Time"].DefaultCellStyle.Format = "t";
            buttonDelete.Visible = true;
            buttonRecord.Visible = true;
            buttonUpdate.Visible = true;
        }

        private void toolStripButtonDoc_Click(object sender, EventArgs e)
        {
            Doctors Doc = new Doctors();
            Doc.ShowDialog();
        }

        private void toolStripButtonClient_Click(object sender, EventArgs e)
        {
            Clients Client = new Clients();
            Client.ShowDialog();
        }

        private void toolStripButtonProcedure_Click(object sender, EventArgs e)
        {
            Procedure Proc = new Procedure();
            Proc.ShowDialog();
        }

        private void toolStripButtonReport_Click(object sender, EventArgs e)
        {
            Report report = new Report();
            report.ShowDialog();
        }

        private void toolStripButtonDepartment_Click(object sender, EventArgs e)
        {
            Department Dep = new Department();
            Dep.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateI();
            
            comboBoxDep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            DataTable table = DBConnect.ShowDB("SELECT ID_Dep, Name FROM Department");
            List<string> sList = new List<string>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                sList.Add((table.Rows[i]["ID_Dep"]).ToString()+" "+ (table.Rows[i]["Name"]).ToString());
            }
            comboBoxDep.DataSource = sList;
           
        }

        private void buttonRecord_Click(object sender, EventArgs e)
        {
            Record rec = new Record();
            rec.Show();
            rec.FormClosed += (obj, arg) => UpdateI();

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DBConnect.InsertDeleteDB(String.Format("UPDATE Report SET Comment = '{0}' WHERE ID_Record = {1}", "Запись отменена", dataGridView.Rows[dataGridView.CurrentRow.Index].Cells["ID_Record"].Value.ToString()));
                DBConnect.InsertDeleteDB(String.Format("UPDATE Records SET Status = '{0}' WHERE ID_Record = {1}", "Прием завершен", dataGridView.Rows[dataGridView.CurrentRow.Index].Cells["ID_Record"].Value.ToString()));
                MessageBox.Show("Запись отменена!");
                UpdateI();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try {
                if (dataGridView.SelectedRows.Count != 0)
                {
                    UpdateRecord uRec = new UpdateRecord(Convert.ToInt32(dataGridView.Rows[dataGridView.CurrentRow.Index].Cells["ID_Record"].Value),
                        
                        Convert.ToInt32(dataGridView.Rows[dataGridView.CurrentRow.Index].Cells["ID_Procedure"].Value),
                        Convert.ToInt32(dataGridView.Rows[dataGridView.CurrentRow.Index].Cells["ID_Doc"].Value),
                        Convert.ToInt32(dataGridView.Rows[dataGridView.CurrentRow.Index].Cells["ID_Pat"].Value));
                    uRec.Show();
                    uRec.FormClosed += (obj, arg) => UpdateI();
                }
                else
                {
                    MessageBox.Show("Не выбрана запись для изменения");
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void textBoxID_Pat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void buttonRecordPat_Click(object sender, EventArgs e)
        {
           
            if (textBoxID_Pat.Text != "")
            {
                dataGridView.DataSource = null;
                dataGridView.DataSource = DBConnect.ShowDB(String.Format("SELECT Patients.Surname, Patients.Name, Patients.Patronymic, Records.Time, Records.Data, Procedure.Name, Records.ID_Record FROM [Procedure] INNER JOIN(Patients INNER JOIN Records ON Patients.ID_Pat = Records.ID_Pat) ON Procedure.ID_Procedure = Records.ID_Procedure WHERE Patients.ID_Pat = {0}", Convert.ToInt32(textBoxID_Pat.Text)));
                dataGridView.Columns[0].HeaderText = "Фамилия"; 
                dataGridView.Columns[1].HeaderText = "Имя";
                dataGridView.Columns[2].HeaderText = "Отчество";
                dataGridView.Columns[3].HeaderText = "Время";
                dataGridView.Columns[4].HeaderText = "Дата";
                dataGridView.Columns[5].HeaderText = "Наименование процедуры";
                dataGridView.Columns[6].HeaderText = "Код записи";
                dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                this.dataGridView.Columns["Time"].DefaultCellStyle.Format = "t";
            }
            else
            {
                UpdateI();
                MessageBox.Show("Заполните поле \"Код клиента\"");
            }

        }

        private void buttonRecordDoc_Click(object sender, EventArgs e)
        {
            if (textBoxID_Doc.Text != "")
            {
                dataGridView.DataSource = null;
                dataGridView.DataSource = DBConnect.ShowDB(String.Format("SELECT Doctors.Surname, Doctors.Name, Doctors.Patronymic, Doctors.[Position], Records.[Time], Records.Data, Records.Status, Records.ID_Record  FROM Records, Doctors WHERE Records.Status = '{0}' AND Records.ID_Doc = Doctors.ID_Doc AND Doctors.ID_Doc = {1}", "Ожидание", Convert.ToInt32(textBoxID_Doc.Text)));
                dataGridView.Columns[0].HeaderText = "Фамилия";
                dataGridView.Columns[1].HeaderText = "Имя";
                dataGridView.Columns[2].HeaderText = "Отчество";
                dataGridView.Columns[3].HeaderText = "Должность";
                dataGridView.Columns[4].HeaderText = "Время";
                dataGridView.Columns[5].HeaderText = "Дата";
                dataGridView.Columns[6].HeaderText = "Статус";
                dataGridView.Columns[7].HeaderText = "Код записи";
                dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                this.dataGridView.Columns["Time"].DefaultCellStyle.Format = "t";
            }
            else
            {
                UpdateI();
                MessageBox.Show("Заполните поле \"Код врача\"");
            }
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            try
            {
                string text = comboBoxDep.SelectedItem.ToString();
                string[] str = text.Split((string[])null, StringSplitOptions.RemoveEmptyEntries);
                dataGridView.DataSource = DBConnect.ShowDB(String.Format("SELECT Procedure.Name, Procedure.Cost, Department.Name FROM Department INNER JOIN[Procedure] ON Department.ID_Dep = Procedure.ID_Dep WHERE(((Procedure.ID_Dep) = {0}))", Convert.ToInt32(str[0])));
                dataGridView.Columns[0].HeaderText = "Наименование услуги";
                dataGridView.Columns[1].HeaderText = "Стоимость";
                dataGridView.Columns[2].HeaderText = "Наименование отделения";
                dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                buttonDelete.Visible = false;
                buttonRecord.Visible = false;
                buttonUpdate.Visible = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxIDDep.Text != "")
                {
                    dataGridView.DataSource = null;
                    dataGridView.DataSource = DBConnect.ShowDB(String.Format("SELECT Doctors.Surname, Doctors.Name, Doctors.Patronymic, Doctors.[Position], Department.Name FROM Doctors, Department WHERE Doctors.ID_Dep = Department.ID_Dep AND Department.ID_Dep = {0}", Convert.ToInt32(textBoxIDDep.Text)));
                    dataGridView.Columns[0].HeaderText = "Фамилия";
                    dataGridView.Columns[1].HeaderText = "Имя";
                    dataGridView.Columns[2].HeaderText = "Отчество";
                    dataGridView.Columns[3].HeaderText = "Должность";
                    dataGridView.Columns[4].HeaderText = "Наименование отделения";
                    dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    buttonDelete.Visible = false;
                    buttonRecord.Visible = false;
                    buttonUpdate.Visible = false;
                }
                else {
                    UpdateI();
                    MessageBox.Show("Заполните поле \"Код отделения\"");
                }
                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void textBoxIDDep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void toolStripButtonUpdate_Click(object sender, EventArgs e)
        {
            UpdateI();
        }

    }
}
