using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using EMart.SellerService.Models;
using EMart.SellerService.Repositories;

namespace EMart.Test
{
    
    [TestFixture]
    class TestSellerService
    {
        SellerRepository _srepo;
        ItemRepository _irepo;
        [SetUp]
        public void SetUp()
        {
            _srepo = new SellerRepository(new EMartDBContext());
            _irepo = new ItemRepository(new EMartDBContext());
        }


        [Test]
        [Description("Test EditProfile()")]
        public void TestEditProfile()
        {
            _srepo.EditProfile(new Seller()
            {
                SellerId = "S076",
                UserName = "Rishika",
                Password = "ranirishi",

                EmailId = "rishika@gmail.com",
                MobileNo = "9985643876",
                CompanyName = "Rishi Says",
                Gstin = "JX691B",
                BriefDetails = "Good Products",
                Website = "QualityGoods.com",
                PostalAddress = "Godavari"
            }
           );
            var result = _srepo.ViewProfile("S076");

            Assert.IsNotNull(result);
        }

        [Test]
        [Description("Test AddItem()")]
        public void TestAddItem()
        {
            _irepo.AddItem(new Items()
            {
                SellerId = "1",
                ItemId = "I074",
                CategoryId = "1",
                SubcategoryId = "SC38",
                Price = "900",
                ItemName = "Camera",
                Image = "electronic7",
                Description = "HD Quality",
                StockNumber = "60",
                Remarks="Good"
            }
           );
            var result = _irepo.GetItem("I074");

            Assert.IsNotNull(result);
        }

        [Test]
        [Description("Test ViewItems()")]
        public void TestViewItems()
        {
            
            var result = _irepo.ViewItems();

            Assert.IsNotNull(result);
        }


        [Test]
        [Description("Test DeleteItem()")]
        public void TestDeleteItem()
        {

            _irepo.DeleteItem("I853");
            var result = _irepo.GetItem("I853");
            Assert.IsNull(result);
        }


        [Test]
        [Description("Test UpdateItem()")]
        public void TestUpdateItem()
        {
            _irepo.UpdateItem(new Items()
            {
                SellerId = "1",
                ItemId = "I074",
                CategoryId = "1",
                SubcategoryId = "SC38",
                Price = "800",
                ItemName = "Camera",
                Image = "electronic7",
                Description = "HD Quality",
                StockNumber = "70",
                Remarks = "Good"
            }
           );
            var result = _irepo.GetItem("I074");

            Assert.IsNotNull(result);
        }

        [Test]
        [Description("Test GetCategories()")]
        public void TestGetCategories()
        {
            var result = _irepo.GetCategories();
            Assert.IsNotNull(result);
        }


        [Test]
        [Description("Test GetSubCategories()")]
        public void TestGetSubCategories()
        {
            var result = _irepo.GetSubCategories("SC38");
            Assert.IsNotNull(result);
        }


    }
}
