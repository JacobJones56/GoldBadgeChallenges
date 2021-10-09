using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuClass
{
    public class Menu
    {
        public string FoodName { get; set; }
        public int FoodNumber { get; set; }
        public int FoodId { get; set; }
        public string FoodInfo { get; set; }
        public decimal FoodPrice { get; set; }

        public Menu() { }

        public Menu(string foodName, int foodNumber, int foodId, string foodInfo, decimal foodPrice)
        {
            FoodName = foodName;
            FoodNumber = foodNumber;
            FoodId = foodId;
            FoodInfo = foodInfo;
            FoodPrice = foodPrice;
        }
    }
}
