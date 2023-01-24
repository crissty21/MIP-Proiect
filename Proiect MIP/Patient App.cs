using Working_With_Data;

namespace Proiect_MIP
{
    public partial class Patient_App : Form
    {
        private Patient patient = new Patient();
        private TextBox txtUsername = new TextBox();
        private TextBox txtCNP = new TextBox();
        private TextBox txtLastName = new TextBox();
        private TextBox txtFirstName = new TextBox();

        public Patient_App(int patientID)
        {
            InitializeComponent();
            try
            {
                patient = get_Patient(patientID);
            }
            catch (Exception e)
            {
                // Handle the exception
                MessageBox.Show("Error: " + e.Message);
            }

            create_Components();
        }

        private void create_Components()
        {
            this.Size = new Size(450, 320);
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblUsername = new Label();
            lblUsername.Text = "Username:";
            lblUsername.Location = new Point(20, 20);
            lblUsername.AutoSize = true;

            txtUsername = new TextBox();
            txtUsername.Location = new Point(20, 40);
            txtUsername.Size = new Size(410, 20);
            txtUsername.Enabled = false;

            Label lblFirstName = new Label();
            lblFirstName.Text = "First Name:";
            lblFirstName.Location = new Point(20, 70);
            lblFirstName.AutoSize = true;

            txtFirstName = new TextBox();
            txtFirstName.Location = new Point(20, 90);
            txtFirstName.Size = new Size(410, 20);
            txtFirstName.Enabled = false;

            Label lblLastName = new Label();
            lblLastName.Text = "Last Name:";
            lblLastName.Location = new Point(20, 120);
            lblLastName.AutoSize = true;

            txtLastName = new TextBox();
            txtLastName.Location = new Point(20, 140);
            txtLastName.Size = new Size(410, 20);
            txtLastName.Enabled = false;

            Label lblCNP = new Label();
            lblCNP.Text = "CNP:";
            lblCNP.Location = new Point(20, 170);
            lblCNP.AutoSize = true;

            txtCNP = new TextBox();
            txtCNP.Location = new Point(20, 190);
            txtCNP.Size = new Size(410, 20);
            txtCNP.Enabled = false;

            Button btnClose = new Button();
            btnClose.Text = "Close";
            btnClose.Location = new Point(20, 230);
            btnClose.Size = new Size(410, 30);
            btnClose.Click += new EventHandler(btnClose_Click);

            this.Controls.Add(lblFirstName);
            this.Controls.Add(txtFirstName);
            this.Controls.Add(lblLastName);
            this.Controls.Add(txtLastName);
            this.Controls.Add(lblCNP);
            this.Controls.Add(txtCNP);
            this.Controls.Add(lblUsername);
            this.Controls.Add(txtUsername);
            this.Controls.Add(btnClose);
        }

        private void Patient_App_Load(object sender, EventArgs e)
        {
            try
            {
                txtFirstName.Text = patient.FirstName;
                txtLastName.Text = patient.LastName;
                txtCNP.Text = patient.CNP;
                txtUsername.Text = patient.Username;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            // Close the form
            this.Close();
        }

        private Patient get_Patient(int id)
        {
            List<Patient> patients = Data.read_Patient_info();
            Patient? patient = patients.Find(x => x.Id == id);
            if (patient == null)
            {
                throw new Exception("Patient unknown");
            }
            return patient;
        }
    }
}
