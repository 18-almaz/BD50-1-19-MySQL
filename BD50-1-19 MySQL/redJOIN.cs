using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BD50_1_19_MySQL
{
    public partial class redJOIN: Form
    {
        public redJOIN()
        {
            InitializeComponent();
            LoadCombobox();
            button1.Visible = true;
        }
        int id;

        public redJOIN(int _id)
        {
            InitializeComponent();
            LoadCombobox();
            id = _id;
            LoadString();
            button2.Visible = true;
            button3.Visible = true;
        }

        private void LoadString()
        {
            MySqlConnection oaConnection = new MySqlConnection
                  ("Server=127.0.0.1;Database=fisenko;Uid=oalmaz;Pwd=123;SslMode=none;charset=utf8");
            MySqlDataAdapter oaDataAdapter = new MySqlDataAdapter
                ("Select id_join_to_brigade, id_staff, id_brigade from joining_in_brigade WHERE id_join_to_brigade=" + id, oaConnection);
            DataTable oaDataTable = new DataTable();
            oaDataAdapter.Fill(oaDataTable);
            comboBox1.SelectedValue = oaDataTable.Rows[0][0];
            comboBox2.SelectedValue = oaDataTable.Rows[0][1];
            comboBox3.SelectedValue = oaDataTable.Rows[0][2];
        }

        private void LoadCombobox()
        {

            MySqlConnection oaConnection = new MySqlConnection
                ("Server=127.0.0.1;Database=fisenko;Uid=oalmaz;Pwd=123;SslMode=none;charset=utf8");
            MySqlDataAdapter oaDataAdapter = new MySqlDataAdapter
                ("Select * from joining_in_brigade", oaConnection);
            DataTable oaDataTable = new DataTable();
            oaDataAdapter.Fill(oaDataTable);
            comboBox1.DataSource = oaDataTable;
            comboBox1.DisplayMember = "id_join_to_brigade";
            comboBox1.ValueMember = "id_join_to_brigade";

            MySqlConnection oaConnection1 = new MySqlConnection
                 ("Server=127.0.0.1;Database=fisenko;Uid=oalmaz;Pwd=123;SslMode=none;charset=utf8");
            MySqlDataAdapter oaDataAdapter1 = new MySqlDataAdapter
                ("Select * FROM joining_in_brigade", oaConnection1);
            DataTable oaDataTable1 = new DataTable();
            oaDataAdapter1.Fill(oaDataTable1);
            comboBox2.DataSource = oaDataTable1;
            comboBox2.DisplayMember = "id_staff";
            comboBox2.ValueMember = "id_staff";

            MySqlConnection oaConnection2 = new MySqlConnection
                ("Server=127.0.0.1;Database=fisenko;Uid=oalmaz;Pwd=123;SslMode=none;charset=utf8");
            MySqlDataAdapter oaDataAdapter2 = new MySqlDataAdapter
                ("Select * from joining_in_brigade", oaConnection2);
            DataTable oaDataTable2 = new DataTable();
            oaDataAdapter2.Fill(oaDataTable2);
            comboBox3.DataSource = oaDataTable2;
            comboBox3.DisplayMember = "id_brigade";
            comboBox3.ValueMember = "id_brigade";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection oaConnection = new MySqlConnection
          ("Server=127.0.0.1;Database=fisenko;Uid=oalmaz;Pwd=123;SslMode=none;charset=utf8");
                MySqlDataAdapter oaDataAdapter = new MySqlDataAdapter
                    ($@"INSERT INTO joining_in_brigade (id_staff, id_brigade) VALUES ('{comboBox2.SelectedValue}', '{comboBox3.SelectedValue}')", oaConnection);
                DataTable oaDataTable = new DataTable();
                oaDataAdapter.Fill(oaDataTable);
                Close();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Невозможно произвести данное действие с данным атрибутом таблицы - он уже используется в других таблицах");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection oaConnection = new MySqlConnection
        ("Server=127.0.0.1;Database=fisenko;Uid=oalmaz;Pwd=123;SslMode=none;charset=utf8");
                MySqlDataAdapter oaDataAdapter = new MySqlDataAdapter
                    ($@"UPDATE joining_in_brigade SET id_staff='{comboBox2.SelectedValue}', id_brigade='{comboBox3.SelectedValue}' WHERE id_join_to_brigade={comboBox1.SelectedValue}", oaConnection);
                DataTable oaDataTable = new DataTable();
                oaDataAdapter.Fill(oaDataTable);
                Close();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Невозможно произвести данное действие с данным атрибутом таблицы - он уже используется в других таблицах");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection oaConnection = new MySqlConnection
         ("Server=127.0.0.1;Database=fisenko;Uid=oalmaz;Pwd=123;SslMode=none;charset=utf8");
                MySqlDataAdapter oaDataAdapter = new MySqlDataAdapter
                    ($@"DELETE FROM joining_in_brigade WHERE id_join_to_brigade={comboBox1.SelectedValue}", oaConnection);
                DataTable oaDataTable = new DataTable();
                oaDataAdapter.Fill(oaDataTable);
                Close();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Невозможно произвести данное действие с данным атрибутом таблицы - он уже используется в других таблицах");
            }
        }

        private void redJOIN_Load(object sender, EventArgs e)
        {

        }
    }
}
