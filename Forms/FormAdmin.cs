using Numisnatic_Platform.Class;
using Numisnatic_Platform.UserControls;
using ProductEntity;
namespace Numisnatic_Platform
{
    public partial class FormAdmin : Form
    {
        int x = -1;
        public FormAdmin()
        {
            InitializeComponent();
            using (MyApplicationContext context = new MyApplicationContext())
            {
                int y = 0;
                foreach (User user in context.Users)
                {
                    var item = new UserControl1(user);
                    item.Location = new Point(0, y);
                    this.panel1.Controls.Add(item);
                    y += item.Height - 20;
                }
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            //log
            panel1.Controls.Clear();
            using (MyApplicationContext context = new MyApplicationContext())
            {
                int y = 0;
                panel1.Controls.Clear();
                foreach (Log log in context.Logs)
                {
                    var item = new LogControl(log);
                    item.Location = new Point(0, y);
                    this.panel1.Controls.Add(item);
                    y += item.Height - 20;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //del
            if (x > 0)
                using (MyApplicationContext context = new MyApplicationContext())
                {

                    int idForRemove = x;
                    foreach (Monet monet in context.Monets)
                    {
                        if (monet.UserId == idForRemove)
                        {
                            context.Monets.Remove(monet);
                        }

                    }
                    context.Users.Remove(context.Users.FirstOrDefault(z => z.Id.Equals(idForRemove)));
                    context.SaveChanges();
                    panel1.Controls.Clear();
                    MessageBox.Show("User is deleted");
                    textBox1.Clear();
                    panel1.Controls.Clear();

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
            panel1.Controls.Clear();
            using (MyApplicationContext context = new MyApplicationContext())
            {
                int y = 0;
                foreach (User user in context.Users)
                {
                    var item = new UserControl1(user);
                    item.Location = new Point(0, y);
                    this.panel1.Controls.Add(item);
                    y += item.Height - 20;
                }
            }
        }
    }
}
