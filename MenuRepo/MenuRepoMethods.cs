using MenuClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuRepo
{
    public class MenuRepoMethods
    {
        private List<Menu> _listOfMenuOptions = new List<Menu>();

        // Create
        public void CreateNewMenuOption(Menu option)
        {
            _listOfMenuOptions.Add(option);
        }
        // Read
        public List<Menu> MenuList()
        {
            return _listOfMenuOptions;
        }
        // Delete
        public bool RemoveMenuOption(int id)
        {
            Menu menuOption = GetIdOfMenuOption(id);

            if (menuOption == null)
            {
                return false;
            }

            int count = _listOfMenuOptions.Count;
            _listOfMenuOptions.Remove(menuOption);

            if (count > _listOfMenuOptions.Count)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        // Helper method
        public Menu GetIdOfMenuOption(int id)
        {
            foreach (Menu menuOption in _listOfMenuOptions)
            {
                if (menuOption.FoodId == id)
                {
                    return menuOption;
                }
            }
            return null;
        }
    }
}
