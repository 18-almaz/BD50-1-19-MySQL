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
    public partial class mainPROVIDER : Form
    {
        public mainPROVIDER()
        {
            InitializeComponent();
            query = _query;
            LoadTable();
            dataGridView1.ReadOnly = true;
            LoadCombobox();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        string query;
        const string _query = "Select id_provider as 'Номер поставщика', provider_for_material as 'Поставщик материалов', provider_for_tech as 'Поставщик техники' FROM provider WHERE id_provider = id_provider";

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
            mainDelivMater mm = new mainDelivMater();
            mm.ShowDialog();
            LoadTable();
          
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dataGridView1[0, e.RowIndex].Value);
                redProvider rp = new redProvider(id);
                rp.ShowDialog();
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
            label1.Visible = checkBox1.Checked;
        }
        private void LoadCombobox()
        {

            MySqlConnection oaConnection = new MySqlConnection
             ("Server=127.0.0.1;Database=fisenko;Uid=oalmaz;Pwd=123;SslMode=none;charset=utf8");
            MySqlDataAdapter oaDataAdapter = new MySqlDataAdapter
                  ("Select * from provider", oaConnection);
            DataTable oaDataTable = new DataTable();
            oaDataAdapter.Fill(oaDataTable);
            comboBox1.DataSource = oaDataTable;
            comboBox1.DisplayMember = "provider_for_material";
            comboBox1.ValueMember = "provider_for_material";
            comboBox1.SelectedIndexChanged += new EventHandler(ComboBoxSelectedIndexChanged);
        }
        void ComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex != -1)
            {
                query += $@" and provider.provider_for_material = '{comboBox1.SelectedValue}' ";
                LoadTable();
            }
        }

        private void mainPROVIDER_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            mainDelivTech mt = new mainDelivTech();
            mt.ShowDialog();
            LoadTable();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            redProvider rp = new redProvider();
            rp.ShowDialog();
        }
    }
}
