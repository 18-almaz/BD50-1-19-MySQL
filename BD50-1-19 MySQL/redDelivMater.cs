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
    public partial class redDelivMater : Form
    {
        public redDelivMater()
        {
            InitializeComponent();
            LoadCombobox();
            button1.Visible = true;
        }
        int id;

        public redDelivMater(int _id)
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
                ("Select * from delivery_of_material WHERE id_delivery_for_material=" + id, oaConnection);
            DataTable oaDataTable = new DataTable();
            oaDataAdapter.Fill(oaDataTable);
  
        }

        private void LoadCombobox()
        {
            MySqlConnection oaConnection = new MySqlConnection
                ("Server=127.0.0.1;Database=fisenko;Uid=oalmaz;Pwd=123;SslMode=none;charset=utf8");
            MySqlDataAdapter oaDataAdapter = new MySqlDataAdapter
                ("Select * from delivery_of_material", oaConnection);
            DataTable oaDataTable = new DataTable();
            oaDataAdapter.Fill(oaDataTable);
            comboBox1.DataSource = oaDataTable;
            comboBox1.DisplayMember = "id_delivery_for_material";
            comboBox1.ValueMember = "id_delivery_for_material";

            MySqlConnection oaConnection1= new MySqlConnection
               ("Server=127.0.0.1;Database=fisenko;Uid=oalmaz;Pwd=123;SslMode=none;charset=utf8");
            MySqlDataAdapter oaDataAdapter1= new MySqlDataAdapter
                ("Select * from provider", oaConnection1);
            DataTable oaDataTable1= new DataTable();
            oaDataAdapter1.Fill(oaDataTable1);
            comboBox2.DataSource = oaDataTable1;
            comboBox2.DisplayMember = "provider_for_material";
            comboBox2.ValueMember = "id_provider";

            MySqlConnection oaConnection2 = new MySqlConnection
               ("Server=127.0.0.1;Database=fisenko;Uid=oalmaz;Pwd=123;SslMode=none;charset=utf8");
            MySqlDataAdapter oaDataAdapter2 = new MySqlDataAdapter
                ("Select * from material", oaConnection2);
            DataTable oaDataTable2 = new DataTable();
            oaDataAdapter2.Fill(oaDataTable2);
            comboBox3.DataSource = oaDataTable2;
            comboBox3.DisplayMember = "name_of_material_type";
            comboBox3.ValueMember = "id_material";

            MySqlConnection oaConnection3 = new MySqlConnection
               ("Server=127.0.0.1;Database=fisenko;Uid=oalmaz;Pwd=123;SslMode=none;charset=utf8");
            MySqlDataAdapter oaDataAdapter3 = new MySqlDataAdapter
                ("Select * from staff", oaConnection3);
            DataTable oaDataTable3 = new DataTable();
            oaDataAdapter3.Fill(oaDataTable3);
            comboBox4.DataSource = oaDataTable3;
            comboBox4.DisplayMember = "last_name";
            comboBox4.ValueMember = "id_staff";
        }

        private void button1_Click(object sender, EventArgs e)
        {
       
                MySqlConnection oaConnection = new MySqlConnection
          ("Server=127.0.0.1;Database=fisenko;Uid=oalmaz;Pwd=123;SslMode=none;charset=utf8");
                MySqlDataAdapter oaDataAdapter = new MySqlDataAdapter
                    ($@"INSERT INTO delivery_of_material (id_provider, id_material, id_staff) VALUES ('{comboBox2.SelectedValue}', '{comboBox3.SelectedValue}', '{comboBox4.SelectedValue}')", oaConnection);
                DataTable oaDataTable = new DataTable();
                oaDataAdapter.Fill(oaDataTable);
                Close();
            }

        

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection oaConnection = new MySqlConnection
        ("Server=127.0.0.1;Database=fisenko;Uid=oalmaz;Pwd=123;SslMode=none;charset=utf8");
                MySqlDataAdapter oaDataAdapter = new MySqlDataAdapter
                    ($@"UPDATE delivery_of_material SET id_provider='{comboBox2.SelectedValue}', id_material='{comboBox3.SelectedValue}', id_staff='{comboBox4.SelectedValue}'  WHERE id_delivery_for_material={id}", oaConnection);
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
                    ($@"DELETE FROM delivery_of_material WHERE id_delivery_for_material={id}", oaConnection);
                DataTable oaDataTable = new DataTable();
                oaDataAdapter.Fill(oaDataTable);
                Close();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Невозможно произвести данное действие с данным атрибутом таблицы - он уже используется в других таблицах");
            }
        }

        private void redDelivMater_Load(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
