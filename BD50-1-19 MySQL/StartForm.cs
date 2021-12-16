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
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainForm f = new mainForm();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mainMaterial m = new mainMaterial();
            m.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mainBRIGADE mb = new mainBRIGADE();
            mb.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mainBUILDING mbu = new mainBUILDING();
            mbu.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            mainPROVIDER mp = new mainPROVIDER();
            mp.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            mainTECH mt = new mainTECH();
            mt.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            mainDelivMater mdv = new mainDelivMater();
            mdv.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            mainTYPEOBJECT mty = new mainTYPEOBJECT();
            mty.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            mainTYPEACTIVITY mtp = new mainTYPEACTIVITY();
            mtp.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            mainPOST mpo = new mainPOST();
            mpo.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            mainJOIN mj = new mainJOIN();
            mj.ShowDialog();
        }

        private void StartForm_Load(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            mainDelivTech mdtc = new mainDelivTech();
            mdtc.ShowDialog();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            info inf = new info();
            inf.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
