using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BD50_1_19_MySQL
{
    public partial class mainDelivMater : Form
    {
        public mainDelivMater()
        {
            InitializeComponent();
            query = _query;
            LoadTable();
            LoadCombobox();
        }

        string query;
        const string _query = "Select id_delivery_for_material as 'Номер поставки материалов'," +
            "delivery_of_material.id_provider as 'Номер поставщика'," +
            "delivery_of_material.id_material as 'Номер материала', " +
            "delivery_of_material.id_staff as 'Номер персонала', " +
            "provider.provider_for_material as 'Поставщик материала', " +
            "staff.last_name as 'Фамилия персонала', " +
            "material.name_of_material_type AS 'Название материала' " +
            "FROM delivery_of_material, provider, staff, material " +
            "WHERE " +
            "delivery_of_material.id_staff = staff.id_staff " +
            "AND delivery_of_material.id_provider=provider.id_provider " +
            "AND delivery_of_material.id_material = material.id_material ";
        private void LoadTable()
        {

            MySqlConnection oaConnection = new MySqlConnection
            ("Server=127.0.0.1;Database=fisenko;Uid=oalmaz;Pwd=123;SslMode=none;charset=utf8");
            MySqlDataAdapter oaDataAdapter = new MySqlDataAdapter(query, oaConnection); 
            DataTable oaDataTable = new DataTable();
            oaDataAdapter.Fill(oaDataTable);
            dataGridView1.DataSource = oaDataTable;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            redDelivMater rdm = new redDelivMater();
            rdm.ShowDialog();
            LoadTable();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dataGridView1[0, e.RowIndex].Value);
                redDelivMater rdm = new redDelivMater(id);
                rdm.ShowDialog();
                LoadTable();
            }
            catch (ArgumentOutOfRangeException) { }
            catch (InvalidCastException)
            {
                button1_Click(null, null);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (!checkBox1.Checked)
            {
                comboBox1.SelectedIndex = -1;
            }
            panel1.Visible = checkBox1.Checked;
        }
        private void LoadCombobox()
        {

            MySqlConnection oaConnection = new MySqlConnection
             ("Server=127.0.0.1;Database=fisenko;Uid=oalmaz;Pwd=123;SslMode=none;charset=utf8");
            MySqlDataAdapter oaDataAdapter = new MySqlDataAdapter
                  ("Select id_delivery_for_material from delivery_of_material", oaConnection);
            DataTable oaDataTable = new DataTable();
            oaDataAdapter.Fill(oaDataTable);
            comboBox1.DataSource = oaDataTable;
            comboBox1.DisplayMember = "id_delivery_for_material";
            comboBox1.ValueMember = "id_delivery_for_material";
            comboBox1.SelectedIndexChanged += new EventHandler(ComboBoxSelectedIndexChanged);
        }
        void ComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex != -1)
            {
                query += $@" and delivery_of_material.Id_delivery_for_material = {comboBox1.SelectedValue} ";
                LoadTable();
            }
        }

        private void mainDelivMater_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}