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
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }
        void UpdateI()
        {
            dataGridView.DataSource = DBConnect.ShowDB("SELECT * FROM Report");
            dataGridView.Columns[0].HeaderText = "Код записи";
            dataGridView.Columns[1].HeaderText = "Оплата";
            dataGridView.Columns[2].HeaderText = "Комментарий";
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                //MessageBox.Show(comboBoxPay.SelectedItem.ToString());
               // DBConnect.InsertDeleteDB(String.Format("UPDATE Report SET Payment = '{0}', Comment = '{1}' WHERE ID_Record = {2}", comboBoxPay.SelectedText, textBoxComment.Text, Convert.ToInt32(dataGridView.Rows[dataGridView.CurrentRow.Index].Cells["ID_Record"].Value)));
                if (comboBoxPay.SelectedItem.ToString() != "")
                {
                    DBConnect.InsertDeleteDB(String.Format("UPDATE Report SET Payment = '{0}', Comment = '{1}' WHERE ID_Record = {2}", comboBoxPay.SelectedItem.ToString(), textBoxComment.Text, Convert.ToInt32(dataGridView.Rows[dataGridView.CurrentRow.Index].Cells["ID_Record"].Value)));
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
                DBConnect.InsertDeleteDB(String.Format("DELETE * FROM Report WHERE ID_Record = {0}", dataGridView.Rows[dataGridView.CurrentRow.Index].Cells["ID_Record"].Value.ToString()));
                UpdateI();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Report_Load(object sender, EventArgs e)
        {
            UpdateI();
            comboBoxPay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            
        }

        private void buttonNoPay_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView.DataSource = DBConnect.ShowDB(String.Format("SELECT * FROM Report WHERE Payment = '{0}'", "Не оплачено"));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBoxPay.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells["Payment"].Value.ToString();
            textBoxComment.Text = dataGridView.Rows[dataGridView.CurrentRow.Index].Cells["Comment"].Value.ToString();
        }
    }
}
