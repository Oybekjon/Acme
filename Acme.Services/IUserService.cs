using Acme.Services.ViewModels;
using System;

namespace Acme.Services
{
    public interface IUserService
    {
        void Register(RegisterViewModel viewModel);
        UserInfo Login(LoginViewModel viewModel);
    }
}
