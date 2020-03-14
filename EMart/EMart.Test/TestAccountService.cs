using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using EMart.AccountService.Models;
using EMart.AccountService.Repositories;

namespace EMart.Test
{
    [TestFixture]
    class TestAccountService
    {
        AccountRepository _acrepo;

        [SetUp]
        public void Setup()
        {
            _acrepo = new AccountRepository(new EMartDBContext());
        }


        [Test]
        [Description("Test BuyerLogin()")]
        public void TestBuyerLogin()
        {
            var result=_acrepo.BuyerLogin("SaiKrishna", "saikrishna");
            Assert.IsNotNull(result);
        }

        [Test]
        [Description("Test SellerLogin()")]
        public void TestSellerLogin()
        {
            var result = _acrepo.SellerLogin("Pranavi", "pran48");
            Assert.IsNotNull(result);
        }

        [Test]
        [Description("Test BuyerRegister()")]
        public void TestBuyerRegister()
        {
            _acrepo.BuyerRegister(new Buyer()
            {
                BuyerId = "B0517",
                UserName = "Vyshnavi",
                Password = "vyshnavi",
                EmailId = "vyshu@gmail.com",
                MobileNo = "9183087858",
                CreatedDateTime = DateTime.Now
            });

            var result = _acrepo.BuyerLogin("Vyshnavi", "vyshnavi");
            Assert.IsNotNull(result);
        }

        [Test]
        [Description("Test SellerRegister()")]
        public void TestSellerRegister()
        {
            _acrepo.SellerRegister(new Seller()
            {
                SellerId = "S094",
                UserName = "Reshma",
                Password = "reshma",

                EmailId = "reshma@gmail.com",
                MobileNo = "9985647656",
                CompanyName = "CraftsGO",
                Gstin = "H6C5A",
                BriefDetails = "craftsgo.com",
                PostalAddress = "Tenali"
            });

            var result = _acrepo.SellerLogin("Reshma", "reshma");
            Assert.IsNotNull(result);
        }



    }
}
