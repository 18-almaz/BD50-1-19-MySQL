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
    public partial class redPOST : Form
    {
        public redPOST()
        {
            InitializeComponent();
            LoadCombobox();
            button1.Visible = true;
        }
        int id;

        public redPOST(int _id)
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
                ("Select * from post WHERE id_post=" + id, oaConnection);
            DataTable oaDataTable = new DataTable();
            oaDataAdapter.Fill(oaDataTable);
            comboBox1.SelectedValue = oaDataTable.Rows[0][1];
            textBox1.Text = oaDataTable.Rows[0][2].ToString();
        }

        private void LoadCombobox()
        {
            try {
                MySqlConnection oaConnection = new MySqlConnection
                    ("Server=127.0.0.1;Database=fisenko;Uid=oalmaz;Pwd=123;SslMode=none;charset=utf8");
                MySqlDataAdapter oaDataAdapter = new MySqlDataAdapter
                    ("Select * from post", oaConnection);
                DataTable oaDataTable = new DataTable();
                oaDataAdapter.Fill(oaDataTable);
                comboBox1.DataSource = oaDataTable;
                comboBox1.DisplayMember = "id_post";
                comboBox1.ValueMember = "name_of_post";
            }
            catch (MySqlException)
            {
                MessageBox.Show("Невозможно произвести данное действие с данным атрибутом таблицы - он уже используется в других таблицах");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection oaConnection = new MySqlConnection
          ("Server=127.0.0.1;Database=fisenko;Uid=oalmaz;Pwd=123;SslMode=none;charset=utf8");
                MySqlDataAdapter oaDataAdapter = new MySqlDataAdapter
                    ($@"INSERT INTO post (name_of_post) VALUES ('{textBox1.Text}')", oaConnection);
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
                    ($@"UPDATE post SET name_of_post='{textBox1.Text}' WHERE id_post={comboBox1.SelectedValue}", oaConnection);
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
                    ($@"DELETE FROM post WHERE id_post={comboBox1.SelectedValue}", oaConnection);
                DataTable oaDataTable = new DataTable();
                oaDataAdapter.Fill(oaDataTable);
                Close();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Невозможно произвести данное действие с данным атрибутом таблицы - он уже используется в других таблицах");
            }
        }

        private void redPOST_Load(object sender, EventArgs e)
        {

        }
    }
}
