using MenuClass;
using MenuRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ChallengeOneUnitTest
{
    [TestClass]
    public class MenuRepoTests 
    {

        [TestMethod]
        public void Create_MenuOptionIsNull_ReturnFalse()
        {
            Menu menuOption = null;
            MenuRepository menuRepoMethods = new MenuRepository();

            bool result = menuRepoMethods.CreateNewMenuOption(menuOption);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void Create_MenuOptionIsNotNull_ReturnTrue()
        {
            Menu menuOption = new Menu();
            MenuRepository menuRepoMethods = new MenuRepository();

            bool result = menuRepoMethods.CreateNewMenuOption(menuOption);

            Assert.IsTrue(result);
        }
    }
}
