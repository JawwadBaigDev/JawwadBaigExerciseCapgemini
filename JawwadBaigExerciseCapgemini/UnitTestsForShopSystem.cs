using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace JawwadBaigExerciseCapgemini
{

    public class ShopBillingSystem
    {

        class ItemDetails
        {
            public double Price { get; set; }
            public bool isHot { get; set; }

        }

        public double StandardBill(List<string> purchasedItems)
        {
            var menu = new Dictionary<string, ItemDetails>();

            menu.Add("Cola", new ItemDetails() { isHot = false, Price = 0.50 });
            menu.Add("Coffee", new ItemDetails() { isHot = true, Price = 1.00 });
            menu.Add("Cheese Sandwich", new ItemDetails() { isHot = false, Price = 2.00 });

            double runningTotal = 0;

            foreach (var item in purchasedItems)
            {
                runningTotal = runningTotal + menu[item].Price;
            }

            return runningTotal;

        }

    }



    [TestClass]
    public class UnitTestsForShopSystem
    {
        
        [TestMethod]
        public void StandardBillCanBeReturned()
        {
            ShopBillingSystem shopBillingSystem = new ShopBillingSystem();
            List<string> itemList = new List<string>();
            Assert.AreEqual(shopBillingSystem.StandardBill(itemList), 0);
        }

        
        [TestMethod]
        public void StandardBillByItemsReturned_1_50p()
        {
            ShopBillingSystem shopBillingSystem = new ShopBillingSystem();
            List<string> itemList = new List<string>();
            itemList.Add("Cola");
            itemList.Add("Coffee");
            Assert.AreEqual(shopBillingSystem.StandardBill(itemList), 1.50);
        }


        
        [TestMethod]
        public void NoServiceChargeForDrinks()
        {
            ShopBillingSystem shopBillingSystem = new ShopBillingSystem();
            List<string> itemList = new List<string>();
            itemList.Add("Cola");
            itemList.Add("Coffee");
            Assert.AreEqual(shopBillingSystem.StandardBill(itemList), 1.5);
        }

    }



}
