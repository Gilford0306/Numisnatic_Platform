using Numisnatic_Platform.Class;

namespace Numisnatic_Platform.UserControls
{
    public partial class MonetControl : UserControl
    {
        public MonetControl()
        {
            InitializeComponent();
        }
        public MonetControl(Monet monet) : this()
        {
            this.label1.Text = monet.Id.ToString();
            this.label2.Text = monet.Title.ToString();
            this.label3.Text = monet.Price.ToString();
        }

    }
}
