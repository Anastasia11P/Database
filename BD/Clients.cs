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
    public partial class Clients : Form
    {
        public Clients()
        {
            InitializeComponent();
        }
        void UpdateI()
        {
            dataGridView.DataSource = DBConnect.ShowDB("SELECT * FROM Patients");

            dataGridView.Columns[0].HeaderText = "Код клиента";
            dataGridView.Columns[1].HeaderText = "Фамилия";
            dataGridView.Columns[2].HeaderText = "Имя";
            dataGridView.Columns[3].HeaderText = "Отчество";
            dataGridView.Columns[4].HeaderText = "Телефон";
            dataGridView.Columns[5].HeaderText = "Дата рождения";

            textBoxID.Text = "";
            maskedTextBoxP.Text = "";
            maskedTextBoxData.Text = "";
            textBoxF.Text = "";
            textBoxN.Text = "";
            textBoxP.Text = "";
        }
        private void MKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }
        private void textBoxID_KeyPress(object sender, KeyPressEventArgs e)
        {
            MKeyPress(sender,e);
        }

        private void textBoxPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            MKeyPress(sender, e);
        }
        private Random Ran;
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (maskedTextBoxP.Text != ""&& maskedTextBoxP.Text.Length >11 && maskedTextBoxData.Text != "" && textBoxF.Text != "" && textBoxN.Text != "" && textBoxP.Text != "")
                {
                    int ran;
                    if (textBoxID.Text != "")
                    {
                        ran = Convert.ToInt32(textBoxID.Text);
                        if (DBConnect.Contains(String.Format("SELECT Name FROM Patients WHERE ID_Pat = {0}", ran)) == true)
                        {
                            MessageBox.Show("Клиент с данным кодом уже существует, выберите другой код клиента.");
                        }
                        else
                        {
                            DBConnect.InsertDeleteDB(String.Format("INSERT INTO Patients (ID_Pat, Surname, Name, Patronymic, Phone, Date_of_birth) VALUES ({0},'{1}','{2}','{3}','{4}','{5}')", ran, textBoxF.Text, textBoxN.Text, textBoxP.Text, maskedTextBoxP.Text, maskedTextBoxData.Text));
                            UpdateI();
                            MessageBox.Show("Данные успешно добавлены!");
                        }

                    }
                    else {
                        ran = Ran.Next(1, 10000);
                        if (DBConnect.Contains(String.Format("SELECT Name FROM Patients WHERE ID_Pat = {0}", ran)) == true)
                        {
                            while (DBConnect.Contains(String.Format("SELECT Name FROM Patients WHERE ID_Pat = {0}", ran)) == true)
                            {
                                ran = Ran.Next(1, 10000);
                            }
                        }
                        else {
                            DBConnect.InsertDeleteDB(String.Format("INSERT INTO Patients (ID_Pat, Surname, Name, Patronymic, Phone, Date_of_birth) VALUES ({0},'{1}','{2}','{3}','{4}','{5}')", ran, textBoxF.Text, textBoxN.Text, textBoxP.Text, maskedTextBoxP.Text, maskedTextBoxData.Text));
                            UpdateI();
                            MessageBox.Show("Данные успешно добавлены!");
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
                if ( maskedTextBoxP.Text != "" && maskedTextBoxP.Text.Length > 11 && maskedTextBoxData.Text != "" && textBoxF.Text != "" && textBoxN.Text != "" && textBoxP.Text != "")
                {
                    int id_P = Convert.ToInt32(dataGridView.Rows[dataGridView.CurrentRow.Index].Cells["ID_Pat"].Value);
                    int ran = Convert.ToInt32(textBoxID.Text);
                    if (textBoxID.Text != "" && (ran != id_P))
                    {
                        if (DBConnect.Contains(String.Format("SELECT Name FROM Patients WHERE ID_Pat = {0}", ran)) == true)
                        {
                            MessageBox.Show("Клиент с данным кодом уже существует, выберите другой код клиента.");
                        }
                        else
                        {
                            id_P = ran;
                            DBConnect.InsertDeleteDB(String.Format("UPDATE Patients SET ID_Pat = {0}, Surname = '{1}', Name = '{2}', Patronymic = '{3}', Phone = '{4}', Date_of_birth = '{5}' WHERE ID_Pat = {6}", id_P, textBoxF.Text, textBoxN.Text, textBoxP.Text, maskedTextBoxP.Text, maskedTextBoxData.Text, Convert.ToInt32(dataGridView.Rows[dataGridView.CurrentRow.Index].Cells["ID_Pat"].Value)));
                            UpdateI();
                            MessageBox.Show("Данные обновлены!");
                        }
                    }
                    else
                    {
                        DBConnect.InsertDeleteDB(String.Format("UPDATE Patients SET ID_Pat = {0}, Surname = '{1}', Name = '{2}', Patronymic = '{3}', Phone = '{4}', Date_of_birth = '{5}' WHERE ID_Pat = {6}", id_P, textBoxF.Text, textBoxN.Text, textBoxP.Text, maskedTextBoxP.Text, maskedTextBoxData.Text, Convert.ToInt32(dataGridView.Rows[dataGridView.CurrentRow.Index].Cells["ID_Pat"].Value)));
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
            
            //DBConnect.InsertDeleteDB(String.Format("DELETE FROM Patients WHERE ID_Pat = {0}", dataGridView.Rows[dataGridView.CurrentRow.Index].Cells["ID_Pat"].Value.ToString()));
            //UpdateI();
            try
            {
                DialogResult result = MessageBox.Show("Удаление приведет к отмене и удалению всех записей пациента.\nПродолжить?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                
                if (result == DialogResult.Yes)
                {
                    // DBConnect.InsertDeleteDB(String.Format("UPDATE Report SET Comment = '{0}' WHERE ID_Record = {1}", "Запись отменена. Причина: удаление данных клиента.", dataGridView.Rows[dataGridView.CurrentRow.Index].Cells["ID_Record"].Value.ToString()));
                    DBConnect.InsertDeleteDB(String.Format("DELETE FROM Patients WHERE ID_Pat = {0}", dataGridView.Rows[dataGridView.CurrentRow.Index].Cells["ID_Pat"].Value.ToString()));
                    UpdateI();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Clients_Load(object sender, EventArgs e)
        {
            UpdateI();
            Ran = new Random((int)DateTime.Now.Ticks);
            maskedTextBoxData.ValidatingType = typeof(System.DateTime);
            //maskedTextBoxP.s
            maskedTextBoxData.TypeValidationCompleted += new TypeValidationEventHandler(maskedTextBoxData_TypeValidationCompleted);
            maskedTextBoxP.TypeValidationCompleted += new TypeValidationEventHandler(maskedTextBoxP_Validated);
           // maskedTextBoxP.Validated += new EventHandler(maskedTextBoxP_Validated);
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            maskedTextBoxData.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells["Date_of_birth"].Value.ToString();
            maskedTextBoxP.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells["Phone"].Value.ToString();
            textBoxID.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells["ID_Pat"].Value.ToString();
            textBoxF.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells["Surname"].Value.ToString();
            textBoxN.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells["Name"].Value.ToString();
            textBoxP.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells["Patronymic"].Value.ToString();
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

        private void maskedTextBoxP_MouseClick(object sender, MouseEventArgs e)
        {
            if (maskedTextBoxP.Text.Length > 2)
            {
                ((MaskedTextBox)sender).SelectionStart = maskedTextBoxP.Text.Length;
            }
            else
            {
                ((MaskedTextBox)sender).SelectionStart = 2;
            }
        }

        private void maskedTextBoxData_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if (!e.IsValidInput)
            {
                toolTipDate.ToolTipTitle = "Некорректное значение даты";
                toolTipDate.Show("Дата должна быть записана в формате: mm/dd/yyyy.", maskedTextBoxData, 0, -20, 5000);
            }
            else
            {
                DateTime userDate = (DateTime)e.ReturnValue;
                if (((userDate >= DateTime.Now)||(userDate<=Convert.ToDateTime(String.Format("01.01.{0}",DateTime.Now.Year-100)))))
                {
                    toolTipDate.ToolTipTitle = "Некорректное значение даты";
                    toolTipDate.Show(String.Format("Дата рождения не может быть позже сегодняшней даты и раньше 01.01.{0}.", DateTime.Now.Year - 100), maskedTextBoxData, 0, -20, 5000);
                    e.Cancel = true;
                }
            }
        }

        private void maskedTextBoxData_MouseClick(object sender, MouseEventArgs e)
        {
            ((MaskedTextBox)sender).SelectionStart = 0;
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
