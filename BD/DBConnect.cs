using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BD
{
    class DBConnect
    {
        static OleDbConnection connection;
        static OleDbCommand command;
        static string com = String.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Persist Security Info=False", System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + "\\DB.accdb");
        private void ConnectTo()
        {
            connection = new OleDbConnection(com);
            command = connection.CreateCommand();
        }

        public DBConnect()
        {
            ConnectTo();
        }
        public static bool Contains(string commC) {
            try
            {
                DataTable table = DBConnect.ShowDB(commC);
                if (table.Rows.Count == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return true;
            }
        }
        public static DataTable ShowDB(string cc)
        {
            DataTable table = new DataTable();
            try
            {
                connection = new OleDbConnection(com);
                OleDbCommand cmd = new OleDbCommand(cc, connection);
                connection.Open();
                cmd.CommandType = CommandType.Text;
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                adapter.Fill(table);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return table;
        }

        public static void InsertDeleteDB(string cc)
        {
            try
            {
                connection = new OleDbConnection(com);
                OleDbCommand cmd = new OleDbCommand(cc, connection);
                cmd.CommandType = CommandType.Text;
                connection.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
