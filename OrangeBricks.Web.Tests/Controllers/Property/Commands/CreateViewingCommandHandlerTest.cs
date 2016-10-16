using System.Data.Entity;
using NSubstitute;
using NUnit.Framework;
using OrangeBricks.Web.Controllers.Property.Commands;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Tests.Controllers.Property.Commands
{
    [TestFixture]
    public class CreateViewingCommandHandlerTest
    {
        private CreateViewingCommandHandler _handler;

        private IOrangeBricksContext _context;

        [SetUp]
        public void SetUp()
        {
            _context = Substitute.For<IOrangeBricksContext>();
            _context.Properties.Returns(Substitute.For<IDbSet<Models.Property>>());
            _handler = new CreateViewingCommandHandler(_context);
        }

        [Test]
        public void HandlerShouldCreateViewing()
        {
            Assert.Fail();
        }

        [Test]
        public void HandlerCreatesViewingForCorrectProperty()
        {
            Assert.Fail();
        }

        [Test]
        public void HandlerCreatesViewingForCorrectBuyer()
        {
            Assert.Fail();
        }

        [Test]
        public void HanderCreatesViewingAtCorrectTime()
        {
            Assert.Fail();
        }
    }
}
