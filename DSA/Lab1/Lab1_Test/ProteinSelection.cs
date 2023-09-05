using System.ComponentModel.Design;
using Lab1;

namespace Lab1_Test
{
    [TestClass]
    public class ProteinSelection
    {

        RestaurantMenu menu;
        [TestInitialize]
        public void TestSetup()
        {
            menu = new RestaurantMenu();
        }

        [TestMethod]
        [DataRow("Beef", "Hamburger")]
        [DataRow("Pepperoni", "Pizza")]
        [DataRow("Tofu", "Tofu Fried Rice")]
        public void TestWithExpectedProtienTypeShouldReturnCorrespondingDishes(string proteinChoice, string menuItem)
        {
            string dish = menu.GetDishRecommendation(proteinChoice);
            Assert.AreEqual(menuItem, dish, true);
        }
        [TestMethod]
        public void TestWith_UNExpected_ProteinTypeShouldReturnMessageProteinNotAvailable()
        {
            string dish = menu.GetDishRecommendation("fish");
            Assert.AreEqual("That protein is not available.", dish, true);
        }
    }
}
