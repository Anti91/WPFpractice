using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFsumApp.Model;

namespace WPFsumApp.Controllers
{
    [Export]
    public class UserController : BindableBase
    {
        private User _user;

        public User ActualUser
        {
            get => _user;
            set => SetProperty(ref _user, value);
        }
    }
}
