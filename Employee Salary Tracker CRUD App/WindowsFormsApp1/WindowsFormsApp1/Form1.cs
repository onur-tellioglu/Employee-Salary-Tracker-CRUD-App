using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void PageRefresh()
        {
            dataGridView1.DataSource = CRUD.List("Select * from Customer");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            PageRefresh();
        }

        void ClearAll()
        {
            foreach (Control item in this.panel2.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
            dateTimePicker1.Value = DateTime.Now;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = CRUD.List("Select * from Customer Where Name like '%"+txtSearch.Text+"%' or Surname like '%"
                +txtSearch.Text+"%'");
        }

        SqlCommand cmd;
        private void AddBtn_Click(object sender, EventArgs e)
        {
            string sql = "insert into Customer(Name, Surname, Phone, Salary, Date) values('"+txtName.Text + "','" + 
                txtSurname.Text + "','" + txtPhone.Text + "',@Salary, @Date)";

            cmd = new SqlCommand();
            cmd.Parameters.Add("@Salary", SqlDbType.Decimal).Value = decimal.Parse(txtSalary.Text);
            cmd.Parameters.Add("@Date", SqlDbType.Date).Value = dateTimePicker1.Value;

            CRUD.ESG(sql, cmd);
            PageRefresh();
            ClearAll();
        }

        private void txt_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ClrBtn_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtSurname.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtPhone.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtSalary.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            string sql = "Update Customer Set Name = '" + txtName.Text + "', Surname = '" + txtSurname.Text 
                + "', Phone = '" + txtPhone.Text + "', Salary = @Salary, Date = @Date Where ID = '" + txtID.Text + "' ";

            cmd = new SqlCommand();
            cmd.Parameters.Add("@Salary", SqlDbType.Decimal).Value = decimal.Parse(txtSalary.Text);
            cmd.Parameters.Add("@Date", SqlDbType.Date).Value = dateTimePicker1.Value;

            CRUD.ESG(sql, cmd);
            PageRefresh();
            ClearAll();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Are you sure about deleting this customer?", "Warning!",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);


            if (dialog == DialogResult.Yes)
            {
                string sql = "Delete from Customer Where ID = '" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "' ";

                cmd = new SqlCommand();

                CRUD.ESG(sql, cmd);
                PageRefresh();
                ClearAll();
            }
        }
    }
}