using System.ComponentModel.Composition;
using System.Windows.Controls;
using WPFsumApp.ViewModel;

namespace WPFsumApp.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    [Export]
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
        }

        [Import]
        public LoginViewModel ViewModel
        {
            get { return this.DataContext as LoginViewModel; }
            set { this.DataContext = value; }
        }
    }
}
