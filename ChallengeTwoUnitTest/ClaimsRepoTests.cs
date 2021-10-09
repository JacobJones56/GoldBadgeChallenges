using ClaimsClass;
using ClaimsRepositroy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ChallengeTwoUnitTest
{
    [TestClass]
    public class ClaimsRepoTests
    {

        private ClaimsRepository _repoTest;
        private Claim _claimTest;

        [TestInitialize]
        public void Arrange()
        {
            _repoTest = new ClaimsRepository();
            _claimTest = new Claim(1, "Car", "Crash", 560.00m, new DateTime(2021, 05, 06), new DateTime(2021, 05, 09), true);
        }
        [TestMethod]
        public void Create_ClaimIsNotNull_ReturnFalse()
        {
            _repoTest.CreateNewClaim(_claimTest);
            Claim claimTest = _repoTest.PeekClaim();

            Assert.IsNotNull(claimTest);
        }
        
    }
}


