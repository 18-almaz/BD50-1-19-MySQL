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
    public partial class EditStaffForm : Form
    {
        public EditStaffForm()
        {
            InitializeComponent();
            LoadCombobox();
            insertButton.Visible = true;
        }
        int id;

        public EditStaffForm(int _id)
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
            try {
                MySqlConnection oaConnection = new MySqlConnection
                      ("Server=127.0.0.1;Database=fisenko;Uid=oalmaz;Pwd=123;SslMode=none;charset=utf8");
                MySqlDataAdapter oaDataAdapter = new MySqlDataAdapter
                    ("Select * from staff WHERE id_staff=" + id, oaConnection);
                DataTable oaDataTable = new DataTable();
                oaDataAdapter.Fill(oaDataTable);
                comboBox1.SelectedValue = oaDataTable.Rows[0][1];
                fio.Text = oaDataTable.Rows[0][2].ToString();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Невозможно произвести данное действие с данным атрибутом таблицы - он уже используется в других таблицах");
            }
        }

        private void LoadCombobox()
        {
            try
            {
                MySqlConnection oaConnection = new MySqlConnection
                    ("Server=127.0.0.1;Database=fisenko;Uid=oalmaz;Pwd=123;SslMode=none;charset=utf8");
                MySqlDataAdapter oaDataAdapter = new MySqlDataAdapter
                    ("Select * from post", oaConnection);
                DataTable oaDataTable = new DataTable();
                oaDataAdapter.Fill(oaDataTable);
                comboBox1.DataSource = oaDataTable;
                comboBox1.DisplayMember = "name_of_post";
                comboBox1.ValueMember = "id_post";
            }
            catch (MySqlException)
            {
                MessageBox.Show("Невозможно произвести данное действие с данным атрибутом таблицы - он уже используется в других таблицах");
            }
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection oaConnection = new MySqlConnection
                    ("Server=127.0.0.1;Database=fisenko;Uid=oalmaz;Pwd=123;SslMode=none;charset=utf8");
                MySqlDataAdapter oaDataAdapter = new MySqlDataAdapter
                    ($@"INSERT INTO staff (id_post,last_name) VALUES ({comboBox1.SelectedValue},'{fio.Text}')", oaConnection);
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
            MySqlConnection oaConnection = new MySqlConnection
                ("Server=127.0.0.1;Database=fisenko;Uid=oalmaz;Pwd=123;SslMode=none;charset=utf8");
            MySqlDataAdapter oaDataAdapter = new MySqlDataAdapter
                ($@"UPDATE staff SET id_post='{comboBox1.SelectedValue}', last_name='{fio.Text}' WHERE id_staff={id}", oaConnection);
            DataTable oaDataTable = new DataTable();
            oaDataAdapter.Fill(oaDataTable);
            Close();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            MySqlConnection oaConnection = new MySqlConnection
                 ("Server=127.0.0.1;Database=fisenko;Uid=oalmaz;Pwd=123;SslMode=none;charset=utf8");
            MySqlDataAdapter oaDataAdapter = new MySqlDataAdapter
                ($@"DELETE FROM staff WHERE id_staff={id}", oaConnection);
            DataTable oaDataTable = new DataTable();
            oaDataAdapter.Fill(oaDataTable);
            Close();
        }

        private void firmsNaim_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void fio_TextChanged(object sender, EventArgs e)
        {

        }

        private void EditStaffForm_Load(object sender, EventArgs e)
        {

        }
    }
}
