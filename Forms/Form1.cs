using Numisnatic_Platform.Class;
using ProductEntity;

namespace Numisnatic_Platform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "admin")
            {
                FormAdmin newForm = new FormAdmin();
                newForm.Show();
            }
            else
            {
                using (MyApplicationContext context = new MyApplicationContext())
                {
                    bool flag = false;
                    foreach (User user in context.Users)
                    {
                        string str = user.Login;
                        str = str.Replace(" ", string.Empty);
                        if (textBox1.Text == str)
                        {
                            FormUser newForm = new FormUser(user);
                            newForm.Show();
                            flag = true;
                        }

                    }
                    if (flag == false && textBox1.Text != string.Empty)
                        MessageBox.Show("Login isn`t exist");
                }
            }
        }
    }
}