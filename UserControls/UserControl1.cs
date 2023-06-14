using Numisnatic_Platform.Class;

namespace Numisnatic_Platform
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        public UserControl1(User monet) : this()
        {
            this.label1.Text = monet.Id.ToString();
            this.label2.Text = monet.Login.ToString();
        }
    }
}
