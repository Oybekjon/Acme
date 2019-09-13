using Acme.Data;
using Acme.DomainObjects;
using Acme.Services.Errors;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Acme.Services.Test
{
    [TestClass]
    public class UserServiceTest
    {

        private readonly Mock<RepositoryContextBase> Context;
        private readonly Mock<IRepository<User>> Repository;

        public UserServiceTest()
        {
            Repository = new Mock<IRepository<User>>();
            Context = new Mock<RepositoryContextBase>();
        }
        private void SetupMocksLogin()
        {
            Repository.Setup(x => x.Where(It.IsAny<Expression<Func<User, bool>>>()))
                .Returns(new List<User> {
                    new User {
                        Email = "jumaniyozov@oybek.com",
                        PasswordHash = "123456",
                        FirstName = "Oybek",
                        LastName = "Jumaniyoz"
                    }
                }.AsQueryable());

            Context.Setup(x => x.GetRepository<User>()).Returns(Repository.Object);
        }

        private void SetupMocksRegisterDuplicate()
        {
            Repository.Setup(x => x.Where(It.IsAny<Expression<Func<User, bool>>>()))
                .Returns(new List<User> {
                    new User {
                        Email = "jumaniyozov@oybek.com",
                        PasswordHash = "123456",
                        FirstName = "Oybek",
                        LastName = "Jumaniyoz"
                    }
                }.AsQueryable());

            Context.Setup(x => x.GetRepository<User>()).Returns(Repository.Object);
        }

        private void SetupMocksRegisterSuccess()
        {
            Repository.Setup(x => x.Where(It.IsAny<Expression<Func<User, bool>>>()))
                .Returns(new List<User> { }.AsQueryable());
            Repository.Setup(x => x.Store(It.IsAny<User>()));
            Repository.Setup(x => x.SaveChanges()).Returns(1);

            Context.Setup(x => x.GetRepository<User>()).Returns(Repository.Object);
        }

        private void SetupMocksFailLogin()
        {
            Repository.Setup(x => x.Where(It.IsAny<Expression<Func<User, bool>>>()))
                .Returns(new List<User> { }.AsQueryable());

            Context.Setup(x => x.GetRepository<User>()).Returns(Repository.Object);
        }

        [TestMethod]
        public void LoginTest()
        {
            SetupMocksLogin();
            var context = Context.Object;
            var srv = new UserService(context);
            var result = srv.Login(new ViewModels.LoginViewModel
            {
                Email = "jumaniyozov@oybek.com",
                Password = "123456"
            });
            Assert.AreEqual("jumaniyozov@oybek.com", result.Email);
        }
        [TestMethod]
        public void RegisterDuplicate()
        {
            SetupMocksRegisterDuplicate();
            var context = Context.Object;
            var srv = new UserService(context);
            try
            {
                srv.Register(new ViewModels.RegisterViewModel
                {
                    Email = "jumaniyozov@oybek.com",
                    Password = "123456",
                    PasswordConfirmation = "123456"
                });
            }
            catch (DuplicateEmailException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.Fail("Incorrect exception during duplicate");
            }

        }

        [TestMethod]
        public void RegisterMismatch()
        {
            SetupMocksRegisterDuplicate();
            var context = Context.Object;
            var srv = new UserService(context);
            try
            {
                srv.Register(new ViewModels.RegisterViewModel
                {
                    Email = "jumaniyozov@oybek.com",
                    Password = "123456",
                    PasswordConfirmation = ""
                });
            }
            catch (PasswordMismatchException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.Fail("Incorrect exception during duplicate");
            }

        }

        [TestMethod]
        public void RegisterSuccess()
        {
            SetupMocksRegisterSuccess();
            var context = Context.Object;
            var srv = new UserService(context);
            srv.Register(new ViewModels.RegisterViewModel
            {
                Email = "jumaniyozov@oybek.com",
                Password = "123456",
                PasswordConfirmation = "123456"
            });
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void LoginFailTest()
        {
            SetupMocksFailLogin();
            var context = Context.Object;
            var srv = new UserService(context);
            try
            {
                var result = srv.Login(new ViewModels.LoginViewModel
                {
                    Email = "jumaniyozov@oybek.com",
                    Password = "123456"
                });

            }
            catch (AuthFailedException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.Fail("Incorrect exception on failed login");
            }
        }
    }
}
