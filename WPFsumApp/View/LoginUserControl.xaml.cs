﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public static readonly DependencyProperty IsLoggedInProperty =
           DependencyProperty.Register("IsLoggedIn", typeof(bool), typeof(LoginUserControl), new PropertyMetadata(true));

        public static readonly DependencyProperty LoginCommandProperty =
        DependencyProperty.Register("LoginButtonCommand", typeof(ICommand), typeof(LoginUserControl));

        public static readonly DependencyProperty LogoutCommandProperty =
        DependencyProperty.Register("ExitButtonCommand", typeof(ICommand), typeof(LoginUserControl));

        public LoginUserControl()
        {
            InitializeComponent();
        }

        public ICommand LoginButtonCommand
        {
            get
            {
                return (ICommand)GetValue(LoginCommandProperty);
            }

            set
            {
                SetValue(LoginCommandProperty, value);
            }
        }

        public ICommand ExitButtonCommand
        {
            get
            {
                return (ICommand)GetValue(LogoutCommandProperty);
            }

            set
            {
                SetValue(LogoutCommandProperty, value);
            }
        }

        public List<User> MyProperty
        {
            get { return (List<User>)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }

        public bool IsLoggedIn
        {
            get { return (bool)GetValue(IsLoggedInProperty); }
            set { SetValue(IsLoggedInProperty, value); }
        }

    }
}
