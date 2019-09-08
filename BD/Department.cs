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
    public partial class Department : Form
    {
        public Department()
        {
            InitializeComponent();
        }

        void UpdateI()
        {
            dataGridView.DataSource = DBConnect.ShowDB("SELECT * FROM Department");
            dataGridView.Columns[0].HeaderText = "Код отделения";
            dataGridView.Columns[1].HeaderText = "Наименование";
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private Random Ran;
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try {
                if (textBoxName.Text != "")
                {
                    if (textBoxID.Text != "")
                    {
                        int ran = Convert.ToInt32(textBoxID.Text);
                        if (DBConnect.Contains(String.Format("SELECT Name FROM Department WHERE ID_Dep = {0}", ran)) == true)
                        {
                            MessageBox.Show("Отделение с данным кодом уже существует, выберите другой код отделения.");
                        }
                        else
                        {
                            DBConnect.InsertDeleteDB(String.Format("INSERT INTO Department (ID_Dep, Name) VALUES ({0},'{1}')", ran, textBoxName.Text.ToString()));
                            textBoxID.Text = "";
                            textBoxName.Text = "";
                            UpdateI();
                            MessageBox.Show("Отделение успешно добавлено!");
                        }
                    }
                    else {
                        int ran = Ran.Next(1, 10000);
                        if (DBConnect.Contains(String.Format("SELECT Name FROM Department WHERE ID_Dep = {0}", ran)) == true)
                        {
                            while (DBConnect.Contains(String.Format("SELECT Name FROM Department WHERE ID_Dep = {0}", ran)) == true)
                            {
                                ran = Ran.Next(1, 10000);
                            }
                        }
                        else
                        {
                            DBConnect.InsertDeleteDB(String.Format("INSERT INTO Department (ID_Dep, Name) VALUES ({0},'{1}')", ran, textBoxName.Text.ToString()));
                            textBoxID.Text = "";
                            textBoxName.Text = "";
                            MessageBox.Show("Отделение успешно добавлено!");
                            UpdateI();
                        }
                    }
                    
                }
                else {
                    MessageBox.Show("Заполнены не все поля.");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                //DataTable table = DBConnect.ShowDB(String.Format("SELECT ID_Dep, Name FROM Department WHERE ID_Dep = {0}", dataGridView.Rows[dataGridView.CurrentRow.Index].Cells["ID_Dep"].Value.ToString()));
                //int ID_Dep = Convert.ToInt32(table.Rows[0]["ID_Dep"]);
                //string Name = table.Rows[0]["Name"].ToString();
                if ((textBoxID.Text != "")&& (textBoxName.Text != ""))
                {
                    DBConnect.InsertDeleteDB(String.Format("UPDATE Department SET ID_Dep = {0}, Name = '{1}' WHERE ID_Dep = {2}", Convert.ToInt32(textBoxID.Text), textBoxName.Text, Convert.ToInt32(dataGridView.Rows[dataGridView.CurrentRow.Index].Cells["ID_Dep"].Value)));
                    textBoxID.Text = "";
                    textBoxName.Text = "";
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
                DialogResult result = MessageBox.Show("Удаление приведет к удалению всех записей, отоносящихся к данному отделению.\nПродолжить?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    DBConnect.InsertDeleteDB(String.Format("DELETE * FROM Department WHERE ID_Dep = {0}", dataGridView.Rows[dataGridView.CurrentRow.Index].Cells["ID_Dep"].Value.ToString()));
                    UpdateI();
                    textBoxID.Text = "";
                    textBoxName.Text = "";
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }


        private void textBoxID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void Department_Load(object sender, EventArgs e)
        {
            UpdateI();
            Ran = new Random((int)DateTime.Now.Ticks);
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxID.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells["ID_Dep"].Value.ToString();
            textBoxName.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells["Name"].Value.ToString();
        }
    }
}
