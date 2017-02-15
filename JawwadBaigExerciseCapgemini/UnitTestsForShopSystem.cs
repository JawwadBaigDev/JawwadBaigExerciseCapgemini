using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace JawwadBaigExerciseCapgemini
{

    public class ShopBillingSystem
    {

        enum MenuItemTypes
        {
            Drinks, Food
        }

        enum ServicCharges
        {
            TenPercent = 10, TwentyPercent = 20
        }

        class ItemDetails
        {
            public double Price { get; set; }
            public bool isHot { get; set; }
            public string itemType { get; set; }

        }

        public double StandardBill(List<string> purchasedItems)
        {
            var menu = new Dictionary<string, ItemDetails>();

            menu.Add("Cola", new ItemDetails() { isHot = false, itemType = MenuItemTypes.Drinks.ToString(), Price = 0.50 });
            menu.Add("Coffee", new ItemDetails() { isHot = true, itemType = MenuItemTypes.Drinks.ToString(), Price = 1.00 });
            menu.Add("Cheese Sandwich", new ItemDetails() { isHot = false, itemType = MenuItemTypes.Food.ToString(), Price = 2.00 });
            menu.Add("Steak Sandwich", new ItemDetails() { isHot = true, itemType = MenuItemTypes.Food.ToString(), Price = 4.50 });

            double runningTotal = 0;

            foreach (var item in purchasedItems)
            {
                runningTotal = runningTotal + menu[item].Price;
            }

            foreach (var item in purchasedItems)
            {
                if (DetectServiceCharges(menu[item].itemType, menu[item].isHot) == ServicCharges.TenPercent.ToString())
                {
                    runningTotal = runningTotal + runningTotal * 10 / 100;
                }
                else if (DetectServiceCharges(menu[item].itemType, menu[item].isHot) == ServicCharges.TwentyPercent.ToString())
                {
                    runningTotal = runningTotal + runningTotal * 20 / 100;
                }
            }

            return runningTotal;

        }

        public string DetectServiceCharges(string purchasedItemsType, bool isHot)
        {
            //step 6
            if (purchasedItemsType == MenuItemTypes.Food.ToString() && isHot)
            {
                return ServicCharges.TwentyPercent.ToString();
            }
            else if (purchasedItemsType == MenuItemTypes.Food.ToString() && !isHot)
            {
                return ServicCharges.TenPercent.ToString();
            }
            

            return string.Empty;
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

        // step 6
        [TestMethod]
        public void BillWithServiceCharge_10_Percent_ForFood()
        {
            ShopBillingSystem shopBillingSystem = new ShopBillingSystem();
            List<string> itemList = new List<string>();
            itemList.Add("Cola");
            itemList.Add("Coffee");
            itemList.Add("Cheese Sandwich");
            // one food item included so add 10% chanrge to total bill
            Assert.AreEqual(shopBillingSystem.StandardBill(itemList), 3.85);
        }

        [TestMethod]
        public void BillWithServiceCharge_20_Percent_ForHotFood()
        {
            ShopBillingSystem shopBillingSystem = new ShopBillingSystem();
            List<string> itemList = new List<string>();
            itemList.Add("Cola");
            itemList.Add("Coffee");
            itemList.Add("Steak Sandwich");
            // one hot food item included so add 20% chanrge to total bill
            Assert.AreEqual(shopBillingSystem.StandardBill(itemList), 7.2);
        }


    }



}
