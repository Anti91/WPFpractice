using System.ComponentModel.Composition;
using System.Windows.Controls;
using WPFsumApp.Modules.Menu.ViewModel;

namespace WPFsumApp.Modules.Menu.View
{
    /// <summary>
    /// Interaction logic for MenuView.xaml
    /// </summary>
    [Export(typeof(MenuView))]
    public partial class MenuView : UserControl
    {
        public MenuView()
        {
            InitializeComponent();
        }

        [Import]
        public MenuViewModel MenuVModel
        {
            get { return this.DataContext as MenuViewModel; }
            set { this.DataContext = value; }
        }
    }
}
