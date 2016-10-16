using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using OrangeBricks.Web.Controllers.Offers.Builders;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Tests.Controllers.Offers.Builders
{

    public static class ExtentionMethods
    {
        public static IDbSet<T> Initialize<T>(this IDbSet<T> dbSet, IQueryable<T> data) where T : class
        {
            dbSet.Provider.Returns(data.Provider);
            dbSet.Expression.Returns(data.Expression);
            dbSet.ElementType.Returns(data.ElementType);
            dbSet.GetEnumerator().Returns(data.GetEnumerator());
            return dbSet;
        }
    }

    [TestFixture]
    public class OffersOffBuyerViewModelBuilderTests
    {
        private IOrangeBricksContext _context;

        [SetUp]
        public void SetUp()
        {
            _context = Substitute.For<IOrangeBricksContext>();
        }

        [Test]
        public void BuildShouldReturnOffersThatMatchBuyersIds()
        {
            // Arrange
            var builder = new OffersOffBuyerViewModelBuilder(_context);

            var offers = new List<Models.Offer>{
                    new Models.Offer{ BuyerId = "TestBuyer" }
                };

            var mockSet = Substitute.For<IDbSet<Models.Offer>>()
                .Initialize(offers.AsQueryable());

            _context.Offers.Returns(mockSet);



            // Act
            var viewModel = builder.Build("TestBuyer");

            // Assert
            Assert.That(viewModel.Offers.Count, Is.EqualTo(1));
        }

        [Test]
        public void BuildShouldNotReturnOffersThatDoNotMatchBuyersIds()
        {
            // Arrange
            var builder = new OffersOffBuyerViewModelBuilder(_context);

            var offers = new List<Models.Offer>{
                    new Models.Offer{ BuyerId = "TestBuyer" }
                };

            var mockSet = Substitute.For<IDbSet<Models.Offer>>()
                .Initialize(offers.AsQueryable());

            _context.Offers.Returns(mockSet);



            // Act
            var viewModel = builder.Build("Other TestBuyer");

            // Assert
            Assert.That(viewModel.Offers.Count, Is.EqualTo(0));
        }
    }
}

