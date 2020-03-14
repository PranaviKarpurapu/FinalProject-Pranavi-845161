using System;
using System.Collections.Generic;
using System.Text;
using EMart.AdminService.Repositories;
using EMart.AdminService.Models;

using NUnit.Framework;

namespace EMart.Test
{
    [TestFixture]
    class TestAdminService
    {
        AdminRepository _adrepo;

        [SetUp]
        public void SetUp()
        {
            _adrepo = new AdminRepository(new EMartDBContext());
        }

        [Test]
        [Description("Test AddCategories()")]
        public void TestAddCategories()
        {
            _adrepo.AddCategories(new Category()
            {
                CategoryId="C604",
                CategoryName="Bag",
                BriefDetails="Different types"
            });

            var result = _adrepo.GetCatById("C604");
            Assert.IsNotNull(result);
        }

        [Test]
        [Description("Test AddSubCategories()")]
        public void TestAddSubCategories()
        {
            _adrepo.AddSubCategories(new SubCategory()
            {
                SubcategoryId = "SC579",
                SubcategoryName = "Schools Bags",
                CategoryId="C694",
                BriefDetails = "Different Colors",
                Gst="56VDFG"
            });

            var result = _adrepo.GetSubCatById("SC579");
            Assert.IsNotNull(result);
        }

        [Test]
        [Description("Test GetCategories()")]
        public void TestGetCategories()
        {
            var result = _adrepo.GetCategories();
            Assert.IsNotNull(result);
        }

        [Test]
        [Description("Test GetCategories()")]
        public void TestViewCategories()
        {
            var result = _adrepo.ViewCategories();
            Assert.IsNotNull(result);
        }

        [Test]
        [Description("Test ViewSubCategories()")]
        public void TestViewSubCategories()
        {
            var result = _adrepo.ViewSubCategories();
            Assert.IsNotNull(result);
        }

        [Test]
        [Description("Test EditCategories()")]
        public void TestEditCategories()
        {
            _adrepo.EditCategories(new Category
            {
                CategoryId = "C694",
                CategoryName = "Bags",
                BriefDetails = "Differnt Bags"
            });

            var result = _adrepo.GetCatById("C694");
            Assert.IsNotNull(result);
        }

        [Test]
        [Description("Test EditSubCategories()")]
        public void TestEditSubCategories()
        {
            _adrepo.EditSubCategories(new SubCategory
            {
                SubcategoryId = "SC579",
                SubcategoryName = "College Bags",
                CategoryId = "C694",
                BriefDetails = "Types of Bags",
                Gst = "HW74B9"
            });

            var result = _adrepo.GetSubCatById("SC579");
            Assert.IsNotNull(result);
        }


        [Test]
        [Description("Test DeleteSubCategories()")]
        public void TestDeleteSubCategories()
        {
            _adrepo.DeleteSubCategories("SC570");

            var result = _adrepo.GetSubCatById("SC570");
            Assert.IsNull(result);
        }

        [Test]
        [Description("Test DeleteCategories()")]
        public void TestDeleteCategories()
        {
            _adrepo.DeleteCategories("C604");

            var result = _adrepo.GetCatById("C604");
            Assert.IsNull(result);
        }
    }
}
