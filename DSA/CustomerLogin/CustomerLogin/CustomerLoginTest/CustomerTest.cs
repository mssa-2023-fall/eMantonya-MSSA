
using CustomerLogin;

namespace CustomerLoginTest
{
    [TestClass]
    public class CustomerTest
    {
        public AllCustomers allCustomers = new AllCustomers();
        [TestMethod]
        public void CreateAccountWorks()
        {
            bool result1 = allCustomers.CreateAccount("yes@yes.com", "Eric", "hello123");
            Assert.IsTrue(result1);
            Assert.IsNotNull(allCustomers.Equals("yes@yes.com"));
        }
        [TestMethod]
        public void CusomerEmailCanOnlyBeUsedOnceToCreateAccount()
        {
            allCustomers.CreateAccount("yes@yes.com", "Eric", "hello123");
            bool result = allCustomers.CreateAccount("yes@yes.com", "Jim", "HELLO123");

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void LoginWorks()
        {
            allCustomers.CreateAccount("yes@yes.com", "Eric", "hello123");

            bool result = allCustomers.Login("yes@yes.com", "hello123");

            Assert.IsTrue(result);
           
        }
        [TestMethod]
        public void LoginFailsWithIncorrectPassOrEmail()
        {
            allCustomers.CreateAccount("yes@yes.com", "Eric", "hello123");

            bool wrongPass = allCustomers.Login("yes@yes.com", "HELLO123");
            bool wrongEmail = allCustomers.Login("NO@yes.com", "hello123");

            Assert.IsFalse(wrongPass);
            Assert.IsFalse(wrongEmail);
        }
        [TestMethod]
        public void LoginWorksWithMultipleUsersInData()
        {
            allCustomers.CreateAccount("yes@yes.com", "Eric", "hello123");
            allCustomers.CreateAccount("no@no.com", "Jim", "123qwe");
            allCustomers.CreateAccount("jack@yes.com", "Jack", "password1");

            bool result1 = allCustomers.Login("jack@yes.com", "password1");
            bool result2 = allCustomers.Login("yes@yes.com", "hello123");
            bool result3 = allCustomers.Login("no@no.com", "123qwe");
            

            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
            Assert.IsTrue(result3);
        }
    }
}
