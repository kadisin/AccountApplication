using AccountApplication.Model;
using AccountApplication.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;

namespace AccountApplication
{

    [TestFixture]
    public class AccountUnitTests
    {
        /*
         *  Methods in AccountViewModel manages data from database so its hard to unittest that methods (methods doesn't using data, they send request to db and get back data
         *  without making any operation of them) so i decided to create simple method to test...
         */


        [Test]
        public void AccountTest_CreateNewAccountWithAllData_ReturnNewAccount()
        {
            //arrange
            var name = "Name";
            var login = "Login";
            var password = "Password";

            var account = new Account()
            {
                Name = name,
                Login = login,
                Password = password
            };


            //act 

            var newAccount = Account.CreateNewAccount(name,login,password);

            //assert
            
            Assert.Equals(account, newAccount);

        }


        [Test]
        public void AccountTest_CreateNewAccountWithoutLogin_ReturnNull()
        {
            //arrange

            var name = "Name";
            var emptyLogin = string.Empty;
            var password = "Password";

            //act 

            var newAccount = Account.CreateNewAccount(name,emptyLogin,password);

            //assert

            Assert.IsNull(newAccount);

        }


        [Test]
        public void AccountTest_CreateNewAccountWithoutName_ReturnNewAccount()
        {
            //arrange

            var emptyName = string.Empty;
            var login = "login";
            var password = "Password";

            var account = new Account()
            { 
                Name = emptyName,
                Login = login,
                Password = password
            };


            //act 

            var newAccount = Account.CreateNewAccount(emptyName, login, password);

            //assert

            Assert.AreEqual(account, newAccount);

        }

        [Test]
        public void AccountTest_CreateNewAccountWithoutPassword_ReturnNewAccount()
        {
            //arrange

            var name = "name";
            var login = "login";
            var emptyPassword = string.Empty; ;

            var account = new Account()
            {
                Name = name,
                Login = login,
                Password = emptyPassword
            };


            //act 

            var newAccount = Account.CreateNewAccount(name, login, emptyPassword);

            //assert

            Assert.AreEqual(account, newAccount);

        }


    }
}
