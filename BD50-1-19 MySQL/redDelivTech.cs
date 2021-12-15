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
    public partial class redDelivTech: Form
    {
        public redDelivTech()
        {
            InitializeComponent();
            LoadCombobox();
            insertButton.Visible = true;
            updateButton.Visible = true;
            deleteButton.Visible = true;
        }
        int id;

        public redDelivTech(int _id)
        {
            InitializeComponent();
            LoadCombobox();
            id = _id;
            LoadString();
            updateButton.Visible = true;
            deleteButton.Visible = true;
        }

        private void LoadString()
        {
            MySqlConnection oaConnection = new MySqlConnection
                  ("Server=127.0.0.1;Database=fisenko;Uid=oalmaz;Pwd=123;SslMode=none;charset=utf8");
            MySqlDataAdapter oaDataAdapter = new MySqlDataAdapter
                ("Select * from delivery_of_technic WHERE id_delivery_for_tech=" + id, oaConnection);
            DataTable oaDataTable = new DataTable();
            oaDataAdapter.Fill(oaDataTable);
   
        }

        private void LoadCombobox()
        {

            MySqlConnection oaConnection = new MySqlConnection
                ("Server=127.0.0.1;Database=fisenko;Uid=oalmaz;Pwd=123;SslMode=none;charset=utf8");
            MySqlDataAdapter oaDataAdapter = new MySqlDataAdapter
                ("Select * from delivery_of_technic", oaConnection);
            DataTable oaDataTable = new DataTable();
            oaDataAdapter.Fill(oaDataTable);
            comboBox1.DataSource = oaDataTable;
            comboBox1.DisplayMember = "id_delivery_for_tech";
            comboBox1.ValueMember = "id_delivery_for_tech";

            MySqlConnection oaConnection1 = new MySqlConnection
                ("Server=127.0.0.1;Database=fisenko;Uid=oalmaz;Pwd=123;SslMode=none;charset=utf8");
            MySqlDataAdapter oaDataAdapter1 = new MySqlDataAdapter
                ("Select * from delivery_of_technic", oaConnection1);
            DataTable oaDataTable1 = new DataTable();
            oaDataAdapter1.Fill(oaDataTable1);
            comboBox2.DataSource = oaDataTable1;
            comboBox2.DisplayMember = "id_provider";
            comboBox2.ValueMember = "id_provider";

            MySqlConnection oaConnection2 = new MySqlConnection
                ("Server=127.0.0.1;Database=fisenko;Uid=oalmaz;Pwd=123;SslMode=none;charset=utf8");
            MySqlDataAdapter oaDataAdapter2 = new MySqlDataAdapter
                ("Select * from delivery_of_technic", oaConnection2);
            DataTable oaDataTable2 = new DataTable();
            oaDataAdapter2.Fill(oaDataTable2);
            comboBox3.DataSource = oaDataTable2;
            comboBox3.DisplayMember = "id_tech";
            comboBox3.ValueMember = "id_tech";

            MySqlConnection oaConnection3 = new MySqlConnection
                ("Server=127.0.0.1;Database=fisenko;Uid=oalmaz;Pwd=123;SslMode=none;charset=utf8");
            MySqlDataAdapter oaDataAdapter3 = new MySqlDataAdapter
                ("Select * from delivery_of_technic", oaConnection3);
            DataTable oaDataTable3 = new DataTable();
            oaDataAdapter3.Fill(oaDataTable3);
            comboBox4.DataSource = oaDataTable3;
            comboBox4.DisplayMember = "id_staff";
            comboBox4.ValueMember = "id_staff";

        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection oaConnection = new MySqlConnection
                    ("Server=127.0.0.1;Database=fisenko;Uid=oalmaz;Pwd=123;SslMode=none;charset=utf8");
                MySqlDataAdapter oaDataAdapter = new MySqlDataAdapter
                    ($@"INSERT INTO delivery_of_technic (id_provider,id_tech, id_staff) VALUES ({comboBox1.SelectedValue},'{comboBox2.SelectedValue}', '{comboBox3.SelectedValue}')", oaConnection);
                DataTable oaDataTable = new DataTable();
                oaDataAdapter.Fill(oaDataTable);
                Close();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Невозможно произвести данное действие с данным атрибутом таблицы - он уже используется в других таблицах");
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection oaConnection = new MySqlConnection
                    ("Server=127.0.0.1;Database=fisenko;Uid=oalmaz;Pwd=123;SslMode=none;charset=utf8");
                MySqlDataAdapter oaDataAdapter = new MySqlDataAdapter
                    ($@"UPDATE delivery_of_technic SET id_provider={comboBox2.SelectedValue}, id_tech={comboBox3.SelectedValue}, id_staff={comboBox4.SelectedValue} WHERE id_delivery_for_tech={id}", oaConnection);
                DataTable oaDataTable = new DataTable();
                oaDataAdapter.Fill(oaDataTable);
                Close();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Невозможно произвести данное действие с данным атрибутом таблицы - он уже используется в других таблицах");
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection oaConnection = new MySqlConnection
                     ("Server=127.0.0.1;Database=fisenko;Uid=oalmaz;Pwd=123;SslMode=none;charset=utf8");
                MySqlDataAdapter oaDataAdapter = new MySqlDataAdapter
                    ($@"DELETE FROM delivery_of_technic WHERE id_delivery_for_tech={id}", oaConnection);
                DataTable oaDataTable = new DataTable();
                oaDataAdapter.Fill(oaDataTable);
                Close();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Невозможно произвести данное действие с данным атрибутом таблицы - он уже используется в других таблицах");
            }
        }

        private void redDelivTech_Load(object sender, EventArgs e)
        {

        }
    }
}
