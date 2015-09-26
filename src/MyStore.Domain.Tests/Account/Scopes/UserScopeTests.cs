using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyStore.Domain.Account.Entities;
using MyStore.Domain.Account.Scopes;

namespace MyStore.Domain.Tests.Scopes
{
    [TestClass]
    public class UserScopeTests
    {
        [TestMethod]
        [TestCategory("User - Scopes")]
        public void RegisterScopeIsValid()
        {
            var user = new User("andrebaltieri@hotmail.com", "andrebaltieri", "123456");
            Assert.AreEqual(true, user.RegisterScopeIsValid());
        }

        [TestMethod]
        [TestCategory("User - Scopes")]
        public void RegisterScopeIsInvalidWhenUsernameIsNull()
        {
            var user = new User("andrebaltieri@hotmail.com", "", "123456");
            Assert.AreEqual(false, user.RegisterScopeIsValid());
        }

        [TestMethod]
        [TestCategory("User - Scopes")]
        public void VerificationScopeIsValid()
        {            
            var user = new User("andrebaltieri@hotmail.com", "andrebaltieri", "123456");
            var verificationCode = user.VerificationCode;

            Assert.AreEqual(true, user.VerificationScopeIsValid(verificationCode));
        }

        [TestMethod]
        [TestCategory("User - Scopes")]
        public void VerificationScopeIsInvalid()
        {
            var user = new User("andrebaltieri@hotmail.com", "andrebaltieri", "123456");
            var verificationCode = "123456";

            Assert.AreEqual(false, user.VerificationScopeIsValid(verificationCode));
        }
    }
}
