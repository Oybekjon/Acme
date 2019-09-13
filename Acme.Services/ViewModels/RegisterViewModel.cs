using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.Services.ViewModels
{
    public class RegisterViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
    }
}
