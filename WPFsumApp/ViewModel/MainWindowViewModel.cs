namespace WPFsumApp.ViewModel
{
    public class MainWindowViewModel
    {
        public OperationViewModel OperationViewModel
        {
            get;
            set;
        }
        public MainWindowViewModel()
        {
            OperationViewModel  = new OperationViewModel();
        }
    }
}
