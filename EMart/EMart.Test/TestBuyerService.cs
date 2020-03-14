using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using EMart.BuyerService.Models;
using EMart.BuyerService.Repositories;
namespace EMart.Test
{
    [TestFixture]
    class TestBuyerService
    {
        BuyerRepository _brepo;
       [SetUp]
        public void SetUp()
        {
            _brepo= new BuyerRepository(new EMartDBContext());
        }

        [Test]
        [Description("Test SearchItems()")]
        public void TestSearchItems()
        {
           var result= _brepo.SearchItems("App");
            Assert.IsNotNull(result);
        }

        [Test]
        [Description("Test BuyItem()")]
        public void TestBuyItem()
        {
            _brepo.BuyItem(new TransactionHistory()
            {
                
                BuyerId = "B0517",
                SellerId = "1",
                TransactionId = "T045",
                ItemId = "I86",
                NumberOfItems = "2",
                DateTime = DateTime.Now,
                //Remarks = "Good",
                TransactionType = "Debit Card"
            }
           );
            var result = _brepo.TransactionHistory("B0517");

            Assert.IsNotNull(result);
        }

        [Test]
        [Description("Test EditProfile()")]
        public void TestEditProfile()
        {
            _brepo.EditProfile(new Buyer()
            {
                BuyerId = "B054",
                UserName = "Lavanya",
                Password = "lavanya",
                EmailId = "lav@gmail.com",
                MobileNo = "9134308675",
                CreatedDateTime = DateTime.Now
            });

            var result = _brepo.ViewProfile("B054");
            Assert.IsNotNull(result);
        }


        [Test]
        [Description("Test TransactionHistory()")]
        public void TestTransactionHistory()
        {
            var result = _brepo.TransactionHistory("B054");
            Assert.IsNotNull(result);
        }

        [Test]
        [Description("Test GetCategories()")]
        public void TestGetCategories()
        {
            var result = _brepo.GetCategories();
            Assert.IsNotNull(result);
        }


        [Test]
        [Description("Test GetSubCategories()")]
        public void TestGetSubCategories()
        {
            var result = _brepo.GetSubCategories("SC38");
            Assert.IsNotNull(result);
        }


        [Test]
        [Description("Test AddtoCart()")]
        public void TestAddtoCart()
        {
            _brepo.Addtocart(new Cart()
            {
                CartId = "CT2",
                BuyerId="5",
                CategoryId = "1",
                SubcategoryId = "SC11",
                SellerId = "1",
                ItemId = "I772",
                Itemname = "Redmi",
                Price = "I853",
                Description = "Black in color",
               
                Image = "electronic2.jpg"
            });

            var result = _brepo.ViewCart("5");
            Assert.IsNotNull(result);
        }

        [Test]
        [Description("Test Deletefromcart()")]
        public void TestDeletefromcart()
        {
            _brepo.Deletefromcart("9");
            var result = _brepo.ViewCart("5");

            Assert.IsNotNull(result);
        }


    }
}


