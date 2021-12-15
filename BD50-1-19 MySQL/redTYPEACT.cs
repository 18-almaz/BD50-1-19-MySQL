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
    public partial class redTYPEACT : Form
    {
        public redTYPEACT()
        {
            InitializeComponent();
            LoadCombobox();
            button1.Visible = true;
        }
        int id;

        public redTYPEACT(int _id)
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
                ("Select * from type_of_activity WHERE id_activity_type =" + id, oaConnection);
            DataTable oaDataTable = new DataTable();
            oaDataAdapter.Fill(oaDataTable);

            textBox1.Text = oaDataTable.Rows[0][2].ToString();
        }

        private void LoadCombobox()
        {

            MySqlConnection oaConnection = new MySqlConnection
                ("Server=127.0.0.1;Database=fisenko;Uid=oalmaz;Pwd=123;SslMode=none;charset=utf8");
            MySqlDataAdapter oaDataAdapter = new MySqlDataAdapter
                ("Select * from type_of_activity", oaConnection);
            DataTable oaDataTable = new DataTable();
            oaDataAdapter.Fill(oaDataTable);
            comboBox1.DataSource = oaDataTable;
            comboBox1.DisplayMember = "id_activity_type";
            comboBox1.ValueMember = "id_activity_type";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection oaConnection = new MySqlConnection
          ("Server=127.0.0.1;Database=fisenko;Uid=oalmaz;Pwd=123;SslMode=none;charset=utf8");
                MySqlDataAdapter oaDataAdapter = new MySqlDataAdapter
                    ($@"INSERT INTO type_of_activity (name_of_activity_type) VALUES ('{textBox1.Text}')", oaConnection);
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
                    ($@"UPDATE type_of_activity SET name_of_activity_type='{textBox1.Text}' WHERE id_activity_type ={id}", oaConnection);
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
            try {
                MySqlConnection oaConnection = new MySqlConnection
         ("Server=127.0.0.1;Database=fisenko;Uid=oalmaz;Pwd=123;SslMode=none;charset=utf8");
                MySqlDataAdapter oaDataAdapter = new MySqlDataAdapter
                    ($@"DELETE FROM type_of_activity WHERE id_activity_type ={id}", oaConnection);
                DataTable oaDataTable = new DataTable();
                oaDataAdapter.Fill(oaDataTable);
                Close();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Невозможно произвести данное действие с данным атрибутом таблицы - он уже используется в других таблицах");
            }
        }

        private void redTYPEACT_Load(object sender, EventArgs e)
        {

        }
    }
}
