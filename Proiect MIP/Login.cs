using Working_With_Data;

namespace Proiect_MIP
{
    public enum Tip
    {
        Doctor,
        Patient
    }
    public partial class Login : Form
    {
        private Tip MyType;
        private Button btnDoctor = new Button();
        private Button btnPatient = new Button();
        private Label lblUsername = new Label();
        private TextBox txtUsername = new TextBox();
        private TextBox txtPassword = new TextBox();
        private Running_button btnLogin = new Running_button();

        public Login(Tip type)
        {
            InitializeComponent();
            create_Components();
            MyType = type;
        }

        public Login(Tip type, String UserName, String Password):this(type)
        {
            txtUsername.Text = UserName;
            txtPassword.Text = Password;
            btnLogin.CanBeClicked = true;
        }

        private void create_Components()
        {
            this.Size = new Size(400, 300);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Login";

            lblUsername = new Label();
            lblUsername.Text = MyType.ToString() + "'s Username:";
            lblUsername.Location = new Point(20, 20);
            lblUsername.AutoSize = true;

            txtUsername = new TextBox();
            txtUsername.Location = new Point(20, 40);
            txtUsername.Size = new Size(360, 20);

            Label lblPassword = new Label();
            lblPassword.Text = "Password:";
            lblPassword.Location = new Point(20, 70);
            lblPassword.AutoSize = true;

            txtPassword = new TextBox();
            txtPassword.Location = new Point(20, 90);
            txtPassword.Size = new Size(360, 20);
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.TextChanged += new EventHandler(Text_Changed);

            btnLogin = new Running_button();
            btnLogin.Text = "Login";
            btnLogin.Location = new Point(290, 120);
            btnLogin.Size = new Size(90, 25);
            btnLogin.Click += new EventHandler(btnLogin_Click);

            Button btnCreateAccount = new Button();
            btnCreateAccount.Text = "Create Account";
            btnCreateAccount.Location = new Point(20, 150);
            btnCreateAccount.Size = new Size(360, 25);
            btnCreateAccount.Click += new EventHandler(btnCreateAccount_Click);

            btnDoctor = new Button();
            btnDoctor.Text = "I'm a Doctor";
            btnDoctor.Location = new Point(20, 180);
            btnDoctor.Size = new Size(360, 25);
            btnDoctor.Click += new EventHandler(btnDoctor_Click);

            btnPatient = new Button();
            btnPatient.Text = "I'm a Patient";
            btnPatient.Location = new Point(20, 180);
            btnPatient.Size = new Size(360, 25);
            btnPatient.Click += new EventHandler(btnPatient_Click);

            this.Controls.Add(lblUsername);
            this.Controls.Add(lblPassword);
            this.Controls.Add(txtUsername);
            this.Controls.Add(txtPassword);
            this.Controls.Add(btnCreateAccount);
            this.Controls.Add(btnLogin);

            if (MyType == Tip.Doctor)
            {
                this.Controls.Add(btnPatient);
            }
            else
            {
                this.Controls.Add(btnDoctor);
            }
        }

        private void Form1_Load(object sender, EventArgs e){}

        private void btnLogin_Click(object sender, EventArgs e)
        {
            UserLogin user = new UserLogin()
            {
                Username = txtUsername.Text,
                Password = txtPassword.Text
            };
            try
            {
                int id = Data_Loader.User_Login(MyType, user);
                this.Hide();
                this.Close();

                if(MyType == Tip.Doctor)
                {
                    new Doctor_App(id).ShowDialog();
                }
                else
                {
                    new Patient_App(id).ShowDialog();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message);
            }
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            // Open the create account form depending on mytype
            this.Hide();
            this.Close();
            if (MyType == Tip.Doctor)
            {
                CreateDoctor createForm = new CreateDoctor();
                createForm.ShowDialog();
            }
            else
            {
                CreatePatient createForm = new CreatePatient();
                createForm.ShowDialog();
            }
        }

        private void btnDoctor_Click(object sender, EventArgs e)
        {
            // Change the form to Doctor login
            lblUsername.Text = "Doctor's Username:";
            MyType = Tip.Doctor;
            this.Controls.Remove(btnDoctor);
            this.Controls.Add(btnPatient);
        }

        private void btnPatient_Click(object sender, EventArgs e)
        {
            // Change the form to Patient login
            lblUsername.Text = "Patient's Username:";
            MyType = Tip.Patient;
            this.Controls.Remove(btnPatient);
            this.Controls.Add(btnDoctor);
        }

        private void Text_Changed(object sender, EventArgs e)
        {
            //event called to check if the fields have text in them or not 
            if(txtPassword.Text.Length == 0 || txtUsername.Text.Length == 0)
            {
                btnLogin.CanBeClicked = false;
            }
            else
            {
                btnLogin.CanBeClicked = true;
            }
        }
    }
}