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
    public partial class redTYPEOBJECT : Form
    {
        public redTYPEOBJECT()
        {
            InitializeComponent();
            LoadCombobox();
            button1.Visible = true;
        }
        int id;

        public redTYPEOBJECT(int _id)
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
                ("Select * from type_of_object  WHERE id_type_of_object =" + id, oaConnection);
            DataTable oaDataTable = new DataTable();
            oaDataAdapter.Fill(oaDataTable);
            comboBox1.SelectedValue = oaDataTable.Rows[0][1];
            textBox1.Text = oaDataTable.Rows[0][2].ToString();
        }

        private void LoadCombobox()
        {

            MySqlConnection oaConnection = new MySqlConnection
                ("Server=127.0.0.1;Database=fisenko;Uid=oalmaz;Pwd=123;SslMode=none;charset=utf8");
            MySqlDataAdapter oaDataAdapter = new MySqlDataAdapter
                ("Select id_type_of_object FROM type_of_object", oaConnection);
            DataTable oaDataTable = new DataTable();
            oaDataAdapter.Fill(oaDataTable);
            comboBox1.DataSource = oaDataTable;
            comboBox1.DisplayMember = "id_type_of_object";
            comboBox1.ValueMember = "id_type_of_object";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection oaConnection = new MySqlConnection
          ("Server=127.0.0.1;Database=fisenko;Uid=oalmaz;Pwd=123;SslMode=none;charset=utf8");
                MySqlDataAdapter oaDataAdapter = new MySqlDataAdapter
                    ($@"INSERT INTO type_of_object (name_of_type_of_object) VALUES ('{textBox1.Text}')", oaConnection);
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
                    ($@"UPDATE type_of_object SET name_of_type_of_object='{textBox1.Text}' WHERE id_type_of_object ={comboBox1.SelectedValue}", oaConnection);
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
                    ($@"DELETE FROM type_of_object  WHERE id_type_of_object ={comboBox1.SelectedValue}", oaConnection);
                DataTable oaDataTable = new DataTable();
                oaDataAdapter.Fill(oaDataTable);
                Close();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Невозможно произвести данное действие с данным атрибутом таблицы - он уже используется в других таблицах");
            }
        }

        private void redTYPEOBJECT_Load(object sender, EventArgs e)
        {

        }
    }
}