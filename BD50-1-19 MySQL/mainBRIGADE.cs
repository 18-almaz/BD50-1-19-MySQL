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
    public partial class mainBRIGADE : Form
    {
        public mainBRIGADE()
        {
            InitializeComponent();
            query = _query;
            LoadTable();
            LoadCombobox();
        }

        string query;
        const string _query = "Select id_brigade, id_object FROM brigade WHERE id_brigade = id_brigade";
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
            redBrigade rb = new redBrigade();
            rb.ShowDialog();
            LoadTable();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dataGridView1[0, e.RowIndex].Value);
                redBrigade rb = new redBrigade(id);
                rb.ShowDialog();
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
                  ("Select * from brigade", oaConnection);
            DataTable oaDataTable = new DataTable();
            oaDataAdapter.Fill(oaDataTable);
            comboBox1.DataSource = oaDataTable;
            comboBox1.DisplayMember = "id_brigade";
            comboBox1.ValueMember = "id_brigade";
            comboBox1.SelectedIndexChanged += new EventHandler(ComboBoxSelectedIndexChanged);
        }
        void ComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex != -1)
            {
                query += $@" and brigade.Id_brigade = {comboBox1.SelectedValue} ";
                LoadTable();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void mainBRIGADE_Load(object sender, EventArgs e)
        {

        }
    }
}