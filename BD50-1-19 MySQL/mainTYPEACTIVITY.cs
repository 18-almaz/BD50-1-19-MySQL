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
    public partial class mainTYPEACTIVITY : Form
    {
        public mainTYPEACTIVITY()
        {
          
            InitializeComponent();
            query = _query;
            LoadTable();
            LoadCombobox();
            dataGridView1.ReadOnly = true;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        string query;
        const string _query = "Select id_activity_type as 'Номер вида работ', name_of_activity_type as 'Нахвание вида работ' FROM type_of_activity";
        private void LoadTable()
        {

            MySqlConnection oaConnection = new MySqlConnection
            ("Server=127.0.0.1;Database=fisenko;Uid=oalmaz;Pwd=123;SslMode=none;charset=utf8");
            MySqlDataAdapter oaDataAdapter = new MySqlDataAdapter(query, oaConnection);
            DataTable oaDataTable = new DataTable();
            oaDataAdapter.Fill(oaDataTable);
            dataGridView1.DataSource = oaDataTable;
            dataGridView1.Columns[0].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            redTYPEACT rta = new redTYPEACT();
            rta.ShowDialog();
            LoadTable();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dataGridView1[0, e.RowIndex].Value);
                redTYPEACT rta = new redTYPEACT(id);
                rta.ShowDialog();
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
                  ("Select * from type_of_activity", oaConnection);
            DataTable oaDataTable = new DataTable();
            oaDataAdapter.Fill(oaDataTable);
            comboBox1.DataSource = oaDataTable;
            comboBox1.DisplayMember = "name_of_activity_type";
            comboBox1.ValueMember = "id_activity_type";
            comboBox1.SelectedIndexChanged += new EventHandler(ComboBoxSelectedIndexChanged);
        }
        void ComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex != -1)
            {
                query += $@" where type_of_activity.id_activity_type = {comboBox1.SelectedValue} ";
                LoadTable();
            }
        }


        private void mainTYPEACTIVITY_Load(object sender, EventArgs e)
        {

        }
    }
}
