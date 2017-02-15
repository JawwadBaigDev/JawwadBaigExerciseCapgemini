using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace JawwadBaigExerciseCapgemini
{

    public class ShopBillingSystem
    {

        public double StandardBill(List<string> itemList)
        {
            return 0;

        }

    }



    [TestClass]
    public class UnitTestsForShopSystem
    {
        // Step 1
        [TestMethod]
        public void StandardBillCanBeReturned()
        {
            ShopBillingSystem taxCodeFinder = new ShopBillingSystem();
            List<string> itemList = new List<string>();
            Assert.AreEqual(taxCodeFinder.StandardBill(itemList), 0);
        }
    }



}
