using Assignment_10._3._1.Data;
using Assignment_10._3._1.Services;
using System.Xml.Linq;
namespace Assignment_10._3._1
{
    public partial class Form1 : Form
    {

        CRUD CRUD = new CRUD();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = CRUD.GetEmployees();
            Submitbtn.Enabled = false;
            Updatebtn.Enabled = false;
            foreach (var dept in Records.context.Departments)
            {
                comboBox1.Items.Add(dept.DepartmentName);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void AddNewbtn_Click(object sender, EventArgs e)
        {
            IDtxtbox.Text = Guid.NewGuid().ToString();
            IDtxtbox.ReadOnly = true;


            Nametxtbox.Clear();
            salarytxtbox.Clear();
            comboBox1.SelectedIndex = -1;
            Submitbtn.Enabled = true;
        }

        private void Submitbtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(IDtxtbox.Text) && !string.IsNullOrEmpty(Nametxtbox.Text) && !string.IsNullOrEmpty(salarytxtbox.Text) && comboBox1.SelectedIndex != -1)
            {
                Models.Employee emp = new Models.Employee()
                {
                    EmployeeId = IDtxtbox.Text,
                    EmployeeName = Nametxtbox.Text,
                    Salary = Convert.ToDouble(salarytxtbox.Text),
                    DepartmentId = comboBox1.SelectedIndex + 1
                };
                CRUD.AddEmployee(emp);
                dataGridView1.DataSource = CRUD.GetEmployees();
                Submitbtn.Enabled = false;
                IDtxtbox.ReadOnly = false;
            }
            else
            {
                MessageBox.Show("Please fill all fields");
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            var id = dataGridView1.CurrentRow.Cells["EmployeeId"].Value.ToString();
            CRUD.DeleteEmployee(id);
            dataGridView1.DataSource = CRUD.GetEmployees();
        }

        private void SelectUpdatebtn_Click(object sender, EventArgs e)
        {
            var id = dataGridView1.CurrentRow.Cells["EmployeeId"].Value.ToString(); // Get the selected employee ID
            var emp = CRUD.GetEmployeeById(id); // Retrieve the employee details using the ID
            if (emp != null)
            {
                IDtxtbox.Text = emp.EmployeeId;
                Nametxtbox.Text = emp.EmployeeName;
                salarytxtbox.Text = emp.Salary.ToString();
                comboBox1.SelectedIndex = emp.DepartmentId - 1; // Assuming DepartmentId starts from 1
                IDtxtbox.ReadOnly = true;
                Updatebtn.Enabled = true;
                Submitbtn.Enabled = false;
            }
            else
            {
                MessageBox.Show("Employee not found");
            }
        }

        private void Updatebtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(IDtxtbox.Text) && !string.IsNullOrEmpty(Nametxtbox.Text) && !string.IsNullOrEmpty(salarytxtbox.Text) && comboBox1.SelectedIndex != -1)
            {
                var id = IDtxtbox.Text;
                var emptoupdate = CRUD.GetEmployeeById(id);
                emptoupdate.EmployeeName = Nametxtbox.Text;
                emptoupdate.Salary = Convert.ToDouble(salarytxtbox.Text);
                emptoupdate.DepartmentId = comboBox1.SelectedIndex + 1;
                CRUD.UpdateEmployee(id, emptoupdate);   // Update the employee details
                dataGridView1.DataSource = CRUD.GetEmployees(); // Refresh the DataGridView
                Updatebtn.Enabled = false;
            }
            else
            {
                MessageBox.Show("Please fill all fields");
            }
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
