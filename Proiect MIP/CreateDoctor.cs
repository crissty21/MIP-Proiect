using System.Data;
using Working_With_Data;

namespace Proiect_MIP
{
    public partial class CreateDoctor : Form
    {
        private Running_button btnCreate = new Running_button();
        private List<TextBox> textBoxes = new List<TextBox>();
        private TextBox txtPassword = new TextBox();
        private TextBox txtConfirmPassword = new TextBox();
        private TextBox txtUsername = new TextBox();
        private TextBox txtLastName = new TextBox();
        private TextBox txtFirstName = new TextBox();
        private TextBox txtSpecialization = new TextBox();

        public CreateDoctor()
        {
            InitializeComponent();
            create_Components();
        }

        private void create_Components()
        {
            this.Size = new Size(450, 430);
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblFirstName = new Label();
            lblFirstName.Text = "First Name:";
            lblFirstName.Location = new Point(20, 20);
            lblFirstName.AutoSize = true;

            txtFirstName = new TextBox();
            txtFirstName.Location = new Point(20, 40);
            txtFirstName.Size = new Size(410, 20);
            txtFirstName.TextChanged += new EventHandler(Text_Changed);
            textBoxes.Add(txtFirstName);

            Label lblLastName = new Label();
            lblLastName.Text = "Last Name:";
            lblLastName.Location = new Point(20, 70);
            lblLastName.AutoSize = true;

            txtLastName = new TextBox();
            txtLastName.Location = new Point(20, 90);
            txtLastName.Size = new Size(410, 20);
            txtLastName.TextChanged += new EventHandler(Text_Changed);
            textBoxes.Add(txtLastName);

            Label lblSpecialization = new Label();
            lblSpecialization.Text = "Specialization:";
            lblSpecialization.Location = new Point(20, 120);
            lblSpecialization.AutoSize = true;

            txtSpecialization = new TextBox();
            txtSpecialization.Location = new Point(20, 140);
            txtSpecialization.Size = new Size(410, 20);
            txtSpecialization.TextChanged += new EventHandler(Text_Changed);
            textBoxes.Add(txtSpecialization);

            Label lblUsername = new Label();
            lblUsername.Text = "Username:";
            lblUsername.Location = new Point(20, 170);
            lblUsername.AutoSize = true;

            txtUsername = new TextBox();
            txtUsername.Location = new Point(20, 190);
            txtUsername.Size = new Size(410, 20);
            txtUsername.TextChanged += new EventHandler(Text_Changed);
            textBoxes.Add(txtUsername);

            Label lblPassword = new Label();
            lblPassword.Text = "Password:";
            lblPassword.Location = new Point(20, 220);
            lblPassword.AutoSize = true;

            txtPassword = new TextBox();
            txtPassword.Location = new Point(20, 240);
            txtPassword.Size = new Size(410, 20);
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.TextChanged += new EventHandler(Text_Changed);
            txtPassword.TextChanged += new EventHandler(conf_password);
            textBoxes.Add(txtPassword);

            Label lblConfirmPassword = new Label();
            lblConfirmPassword.Text = "Confirm Password:";
            lblConfirmPassword.Location = new Point(20, 270);
            lblConfirmPassword.AutoSize = true;

            txtConfirmPassword = new TextBox();
            txtConfirmPassword.Location = new Point(20, 290);
            txtConfirmPassword.Size = new Size(410, 20);
            txtConfirmPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.TextChanged += new EventHandler(Text_Changed);
            txtConfirmPassword.TextChanged += new EventHandler(conf_password);
            textBoxes.Add(txtConfirmPassword);

            btnCreate = new Running_button();
            btnCreate.Location = new Point(150, 320);
            btnCreate.Size = new Size(150, 30);
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += new EventHandler(this.btnCreate_Click);

            Button btnCancel = new Button();
            btnCancel.Location = new Point(150, 350);
            btnCancel.Size = new Size(150, 30);
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += new EventHandler(this.btnCancel_Click);

            this.Controls.Add(lblSpecialization);
            this.Controls.Add(txtSpecialization);
            this.Controls.Add(txtLastName);
            this.Controls.Add(txtFirstName);
            this.Controls.Add(lblLastName);
            this.Controls.Add(lblFirstName);
            this.Controls.Add(txtConfirmPassword);
            this.Controls.Add(lblPassword);
            this.Controls.Add(lblConfirmPassword);
            this.Controls.Add(txtPassword);
            this.Controls.Add(txtUsername);
            this.Controls.Add(lblUsername);
            this.Controls.Add(btnCreate);
            this.Controls.Add(btnCancel);
        }

        private void Create_Load(object sender, EventArgs e){}

        private void btnCreate_Click(object sender, EventArgs e)
        {
            // Add your code here
            Doctor doctor = new Doctor()
            {
                Username = txtUsername.Text,
                Password = txtPassword.Text,
                Specialization = txtSpecialization.Text,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text
            };
            try
            {
                Data_Saver.add_New_Doctor_Login(doctor);
                Data_Saver.add_New_Doctor_infos(doctor);
                Login form = new Login(Tip.Doctor, doctor.Username, doctor.Password);

                // Close the form
                this.Hide();
                this.Close();

                form.ShowDialog();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Close the form
            this.Hide();
            this.Close();

            Login form = new Login(Tip.Doctor);
            form.ShowDialog();
        }
       
        private void Text_Changed(object sender, EventArgs e)
        {
            //check to see if the user completed the fields with data
            List<TextBox> list = textBoxes.Where(e => e.Text.Length == 0).ToList();
            if (list.Count() == 0)
            {
                btnCreate.CanBeClicked = true;
            }
            else
            {
                btnCreate.CanBeClicked = false;
            }
            
        }
        
        private void conf_password(object sender, EventArgs e)
        {
            //makes sure that the passwords coincide 
            if(txtConfirmPassword.Text == txtPassword.Text)
            {
                txtConfirmPassword.ForeColor = Color.Black;
                txtPassword.ForeColor = Color.Black;
            }
            else
            {
                txtConfirmPassword.ForeColor = Color.Red;
                txtPassword.ForeColor = Color.Red;
            }
        }

    }
}
