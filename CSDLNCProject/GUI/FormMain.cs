using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;

namespace CSDLNCProject
{
    public partial class FormMain : Form
    {
        public bool isExit = true;
        private NhanVienBLL nhanVienBLL = new NhanVienBLL();
        public event EventHandler Logout;

        public FormMain()
        {
            InitializeComponent();
        }

        private void hệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            
        }

        private void loadNhanVien()
        {
            var listNhanVien = nhanVienBLL.GetAllNhanVien();
            dataGridView1.DataSource = listNhanVien;    
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FormMain_Load_1(object sender, EventArgs e)
        {
            loadNhanVien();
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(isExit)
            Application.Exit();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isExit)
            {
                if (MessageBox.Show("Bạn có muốn thoát chương trình không?", "Cảnh báo", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logout(this, new EventArgs());
        }
    }
}
