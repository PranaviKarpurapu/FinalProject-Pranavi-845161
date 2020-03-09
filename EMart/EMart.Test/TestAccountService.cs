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

        //[Test]
        //[Description("Test BuyerRegister()")]
        //public void TestBuyerRegister()
        //{
        //    _acrepo.BuyerRegister(new Buyer()
        //    {
        //        BuyerId = "B054",
        //        UserName = "Lavanya",
        //        Password="lavanya",
        //        EmailId="lav@gmail.com",
        //        MobileNo="9183086775",
        //        CreatedDateTime=DateTime.Now
        //    });

        //    var result = _acrepo.BuyerLogin("Lavanya", "lavanya");
        //    Assert.IsNotNull(result);
        //}

        //[Test]
        //[Description("Test SellerRegister()")]
        //public void TestSellerRegister()
        //{
        //    _acrepo.SellerRegister(new Seller()
        //    {
        //        SellerId="S076",
        //        UserName="Rishika",
        //        Password="rani",

        //        EmailId="rishi@gmail.com",
        //        MobileNo="9985643876",
        //        CompanyName="Rishi Says",
        //        Gstin="JX691B",
        //        BriefDetails="Good Products",
        //        Website="QualityGoods.com",
        //        PostalAddress="Godavari"
        //    });

        //    var result = _acrepo.SellerLogin("Rishika", "rani");
        //    Assert.IsNotNull(result);
        //}



    }
}
