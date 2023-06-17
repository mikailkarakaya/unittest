using Architecht.Ecommerce;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architecht.UnitTest
{
    [TestFixture(Description = "Test yapıyoruz", Author = "Architecht", Category = "Unit Test Örnekleri")]
    public class BasketTest
    {
        private BasketItem basketItem;
        private BasketHelper basketHelper;

        [OneTimeSetUp]
        public void TestInitialize()
        {
            basketHelper = new BasketHelper();
            basketItem = new BasketItem
            {
                Product = new Product
                {
                    Id = 1,
                    Name = "Televizyon",
                    UnitPrice = 250000
                },
                Quantity = 7
            };
            basketHelper.Add(basketItem);

            basketHelper.Add(new BasketItem
            {
                Product = new Product
                {
                    Id = 1,
                    Name = "Saat",
                    UnitPrice = 12000
                },
                Quantity = 3
            }
            );
            basketHelper.Add(new BasketItem
            {
                Product = new Product
                {
                    Id = 1,
                    Name = "Buzdolabı",
                    UnitPrice = 45000
                },
                Quantity = 5
            }
           );
        }
     
        [OneTimeTearDown]
        public void TestClean()
        {
            basketHelper.Dispose();
        }

        [Test]
        public void AddProductInBasket()
        {
            #region Arrange

            const int excepted = 2;

            #endregion

            #region Act
            var totalItems = basketHelper.TotalItems();
            #endregion

            #region Assert
            Assert.AreEqual(excepted, totalItems);
            #endregion
        }
        [TestCase(1, Description = "Sepetten ürün silen method")]
        public void RemoveProductInBasket(int basketId)
        {
            #region Arrange
            var totalItemsInBasket = basketHelper.TotalItems();
            #endregion

            #region Act
            basketHelper.Remove(basketId);
            var totalItems = basketHelper.TotalItems();
            #endregion

            #region Assert
            Assert.AreEqual(totalItemsInBasket - 1, totalItems);
            #endregion
        }

        [Test]
        public void AssertionControlExamples()
        {
            #region Arrange
            //const int result = 12;
            //const int expected = 5;
            #endregion

            #region Assert

            #region Comparison Constraints

            //Assert.That(result, Is.EqualTo(5));
            //Assert.That(result, Is.Not.EqualTo(5));

            //Assert.That(result, Is.GreaterThan(expected));
            //Assert.That(result, Is.GreaterThanOrEqualTo(expected));


            //Assert.That(result, Is.LessThan(expected));
            //Assert.That(result, Is.LessThanOrEqualTo(expected));

            //Assert.That(result, Is.InRange(0, expected));

            #endregion

            #region Conditional Constraints

            // string[] fruits = new string[] { "Elma", "Muz", "Erik", "Elma" };


            //Assert.That(fruits, Is.Null);
            //Assert.That(fruits, Is.Not.Null);
            //Assert.That(fruits.Length > 0, Is.True);
            //Assert.That(fruits.Length > 0, Is.False);
            //Assert.That(fruits, Is.Empty);


            #endregion

            #region String Constraints
            const string strinResult = "ArchiTecht";

            //Assert.That(strinResult, Is.EqualTo("archiTecht").IgnoreCase);

            //Assert.That(strinResult, Is.EqualTo("architecht"));
            //Assert.That(strinResult, Is.Not.EqualTo("architecht"));

            //Assert.That(strinResult, Does.Contain("arch"));
            //Assert.That(strinResult, Does.Not.Contain("echt"));
            //Assert.That(strinResult, Does.Contain("arch").IgnoreCase);
            //Assert.That(strinResult, Does.Not.Contain("echt").IgnoreCase);

            //Assert.That(strinResult, Is.Empty);
            //Assert.That(strinResult, Is.Not.Empty);

            //Assert.That(strinResult, Does.StartWith("arch"));
            //Assert.That(strinResult, Does.Not.StartWith("echt"));

            //Assert.That(strinResult, Does.EndWith("arch"));
            //Assert.That(strinResult, Does.Not.EndWith("echt"));


            //Assert.That(strinResult, Does.Match("a*t"));
            //Assert.That(strinResult, Does.Not.Match("t*a"));

            #endregion

            #region Compound Constraints

            //Assert.That(result, Is.GreaterThan(4).And.LessThan(10));
            //Assert.That(result, Is.LessThan(1).Or.GreaterThan(4));
            //Assert.That(result, Is.Not.EqualTo(7));
            //Assert.That(fruits, Is.Not.Null.And.InstanceOf<string>().Or.Unique.Or.Ordered.Descending.And.Contain("kuş"));


            #endregion

            #region Collection Constraints

            //int[] years = new int[] { 2022, 2021, 2021, 2023, 2024, 2025 };

            //Assert.That(years, Is.All.Not.Null);
            //Assert.That(years, Is.All.GreaterThan(2020));
            //Assert.That(years, Is.All.LessThan(2053));
            //Assert.That(years, Is.All.InstanceOf<Int32>());
            //Assert.That(years, Is.All.InstanceOf<string>());
            //Assert.That(years, Is.Empty);
            //Assert.That(years, Is.Not.Empty);
            //Assert.That(years, Has.Exactly(2).Items);//dizi içerisinde kaç tane Item olduğunu kontrol eder
            //Assert.That(years, Is.Unique);// tüm dizi elemanlarının uniq olup olmadığını kontrol eder
            //Assert.That(years, Contains.Item(4));//dizi içerisinde 4 olan bir item var mı kontrol eder
            //Assert.That(years, Is.Ordered.Ascending);//dizi de  Ascending bir sıralama var mı kontrolu yapar
            //Assert.That(years, Is.Ordered.Descending);

            //var basketItems = basketHelper.BasketItems;

            //Assert.That(basketItems, Is.Ordered.Ascending.By("Quantity"));
            //Assert.That(basketItems, Is.Ordered.Descending.By("Quantity"));

            //Assert.That(basketItems, Is.Ordered.Ascending.By("Quantity").Then.Descending.By("UnitPrice"));


            #endregion

            #region Exceptions Constraints

            //BasketItem item = new BasketItem();
            //item.Quantity= 0;

            //Assert.Throws<Exception>(() => item.CalculatePrice());
            //Exception ex = Assert.Throws<Exception>(() => item.CalculatePrice());

            //Assert.That(ex.Message, Is.EqualTo("Test için method exception döndü mü ?"));

            #endregion

            #region Directory / File Constraints
            //string path = @"C:\Users\Documents";
            //Assert.That(new FileInfo(path), Does.Exist);
            //Assert.That(new FileInfo(path), Does.Not.Exist);

            //Assert.That(new DirectoryInfo(path), Does.Exist);
            //Assert.That(new DirectoryInfo(path), Does.Not.Exist);

            //Assert.That(path, Is.SamePath(@"c:\downloads\images").IgnoreCase);
            //Assert.That(new DirectoryInfo(path), Is.Empty);

            #endregion

            #region Type / Reference Constraints

            Product productItem = new Product();

            //Assert.That(productItem, Is.InstanceOf<Product>());

            //Assert.That(productItem, Is.Not.InstanceOf<string>());

            //Assert.That(productItem, Is.TypeOf<Product>());

            //Assert.That(productItem, Is.AssignableTo<Product>());

            Assert.Pass();

            #endregion




            #endregion
        }


        [TestCase(11, ExpectedResult = false,Description ="TestCase niteliği için örnek")]
        public bool TestCaseControlExample(int? param1)
        {
            #region Arrange
            const int result = 12;
            #endregion

            #region Act
            #endregion

            #region Assert

            return param1 > result;

            #endregion
        }


        [TestCase(Bank.KUVEYTTURK)]
        public void TestControlForMoqFramework(Bank bankName)
        {
            #region Arrange
            var moqValidator = new Mock<ICheckout>();
            moqValidator.Setup(m => m.GoBankForPayment(bankName)).Returns("Architecht");
            #endregion

            #region Act

            string response = moqValidator.Object.GoBankForPayment(bankName);

            #endregion

            #region Assert
            Assert.AreEqual("Architecht", response);
            moqValidator.Verify(x => x.GoBankForPayment(bankName), Times.Never());
            #endregion
        }

    }
}
