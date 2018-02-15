using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFsumApp.Model;

namespace WPFsumApp.View
{
    /// <summary>
    /// Interaction logic for LoginUserControl.xaml
    /// </summary>
    public partial class LoginUserControl : UserControl
    {
        public static readonly DependencyProperty MyPropertyProperty =
           DependencyProperty.Register("MyProperty", typeof(List<User>), typeof(LoginUserControl));

        public LoginUserControl()
        {
            InitializeComponent();
        }

        public List<User> MyProperty
        {
            get { return (List<User>)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }
    }
}
