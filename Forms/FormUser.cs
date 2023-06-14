using Numisnatic_Platform.Class;
using Numisnatic_Platform.UserControls;
using ProductEntity;
using User = Numisnatic_Platform.Class.User;

namespace Numisnatic_Platform
{
    public partial class FormUser : Form
    {
        User user1 = new User();
        int x = -1;
        int z = -1;
        public FormUser()
        {
            InitializeComponent();
        }

        public FormUser(User user) : this()
        {
            user1 = user;
            label1.Text = user.Login.ToString() + " - your monet";
            using (MyApplicationContext context = new MyApplicationContext())
            {
                int y = 0;
                foreach (Monet monet in context.Monets)
                {
                    if (monet.UserId == user.Id)
                    {
                        var item = new MonetControl(monet);
                        item.Location = new Point(0, y);
                        this.panel1.Controls.Add(item);
                        y += item.Height - 20;
                    }

                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormBuying newForm = new FormBuying(user1);
            newForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            using (MyApplicationContext context = new MyApplicationContext())
            {
                int y = 0;

                foreach (Monet monet in context.Monets)
                {
                    if (monet.UserId == user1.Id)
                    {
                        var item = new MonetControl(monet);
                        item.Location = new Point(0, y);
                        this.panel1.Controls.Add(item);
                        y += item.Height - 20;
                    }

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (x != -1)
            {
                using (MyApplicationContext context = new MyApplicationContext())
                {
                    try
                    {
                        var oldData = context.Monets.FirstOrDefault(y => y.Id == x);
                        oldData.IsSelling = true;
                        context.Monets.Update(oldData);
                        context.SaveChanges();
                        MessageBox.Show("Monets is adding to selling list");
                    }
                    catch
                    {
                        MessageBox.Show("Monet ID isn`t exist");
                        textBox1.Clear();
                    }
                }

            }
        }
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            if (textBox1.Text.ToString() != string.Empty)
            {
                try
                {
                    x = int.Parse(textBox1.Text.ToString());
                }
                catch
                {
                    MessageBox.Show("Only Number");
                    textBox1.Clear();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (MyApplicationContext context = new MyApplicationContext())
            {
                foreach (Monet monet in context.Monets)
                {
                    if (monet.Id == z)
                    {
                        FormBuying newForm = new FormBuying(user1, z);
                        newForm.Show();
                    }

                }

            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.ToString() != string.Empty)
            {
                try
                {
                    z = int.Parse(textBox2.Text.ToString());
                }
                catch
                {
                    MessageBox.Show("Only Number");
                    textBox2.Clear();
                }
            }
        }
    }
}
