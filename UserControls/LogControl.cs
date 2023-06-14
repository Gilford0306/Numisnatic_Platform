using Numisnatic_Platform.Class;


namespace Numisnatic_Platform.UserControls
{
    public partial class LogControl : UserControl
    {
        public LogControl()
        {
            InitializeComponent();
        }
        public LogControl(Log log) : this()
        {
            this.label1.Text = log.Date.ToString();
            this.label2.Text = log.Description.ToString();
        }
    }
}
