namespace WPFsumApp.ViewModel
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            OperationViewModel = new OperationViewModel();
        }

        public OperationViewModel OperationViewModel
        {
            get;
            set;
        }
    }
}
