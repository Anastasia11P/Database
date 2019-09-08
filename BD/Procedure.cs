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
    public partial class Procedure : Form
    {
        public Procedure()
        {
            InitializeComponent();
        }
        private Random Ran;
        void UpdateI()
        {
            dataGridView.DataSource = DBConnect.ShowDB("SELECT * FROM [Procedure]");
            dataGridView.Columns[0].HeaderText = "Код услуги";
            dataGridView.Columns[1].HeaderText = "Наименование";
            dataGridView.Columns[2].HeaderText = "Стоимость";
            dataGridView.Columns[3].HeaderText = "Код отделения";
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            comboBoxIDDep.Text = "";
            textBoxName.Text = "";
            textBoxID_Procedure.Text = "";
            textBoxCost.Text = "";
        }
        private void textBoxID_Dep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void Procedure_Load(object sender, EventArgs e)
        {
            UpdateI();
            Ran = new Random((int)DateTime.Now.Ticks);
            DataTable table = DBConnect.ShowDB("SELECT ID_Dep FROM Department");
            List<string> sList2 = new List<string>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                sList2.Add(String.Format((table.Rows[i]["ID_Dep"]).ToString()));
            }
            comboBoxIDDep.DataSource = sList2;
            comboBoxIDDep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxIDDep.Text != "" && textBoxName.Text != "" && textBoxCost.Text != "")
                {
                    int ran;
                    if (textBoxID_Procedure.Text != "")
                    {
                        ran = Convert.ToInt32(textBoxID_Procedure.Text);
                        if (DBConnect.Contains(String.Format("SELECT Name FROM [Procedure] WHERE ID_Procedure = {0}", ran)) == true)
                        {
                            MessageBox.Show("Процедура с данным кодом уже существует, выберите другой код процедуры.");
                        }
                        else
                        {
                            DBConnect.InsertDeleteDB(String.Format("INSERT INTO [Procedure] (ID_Procedure, Name, Cost, ID_Dep) VALUES ({0},'{1}','{2}',{3})", ran, textBoxName.Text, textBoxCost.Text, Convert.ToInt32(comboBoxIDDep.Text)));
                            MessageBox.Show("Процедура успешно добавлена!");
                            UpdateI();
                        }
                       
                    }
                    else {
                        ran = Ran.Next(1, 10000);
                        if (DBConnect.Contains(String.Format("SELECT Name FROM [Procedure] WHERE ID_Procedure = {0}", ran)) == true)
                        {
                            while (DBConnect.Contains(String.Format("SELECT Name FROM [Procedure] WHERE ID_Procedure = {0}", ran)) == true)
                            {
                                ran = Ran.Next(1, 10000);
                            }
                        }
                        else {
                            DBConnect.InsertDeleteDB(String.Format("INSERT INTO [Procedure] (ID_Procedure, Name, Cost, ID_Dep) VALUES ({0},'{1}','{2}',{3})", ran, textBoxName.Text, textBoxCost.Text, Convert.ToInt32(comboBoxIDDep.Text)));
                            MessageBox.Show("Процедура успешно добавлена!");
                            UpdateI();
                        }
                        
                    }
                    
                }
                else
                {
                    MessageBox.Show("Заполнены не все поля.");
                }
                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int id_P = Convert.ToInt32(dataGridView.Rows[dataGridView.CurrentRow.Index].Cells["ID_Procedure"].Value);
                int ran = Convert.ToInt32(textBoxID_Procedure.Text);
              
                if (comboBoxIDDep.Text != "" && textBoxName.Text != "" && textBoxCost.Text != "")
                {
                    if (textBoxID_Procedure.Text != "" && (ran != id_P))
                    {
                        if (DBConnect.Contains(String.Format("SELECT Name FROM [Procedure] WHERE ID_Procedure = {0}", ran)) == true)
                        {
                            MessageBox.Show("Услуга с данным кодом уже существует, выберите другой код.");
                        }
                        else
                        {
                            id_P = ran;
                            DBConnect.InsertDeleteDB(String.Format("UPDATE [Procedure] SET ID_Procedure = {0}, Name = '{1}', Cost = '{2}', ID_Dep = {3} WHERE ID_Procedure = {4}", id_P, textBoxName.Text, textBoxCost.Text, Convert.ToInt32(comboBoxIDDep.Text), Convert.ToInt32(dataGridView.Rows[dataGridView.CurrentRow.Index].Cells["ID_Procedure"].Value)));
                            UpdateI();
                            MessageBox.Show("Данные обновлены!");
                        }
                    }
                }
                else
                {
                    DBConnect.InsertDeleteDB(String.Format("UPDATE [Procedure] SET ID_Procedure = {0}, Name = '{1}', Cost = '{2}', ID_Dep = {3} WHERE ID_Procedure = {4}", id_P, textBoxName.Text, textBoxCost.Text, Convert.ToInt32(comboBoxIDDep.Text), Convert.ToInt32(dataGridView.Rows[dataGridView.CurrentRow.Index].Cells["ID_Procedure"].Value)));
                    UpdateI();
                    MessageBox.Show("Данные обновлены!");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Удаление приведет к удалению всех записей на данную процедуру.\nПродолжить?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    //DBConnect.InsertDeleteDB(String.Format("UPDATE Report SET Comment = '{0}' WHERE ID_Record = {1}", "Запись отменена. Причина: Удаление данных по процедуре.", dataGridView.Rows[dataGridView.CurrentRow.Index].Cells["ID_Record"].Value.ToString()));
                    DBConnect.InsertDeleteDB(String.Format("DELETE * FROM [Procedure] WHERE ID_Procedure = {0}", dataGridView.Rows[dataGridView.CurrentRow.Index].Cells["ID_Procedure"].Value.ToString()));
                    UpdateI();
                }
               
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void textBoxID_Procedure_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBoxIDDep.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells["ID_Dep"].Value.ToString();
            textBoxName.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells["Name"].Value.ToString();
            textBoxID_Procedure.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells["ID_Procedure"].Value.ToString();
            textBoxCost.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells["Cost"].Value.ToString();
        }

        private void textBoxCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }
    }
}
