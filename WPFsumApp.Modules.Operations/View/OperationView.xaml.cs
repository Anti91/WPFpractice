﻿using System.ComponentModel.Composition;
using System.Windows.Controls;
using WPFsumApp.Modules.Operations.ViewModel;

namespace WPFsumApp.Modules.Operations.View
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    [Export]
    public partial class OperationView : UserControl
    {
        [ImportingConstructor]
        public OperationView()
        {
            InitializeComponent();
        }

        [Import]
        public OperationViewModel ViewModel
        {
            get { return this.DataContext as OperationViewModel; }
            set { this.DataContext = value; }
        }
    }
}