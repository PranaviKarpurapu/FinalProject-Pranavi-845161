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
                CategoryId="C571",
                CategoryName="Book",
                BriefDetails="Types of Books"
            });

            var result = _adrepo.GetCatById("C571");
            Assert.IsNotNull(result);
        }

        [Test]
        [Description("Test AddSubCategories()")]
        public void TestAddSubCategories()
        {
            _adrepo.AddSubCategories(new SubCategory()
            {
                SubcategoryId = "SC571",
                SubcategoryName = "Book",
                CategoryId="C571",
                BriefDetails = "Types of Books",
                Gst="HW74B9"
            });

            var result = _adrepo.GetSubCatById("SC571");
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
                CategoryId = "C571",
                CategoryName = "Books",
                BriefDetails = "Differnt Books"
            });

            var result = _adrepo.GetCatById("C571");
            Assert.IsNotNull(result);
        }

        [Test]
        [Description("Test EditSubCategories()")]
        public void TestEditSubCategories()
        {
            _adrepo.EditSubCategories(new SubCategory
            {
                SubcategoryId = "SC571",
                SubcategoryName = "Lepakshi Books",
                CategoryId = "C571",
                BriefDetails = "Types of Books",
                Gst = "HW74B9"
            });

            var result = _adrepo.GetSubCatById("SC571");
            Assert.IsNotNull(result);
        }


        [Test]
        [Description("Test DeleteSubCategories()")]
        public void TestDeleteSubCategories()
        {
            _adrepo.DeleteSubCategories("SC571");

            var result = _adrepo.GetSubCatById("SC571");
            Assert.IsNull(result);
        }

        [Test]
        [Description("Test DeleteCategories()")]
        public void TestDeleteCategories()
        {
            _adrepo.DeleteCategories("C571");

            var result = _adrepo.GetCatById("C571");
            Assert.IsNull(result);
        }
    }
}
