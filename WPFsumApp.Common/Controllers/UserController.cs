using System.ComponentModel.Composition;
using Prism.Mvvm;
using WPFsumApp.Common.Models;

namespace WPFsumApp.Common.Controllers
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
