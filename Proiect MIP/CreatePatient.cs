using System.Data;
using Working_With_Data;

namespace Proiect_MIP
{
    public partial class CreatePatient : Form
    {
        private TextBox txtFirstName = new TextBox();
        private TextBox txtLastName = new TextBox();
        private TextBox txtCNP = new TextBox();
        private TextBox txtUsername = new TextBox();
        private TextBox txtPassword = new TextBox();
        private TextBox txtConfirmPassword = new TextBox();
        private Running_button btnCreate = new Running_button();

        private List<TextBox> textBoxes = new List<TextBox>();

        public CreatePatient()
        {
            InitializeComponent();
            create_Components();
        }

        private void create_Components()
        {
            this.Size = new Size(450, 440);
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

            Label lblCNP = new Label();
            lblCNP.Text = "CNP:";
            lblCNP.Location = new Point(20, 120);
            lblCNP.AutoSize = true;

            txtCNP = new TextBox();
            txtCNP.Location = new Point(20, 140);
            txtCNP.Size = new Size(410, 20);
            txtCNP.TextChanged += new EventHandler(Text_Changed);
            txtCNP.TextChanged += new EventHandler(check_CNP);
            textBoxes.Add(txtCNP);

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
            txtPassword.TextChanged += new EventHandler(conf_password);
            txtPassword.TextChanged += new EventHandler(Text_Changed);
            textBoxes.Add(txtPassword);

            Label lblConfirmPassword = new Label();
            lblConfirmPassword.Text = "Confirm Password:";
            lblConfirmPassword.Location = new Point(20, 270);
            lblConfirmPassword.AutoSize = true;

            txtConfirmPassword = new TextBox();
            txtConfirmPassword.Location = new Point(20, 290);
            txtConfirmPassword.Size = new Size(410, 20);
            txtConfirmPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.TextChanged += new EventHandler(conf_password);
            txtConfirmPassword.TextChanged += new EventHandler(Text_Changed);
            textBoxes.Add(txtConfirmPassword);

            btnCreate = new Running_button();
            btnCreate.Text = "Create";
            btnCreate.Location = new Point(125, 320);
            btnCreate.Size = new Size(200, 30);
            btnCreate.Click += new EventHandler(btnCreate_Click);

            Button btnCancel = new Button();
            btnCancel.Text = "Cancel";
            btnCancel.Location = new Point(125, 360);
            btnCancel.Size = new Size(200, 30);
            btnCancel.Click += new EventHandler(btnCancel_Click);

            this.Controls.Add(lblFirstName);
            this.Controls.Add(txtFirstName);
            this.Controls.Add(lblLastName);
            this.Controls.Add(txtLastName);
            this.Controls.Add(lblCNP);
            this.Controls.Add(txtCNP);
            this.Controls.Add(lblUsername);
            this.Controls.Add(txtUsername);
            this.Controls.Add(lblPassword);
            this.Controls.Add(txtPassword);
            this.Controls.Add(lblConfirmPassword);
            this.Controls.Add(txtConfirmPassword);
            this.Controls.Add(btnCreate);
            this.Controls.Add(btnCancel);
        }

        private void CreatePatient_Load(object sender, EventArgs e){}

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Patient patient = new Patient()
            {
                Username = txtUsername.Text,
                Password = txtPassword.Text,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                CNP = txtCNP.Text
            };
            Login form = new Login(Tip.Patient, patient.Username, patient.Password);
            try
            {
                Data_Saver.add_New_Patient_Login(patient);
                Data_Saver.add_New_Patient_infos(patient);

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
            this.Hide();
            this.Close();

            Login form = new Login(Tip.Patient);
            form.ShowDialog();
        }

        private void Text_Changed(object sender, EventArgs e)
        {
            List<TextBox> list = textBoxes.Where(txt => txt.Text.Length == 0).ToList();
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
            if (txtConfirmPassword.Text == txtPassword.Text)
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

        private void check_CNP(object sender, EventArgs e)
        {
            if (txtCNP.Text.Length != 13)
            {
                txtCNP.ForeColor = Color.Red;
            }
            else
            {
                txtCNP.ForeColor = Color.Black;
            }
        }
    }
}
