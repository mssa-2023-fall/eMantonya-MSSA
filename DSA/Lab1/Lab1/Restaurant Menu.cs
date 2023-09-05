using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class RestaurantMenu
    {
        public string GetDishRecommendation(string proteinChoice)
        {
            switch (proteinChoice.ToLower())
            {
                case "beef":
                    return "Hamburger";
                case "pepperoni":
                    return "Pizza";
                case "tofu":
                    return "Tofu Fried Rice";
                default:
                    return "That protein is not available.";

            }
            
        }
    }
}
