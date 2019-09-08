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
    public partial class Doctors : Form
    {
        public Doctors()
        {
            InitializeComponent();
        }
        private Random Ran;
        private void Doctors_Load(object sender, EventArgs e)
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
        void UpdateI()
        {
            dataGridView.DataSource = DBConnect.ShowDB("SELECT * FROM Doctors");

            dataGridView.Columns[0].HeaderText = "Код врача";
            dataGridView.Columns[1].HeaderText = "Фамилия";
            dataGridView.Columns[2].HeaderText = "Имя";
            dataGridView.Columns[3].HeaderText = "Отчество";
            dataGridView.Columns[4].HeaderText = "Должность";
            dataGridView.Columns[5].HeaderText = "Телефон";
            dataGridView.Columns[6].HeaderText = "E-mail";
            dataGridView.Columns[7].HeaderText = "Код отделения";
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            textBoxID.Text = "";
            maskedTextBoxP.Text = "";
            textBoxPosition.Text = "";
            textBoxF.Text = "";
            textBoxN.Text = "";
            textBoxP.Text = "";
            textBoxE_mail.Text = "";
            comboBoxIDDep.Text = "";
        }
        private void MKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }
        private void textBoxId_KeyPress(object sender, KeyPressEventArgs e)
        {
            MKeyPress(sender, e);
        }

        private void textBoxID_Dep_KeyPress(object sender, KeyPressEventArgs e)
        {
            MKeyPress(sender, e);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if ( maskedTextBoxP.Text != ""&& maskedTextBoxP.Text.Length >11 && textBoxF.Text != "" && textBoxN.Text != "" && textBoxP.Text != "" && textBoxPosition.Text != "" && comboBoxIDDep.Text != "")
                {
                    int ran;
                    if (textBoxID.Text != "")
                    {
                       ran = Convert.ToInt32(textBoxID.Text);
                       if (DBConnect.Contains(String.Format("SELECT Name FROM Doctors WHERE ID_Doc = {0}", ran)) == true)
                       {
                           MessageBox.Show("Врач с данным кодом уже существует, выберите другой код врача.");
                       }else{
                            DBConnect.InsertDeleteDB(String.Format("INSERT INTO Doctors (ID_Doc, Surname, Name, Patronymic, [Position], Phone, E_mail, ID_Dep) VALUES ({0},'{1}','{2}','{3}','{4}','{5}','{6}', {7})", ran, textBoxF.Text, textBoxN.Text, textBoxP.Text, textBoxPosition.Text, maskedTextBoxP.Text, textBoxE_mail.Text, comboBoxIDDep.Text));
                            UpdateI();
                            MessageBox.Show("Новый сотрудник успешно добавлен!");
                        }
                            
                    }
                    else {
                        ran = Ran.Next(1, 10000);
                        if (DBConnect.Contains(String.Format("SELECT Name FROM Doctors WHERE ID_Doc = {0}", ran)) == true)
                        {
                            while (DBConnect.Contains(String.Format("SELECT Name FROM Doctors WHERE ID_Doc = {0}", ran)) == true)
                            {
                                ran = Ran.Next(1, 10000);
                            }
                        }
                        else
                        {
                            DBConnect.InsertDeleteDB(String.Format("INSERT INTO Doctors (ID_Doc, Surname, Name, Patronymic, [Position], Phone, E_mail, ID_Dep) VALUES ({0},'{1}','{2}','{3}','{4}','{5}','{6}', {7})", ran, textBoxF.Text, textBoxN.Text, textBoxP.Text, textBoxPosition.Text, maskedTextBoxP.Text, textBoxE_mail.Text, comboBoxIDDep.Text));
                            UpdateI();
                            MessageBox.Show("Новый сотрудник успешно добавлен!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Заполнены не все поля или заданы некорректные значения.");
                }
                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (maskedTextBoxP.Text != "" && maskedTextBoxP.Text.Length > 11 && textBoxF.Text != "" && textBoxN.Text != "" && textBoxP.Text != "" && textBoxPosition.Text != "" && comboBoxIDDep.Text != "" )
                {
                    int id_D = Convert.ToInt32(dataGridView.Rows[dataGridView.CurrentRow.Index].Cells["ID_Doc"].Value);
                    int ran = Convert.ToInt32(textBoxID.Text);
                    if (textBoxID.Text != "" && (ran != id_D))
                    {
                        if (DBConnect.Contains(String.Format("SELECT Name FROM Doctors WHERE ID_Doc = {0}", ran)) == true)
                        {
                            MessageBox.Show("Врач с данным кодом уже существует, выберите другой код врача.");
                        }
                        else
                        {
                            id_D = ran;
                            DBConnect.InsertDeleteDB(String.Format("UPDATE Doctors SET ID_Doc = {0}, Surname = '{1}', Name = '{2}', Patronymic = '{3}', [Position] = '{4}', Phone = '{5}', E_mail = '{6}', ID_Dep = {7} WHERE ID_Doc = {8}", id_D, textBoxF.Text, textBoxN.Text, textBoxP.Text, textBoxPosition.Text, maskedTextBoxP.Text, textBoxE_mail.Text, Convert.ToInt32(comboBoxIDDep.Text), Convert.ToInt32(dataGridView.Rows[dataGridView.CurrentRow.Index].Cells["ID_Doc"].Value)));
                            UpdateI();
                            MessageBox.Show("Данные обновлены!");
                        }
                    }
                    else {
                        DBConnect.InsertDeleteDB(String.Format("UPDATE Doctors SET ID_Doc = {0}, Surname = '{1}', Name = '{2}', Patronymic = '{3}', [Position] = '{4}', Phone = '{5}', E_mail = '{6}', ID_Dep = {7} WHERE ID_Doc = {8}", id_D, textBoxF.Text, textBoxN.Text, textBoxP.Text, textBoxPosition.Text, maskedTextBoxP.Text, textBoxE_mail.Text, Convert.ToInt32(comboBoxIDDep.Text), Convert.ToInt32(dataGridView.Rows[dataGridView.CurrentRow.Index].Cells["ID_Doc"].Value)));
                        UpdateI();
                        MessageBox.Show("Данные обновлены!");
                    }
                }
                else
                {
                    MessageBox.Show("Заполнены не все поля или заданы некорректные значения.");
                }
                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Удаление приведет к отмене всех записей к врачу и удалению информации по соотвествующим записям. \nПродолжить?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                
                if (result== DialogResult.Yes)
                {
                   // DBConnect.InsertDeleteDB(String.Format("UPDATE Report SET Comment = '{0}' WHERE ID_Record = {1}", "Запись отменена. Причина: увольнение принимающего врача.", dataGridView.Rows[dataGridView.CurrentRow.Index].Cells["ID_Record"].Value.ToString()));
                    DBConnect.InsertDeleteDB(String.Format("DELETE * FROM Doctors WHERE ID_Doc = {0}", dataGridView.Rows[dataGridView.CurrentRow.Index].Cells["ID_Doc"].Value.ToString()));
                    UpdateI();
                }
                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }


        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBoxIDDep.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells["ID_Dep"].Value.ToString();
            textBoxPosition.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells["Position"].Value.ToString();
            textBoxID.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells["ID_Doc"].Value.ToString();
            textBoxF.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells["Surname"].Value.ToString();
            textBoxN.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells["Name"].Value.ToString();
            textBoxP.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells["Patronymic"].Value.ToString();
            textBoxE_mail.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells["E_mail"].Value.ToString();
            maskedTextBoxP.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells["Phone"].Value.ToString(); 
        }

        private void textBoxF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetter(e.KeyChar) && e.KeyChar != Convert.ToChar(8) && e.KeyChar != Convert.ToChar(32))
            {
                e.Handled = true;
            }
        }

        private void textBoxN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetter(e.KeyChar) && e.KeyChar != Convert.ToChar(8) && e.KeyChar != Convert.ToChar(32))
            {
                e.Handled = true;
            }
        }

        private void textBoxP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetter(e.KeyChar) && e.KeyChar != Convert.ToChar(8) && e.KeyChar != Convert.ToChar(32))
            {
                e.Handled = true;
            }
        }

        private void textBoxPosition_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetter(e.KeyChar) && e.KeyChar != Convert.ToChar(8) && e.KeyChar != Convert.ToChar(32)&&(!Char.IsPunctuation(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        

        private void maskedTextBoxP_MouseClick(object sender, MouseEventArgs e)
        {
            if (maskedTextBoxP.Text.Length >2)
            {
                ((MaskedTextBox)sender).SelectionStart = maskedTextBoxP.Text.Length;
            }
            else {
                ((MaskedTextBox)sender).SelectionStart = 2;
            }
        }

        private void maskedTextBoxP_Validated(object sender, EventArgs e)
        {
            string str = maskedTextBoxP.Text;
            if (str.Length < 12)
            {
                toolTipP.ToolTipTitle = "Некорректное значение";
                toolTipP.Show("Проверьте правильность введенного номера.", maskedTextBoxP, 0, -20, 5000);
            }
        }
    }
}
