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
    public partial class mainJOIN : Form
    {
        public mainJOIN()
        {
            InitializeComponent();
            dataGridView1.ReadOnly = true;
            query = _query;
            LoadTable();
            LoadCombobox();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        string query;
        const string _query = "Select id_join_to_brigade as 'Номер объединения', joining_in_brigade.id_staff as 'Номер персонала', " +
            "staff.last_name as 'Фамилия персонала', joining_in_brigade.id_brigade as 'Номер бригады' FROM joining_in_brigade, staff " +
            "WHERE joining_in_brigade.id_staff = staff.id_staff";

        private void LoadTable()
        {

            MySqlConnection oaConnection = new MySqlConnection
            ("Server=127.0.0.1;Database=fisenko;Uid=oalmaz;Pwd=123;SslMode=none;charset=utf8");
            MySqlDataAdapter oaDataAdapter = new MySqlDataAdapter(query, oaConnection); //("Select staff.id_staff, staff.id_post, staff.last_name FROM staff, post WHERE staff.id_post = post.id_post ", oaConnection);
            DataTable oaDataTable = new DataTable();
            oaDataAdapter.Fill(oaDataTable);
            dataGridView1.DataSource = oaDataTable;
            dataGridView1.Columns[0].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            redJOIN rj = new redJOIN();
            rj.ShowDialog();
            LoadTable();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dataGridView1[0, e.RowIndex].Value);
                redJOIN rj= new redJOIN(id);
                rj.ShowDialog();
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
                  ("Select * from joining_in_brigade", oaConnection);
            DataTable oaDataTable = new DataTable();
            oaDataAdapter.Fill(oaDataTable);
            comboBox1.DataSource = oaDataTable;
            comboBox1.DisplayMember = "id_staff";
            comboBox1.ValueMember = "id_staff";
            comboBox1.SelectedIndexChanged += new EventHandler(ComboBoxSelectedIndexChanged);

        }
        void ComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex != -1)
            {
                query += $@" and joining_in_brigade.id_staff = {comboBox1.SelectedValue} ";
                LoadTable();
            }
        }

        private void mainJOIN_Load(object sender, EventArgs e)
        {

        }
    }
}
