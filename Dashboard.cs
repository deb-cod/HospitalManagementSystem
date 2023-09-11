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

namespace HospitalManagementSystem
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnAddPatient_Click(object sender, EventArgs e)
        {
            btnAddPatient.ForeColor = Color.OrangeRed;
            btnFullHistory.ForeColor = Color.Black;
            btnHospital.ForeColor = Color.Black;
            btnAddDiag.ForeColor = Color.Black;

            panel1.Visible = true;
        }

        private void btnFullHistory_Click(object sender, EventArgs e)
        {
            btnAddPatient.ForeColor = Color.Black;
            btnFullHistory.ForeColor = Color.OrangeRed;
            btnHospital.ForeColor = Color.Black;
            btnAddDiag.ForeColor = Color.Black;
        }

        private void btnAddDiag_Click(object sender, EventArgs e)
        {
            btnAddPatient.ForeColor = Color.Black;
            btnFullHistory.ForeColor = Color.Black;
            btnHospital.ForeColor = Color.Black;
            btnAddDiag.ForeColor = Color.OrangeRed;
        }

        private void btnHospital_Click(object sender, EventArgs e)
        {
            btnAddPatient.ForeColor = Color.Black;
            btnFullHistory.ForeColor = Color.Black;
            btnHospital.ForeColor = Color.OrangeRed;
            btnAddDiag.ForeColor = Color.Black;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                String name = txtName.Text;
                String address = txtAddress.Text;
                Int64 contact = Convert.ToInt64(txtContact.Text);
                int age = Convert.ToInt32(txtAge.Text);
                String gender = comboGender.Text;
                String blood = txtBlood.Text;
                String any = txtAny.Text;
                int pid = Convert.ToInt32(txtPid.Text);

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "data source =LAPTOP-8REHB37C\\SQLEXPRESS; database = hospital_db_2; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "insert into AddPatient values ('" + name + "','" + address + "','" + contact + "','" + age + "','" + gender + "','" + blood + "','" + any + "','" + pid + "')";

                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            txtName.Clear();
            txtAddress.Clear();
            txtContact.Clear();
            txtAge.Clear();
            txtBlood.Clear();
            txtAny.Clear();
            txtPid.Clear();
            comboGender.ResetText();
            MessageBox.Show("New Patient Saved");

        }
    }
}
