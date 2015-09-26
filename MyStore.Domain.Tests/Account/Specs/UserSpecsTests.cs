using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyStore.Domain.Account.Entities;
using System.Collections.Generic;
using MyStore.Domain.Account.Specs;

namespace MyStore.Domain.Tests.Account.Specs
{
    [TestClass]
    public class UserSpecsTests
    {
        private List<User> _users;

        public UserSpecsTests()
        {
            _users = new List<User>();

            _users.Add(new User("andrebaltieri@hotmail.com", "andrebaltieri", "123456"));
            _users.Add(new User("ironman@hotmail.com", "ironman", "123456"));
            _users.Add(new User("batman@hotmail.com", "batman", "123456"));
            _users.Add(new User("spiderman@hotmail.com", "spiderman", "123456"));
        }

        [TestMethod]
        [TestCategory("User - Specs")]
        public void GetByUsernameShouldReturnValue()
        {
            var user = _users
                .AsQueryable()
                .Where(UserSpecs.GetByUsername("andrebaltieri"))
                .FirstOrDefault();

            Assert.AreNotEqual(null, user);
        }

        [TestMethod]
        [TestCategory("User - Specs")]
        public void GetByUsernameShouldNotReturnValue()
        {
            var user = _users
                .AsQueryable()
                .Where(UserSpecs.GetByUsername("andrebaltieri258794"))
                .FirstOrDefault();

            Assert.AreEqual(null, user);
        }
    }
}
