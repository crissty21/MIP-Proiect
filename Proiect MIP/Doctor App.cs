using Working_With_Data;

namespace Proiect_MIP
{
    public partial class Doctor_App : Form
    {
        private Doctor doctor = new Doctor();
        private TextBox txtUsername = new TextBox();
        private TextBox txtSpecilization = new TextBox();
        private TextBox txtLastName = new TextBox();
        private TextBox txtFirstName = new TextBox();

        public Doctor_App(int doctorID)
        {
            InitializeComponent();
            try
            {
                doctor = get_Doctor(doctorID);
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

            Label lblSpecialization = new Label();
            lblSpecialization.Text = "Specialization:";
            lblSpecialization.Location = new Point(20, 170);
            lblSpecialization.AutoSize = true;

            txtSpecilization = new TextBox();
            txtSpecilization.Location = new Point(20, 190);
            txtSpecilization.Size = new Size(410, 20);
            txtSpecilization.Enabled = false;

            Button btnClose = new Button();
            btnClose.Text = "Close";
            btnClose.Location = new Point(20, 230);
            btnClose.Size = new Size(410, 30);
            btnClose.Click += new EventHandler(this.btnClose_Click);

            this.Controls.Add(lblFirstName);
            this.Controls.Add(txtFirstName);
            this.Controls.Add(lblLastName);
            this.Controls.Add(txtLastName);
            this.Controls.Add(lblSpecialization);
            this.Controls.Add(txtSpecilization);
            this.Controls.Add(lblUsername);
            this.Controls.Add(txtUsername);
            this.Controls.Add(btnClose);
        }

        private void Patient_App_Load(object sender, EventArgs e)
        {
            try
            {
                txtFirstName.Text = doctor.FirstName;
                txtLastName.Text = doctor.LastName;
                txtUsername.Text = doctor.Username;
                txtSpecilization.Text = doctor.Specialization;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Doctor get_Doctor(int id)
        {
            List<Doctor> doctors = Data.read_Doctor_info();
            Doctor? doctor = doctors.Find(x => x.Id == id);
            if(doctor == null)
            {
                throw new Exception("Doctor unknown");
            }
            return doctor;
        }

    }
}
