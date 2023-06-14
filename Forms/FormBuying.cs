
using Numisnatic_Platform.Class;
using Numisnatic_Platform.UserControls;
using ProductEntity;
using User = Numisnatic_Platform.Class.User;

namespace Numisnatic_Platform
{
    public partial class FormBuying : Form
    {
        int x = -1;
        int z = -1;
        User user1 = new User();
        public FormBuying()
        {
            InitializeComponent();
        }

        public FormBuying(User user) : this()
        {
            user1 = user;
            label1.Text = user.Login.ToString() + " - you can buy";
            using (MyApplicationContext context = new MyApplicationContext())
            {
                int y = 0;
                foreach (Monet monet in context.Monets)
                {
                    if (monet.IsSelling == true && monet.UserId != user.Id)
                    {
                        var item = new MonetControl(monet);
                        item.Location = new Point(0, y);
                        this.panel1.Controls.Add(item);
                        y += item.Height - 20;
                    }

                }
            }
        }

        public FormBuying(User user, int t) : this()
        {
            user1 = user;
            z = t;
            label1.Text = user.Login.ToString() + " - you can change";
            button1.Text = "Change";
            using (MyApplicationContext context = new MyApplicationContext())
            {
                int y = 0;
                foreach (Monet monet in context.Monets)
                {
                    if (monet.IsSelling == true && monet.UserId != user.Id)
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
            if (z == -1)
            {
                if (x != -1)
                {
                    using (MyApplicationContext context = new MyApplicationContext())
                    {
                        try
                        {
                            var oldData = context.Monets.FirstOrDefault(y => y.Id == x);
                            oldData.UserId = user1.Id;
                            oldData.IsSelling = false;
                            context.Monets.Update(oldData);
                            context.SaveChanges();
                            MessageBox.Show("Monets is buying");
                            context.Logs.Add(new Log() { Date = DateTime.Now.ToString(), Description = @$"{user1.Login} is buying monet id {x}" });
                            context.SaveChanges();
                            this.Close();
                        }
                        catch
                        {
                            MessageBox.Show("Monet ID isn`t exist");
                            textBox1.Clear();
                        }
                    }

                }
            }
            else
            {
                if (x != -1)
                {
                    using (MyApplicationContext context = new MyApplicationContext())
                    {
                        try
                        {
                            var oldData = context.Monets.FirstOrDefault(y => y.Id == x);
                            int ChangeIdUser = oldData.UserId;
                            oldData.UserId = user1.Id;
                            oldData.IsSelling = false;
                            context.Monets.Update(oldData);
                            context.SaveChanges();

                            oldData = context.Monets.FirstOrDefault(y => y.Id == z);
                            oldData.UserId = ChangeIdUser;
                            oldData.IsSelling = false;
                            context.Monets.Update(oldData);
                            context.SaveChanges();
                            MessageBox.Show("Monets is changing");
                            context.Logs.Add(new Log() { Date = DateTime.Now.ToString(), Description = @$"{user1.Login} is change monet id {x} on monet id {z}" });
                            context.SaveChanges();
                            this.Close();
                        }
                        catch
                        {
                            MessageBox.Show("Monet ID isn`t exist");
                            textBox1.Clear();
                        }
                    }

                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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
    }
}
