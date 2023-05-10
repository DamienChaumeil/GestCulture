using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestCulture.ViewModels
{
    internal class MainPageViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string LoginCommand { get; set; }
        public string ErrorMessage { get; set; }
    }
}
