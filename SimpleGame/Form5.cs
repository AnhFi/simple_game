using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleGame
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        public Form5(int data)
        {
            InitializeComponent();
            tb_diem.Text = data.ToString();
        }

        SqlConnection conn;
        SqlCommand cmd;
        string str = @"Data Source=AFEE\SQLEXPRESS;Initial Catalog=QLPlayer;Integrated Security=True;Encrypt=False";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        void loaddata()
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = " select * from Player ";
            adapter.SelectCommand = cmd;
            table.Clear();
            adapter.Fill(table);
            dgv.DataSource = table;

            int totalRowHeight = dgv.ColumnHeadersHeight;

            foreach (DataGridViewRow row in dgv.Rows)
                totalRowHeight += row.Height;

            dgv.Height = totalRowHeight;

        }

        private void Form5_Load_1(object sender, EventArgs e)
        {
            conn = new SqlConnection(str);
            conn.Open();
            loaddata();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tb_name.ReadOnly = true;
            int i;
            i = dgv.CurrentRow.Index;
            tb_stt.Text = dgv.Rows[i].Cells[0].Value.ToString();
            tb_ma.Text = dgv.Rows[i].Cells[1].Value.ToString();
            tb_name.Text = dgv.Rows[i].Cells[2].Value.ToString();
            tb_diem.Text = dgv.Rows[i].Cells[3].Value.ToString();

        }

        private void bt_them_Click(object sender, EventArgs e)
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "insert into Player values('"+tb_stt.Text+"', '"+tb_ma.Text + "', '"+tb_name.Text+"','"+tb_diem.Text+"')";
            cmd.ExecuteNonQuery();
            loaddata();
        }
        private void bt_xoa_Click(object sender, EventArgs e)
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "Delete from Player where STT= '"+tb_stt.Text+"'";
            cmd.ExecuteNonQuery();
            loaddata();
        }

        private void bt_tangdan_Click(object sender, EventArgs e)
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Player ORDER BY Diem ASC";
            cmd.ExecuteNonQuery();
            loaddata();
        }

        private void UpdateLableForm5(string str)
        {
            lb_diem.Text = str;
        }
    }
}
