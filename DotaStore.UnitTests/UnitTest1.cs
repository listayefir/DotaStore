using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DotaStore.Domain.Abstract;
using DotaStore.Domain.Entities;
using DotaStore.UI.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DotaStore.UI.HtmlHelpers;
using DotaStore.UI.Models;
using Moq;

namespace DotaStore.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        private ItemsController _controller;
        private void SetObject()
        {
            Mock<IRepository> mock = new Mock<IRepository>();
            mock.Setup(m => m.Items).Returns(new Item[]
            {
                new Item
                {
                    Cathegory = "Badge",
                    Description = null,
                    ID = new Guid(),
                    Name = "A",
                    Picture = null,
                    Price = 15.00m,
                    ProductionDate = null
                },
                new Item
                {
                    Cathegory = "Badge",
                    Description = null,
                    ID = new Guid(),
                    Name = "B",
                    Picture = null,
                    Price = 15.00m,
                    ProductionDate = null
                },
                new Item
                {
                    Cathegory = "Badge",
                    Description = null,
                    ID = new Guid(),
                    Name = "C",
                    Picture = null,
                    Price = 15.00m,
                    ProductionDate = null
                },
                new Item
                {
                    Cathegory = "Badge",
                    Description = null,
                    ID = new Guid(),
                    Name = "D",
                    Picture = null,
                    Price = 15.00m,
                    ProductionDate = null
                },
                new Item
                {
                    Cathegory = "Badge",
                    Description = null,
                    ID = new Guid(),
                    Name = "E",
                    Picture = null,
                    Price = 15.00m,
                    ProductionDate = null
                },
                new Item
                {
                    Cathegory = "T-Shirt",
                    Description = null,
                    ID = new Guid(),
                    Name = "F",
                    Picture = null,
                    Price = 15.00m,
                    ProductionDate = null
                },
                new Item
                {
                    Cathegory = "T-Shirt",
                    Description = null,
                    ID = new Guid(),
                    Name = "G",
                    Picture = null,
                    Price = 15.00m,
                    ProductionDate = null
                }
            }.AsEnumerable()
        );
            _controller = new ItemsController(mock.Object);
        }
        [TestMethod]
        public void CanPaginate()
        {
            SetObject();
            _controller.PageSize = 2;

           var result =
                ((ItemsViewModel)_controller.List(null,3).Model).Items.ToArray();

            Assert.IsTrue(result.Length==2);
            Assert.AreEqual("E", result[0].Name);
            Assert.AreEqual("F", result[1].Name);
        }

        [TestMethod]
        public void PageLinckGenerationTest()
        {
            HtmlHelper helper = null;

            PagingInfo info = new PagingInfo()
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
            };

            Func<int,string> pageUrlDelegate = i => "Page" + i;

            var result = helper.PageLinks(info, pageUrlDelegate);

            Assert.AreEqual(@"<a href=""Page1"">1</a>"
                            + @"<a class=""selected"" href=""Page2"">2</a>"
                            + @"<a href=""Page3"">3</a>",result.ToString());


        }

        [TestMethod]
        public void SendingPaginationInfoTest()
        {
            SetObject();
            _controller.PageSize = 2;

            var result = (ItemsViewModel) _controller.List(null,3).Model;

            PagingInfo pageInfo = result.PagingInfo;

            Assert.AreEqual(3, pageInfo.CurrentPage);
            Assert.AreEqual(2,pageInfo.ItemsPerPage);
            Assert.AreEqual(7,pageInfo.TotalItems);
            Assert.AreEqual(4,pageInfo.TotalPages);
        }

        [TestMethod]
        public void ItemFilterTest()
        {
            SetObject();
            _controller.PageSize = 2;

            var result = ((ItemsViewModel) _controller.List("T-Shirt", 1).Model).Items.ToArray();

            Assert.AreEqual(2, result.Length);
            Assert.AreEqual("F", result[0].Name);
            Assert.AreEqual("G",result[1].Name);
        }

        [TestMethod]
        public void CatCreateTest()
        {
           var mock = new Mock<IRepository>();
            
           mock.Setup(m => m.Items).Returns(new Item[]
            {
                new Item
                {
                    Cathegory = "Badge",
                    Description = null,
                    ID = new Guid(),
                    Name = "A",
                    Picture = null,
                    Price = 15.00m,
                    ProductionDate = null
                },
                new Item
                {
                    Cathegory = "Badge",
                    Description = null,
                    ID = new Guid(),
                    Name = "B",
                    Picture = null,
                    Price = 15.00m,
                    ProductionDate = null
                },
                new Item
                {
                    Cathegory = "Badge",
                    Description = null,
                    ID = new Guid(),
                    Name = "C",
                    Picture = null,
                    Price = 15.00m,
                    ProductionDate = null
                },
                new Item
                {
                    Cathegory = "Badge",
                    Description = null,
                    ID = new Guid(),
                    Name = "D",
                    Picture = null,
                    Price = 15.00m,
                    ProductionDate = null
                },
                new Item
                {
                    Cathegory = "Badge",
                    Description = null,
                    ID = new Guid(),
                    Name = "E",
                    Picture = null,
                    Price = 15.00m,
                    ProductionDate = null
                },
                new Item
                {
                    Cathegory = "T-Shirt",
                    Description = null,
                    ID = new Guid(),
                    Name = "F",
                    Picture = null,
                    Price = 15.00m,
                    ProductionDate = null
                },
                new Item
                {
                    Cathegory = "T-Shirt",
                    Description = null,
                    ID = new Guid(),
                    Name = "G",
                    Picture = null,
                    Price = 15.00m,
                    ProductionDate = null
                }
            }.AsEnumerable()
        );
            var target = new NavController(mock.Object);

            var results = ((IEnumerable<string>) target.Menu().Model).ToArray();

            Assert.AreEqual(2, results.Length);
            Assert.AreEqual("Badge", results[0]);
            Assert.AreEqual("T-Shirt",results[1]);
        }

        [TestMethod]
        public void CategoryIndicationTest()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(m => m.Items).Returns(new Item[]
            {
                new Item
                {
                    Cathegory = "A",
                    Description = null,
                    ID = new Guid(),
                    Name = "A",
                    Picture = null,
                    Price = 15.00m,
                    ProductionDate = null
                },
                new Item
                {
                    Cathegory = "B",
                    Description = null,
                    ID = new Guid(),
                    Name = "B",
                    Picture = null,
                    Price = 15.00m,
                    ProductionDate = null
                }
            });

            var target = new NavController(mock.Object);
            string category = "B";

            var result = target.Menu(category).ViewBag.SelectedCategory;

            Assert.AreEqual(category,result);

        }
        
    }

}

