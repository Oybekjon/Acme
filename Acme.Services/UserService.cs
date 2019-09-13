using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acme.Data;
using Acme.DomainObjects;
using Acme.Services.Errors;
using Acme.Services.ViewModels;

namespace Acme.Services
{
    public class UserService : IUserService
    {
        private readonly RepositoryContextBase Context;
        public UserService(RepositoryContextBase context)
        {
            Guard.NotNull(context, nameof(context));
            Context = context;
        }
        public UserInfo Login(LoginViewModel viewModel)
        {
            Guard.NotNull(viewModel, nameof(viewModel));
            var repo = Context.GetRepository<User>();
            var hash = HashPassword(viewModel.Password);
            var result = repo.Where(x => x.Email == viewModel.Email && x.PasswordHash == hash).ToList();
            if (result.Count == 0)
            {
                throw new AuthFailedException();
            }
            var user = result.FirstOrDefault();
            return new UserInfo {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }

        private string HashPassword(string password)
        {
            return password;
        }

        public void Register(RegisterViewModel viewModel)
        {
            Guard.NotNull(viewModel, nameof(viewModel));
            if (viewModel.Password != viewModel.PasswordConfirmation)
                throw new PasswordMismatchException();
            var repo = Context.GetRepository<User>();
            var exists = repo.Where(x => x.Email == viewModel.Email).Any();
            if (exists)
            {
                throw new DuplicateEmailException();
            }
            var user = new User {
                Email = viewModel.Email,
                PasswordHash = HashPassword(viewModel.Password)
            };
            repo.Store(user);
            repo.SaveChanges();
        }
    }
}
