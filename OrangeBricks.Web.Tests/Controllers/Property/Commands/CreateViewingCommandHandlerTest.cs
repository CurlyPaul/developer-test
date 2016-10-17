using System.Data.Entity;
using NSubstitute;
using NUnit.Framework;
using OrangeBricks.Web.Controllers.Property.Commands;
using OrangeBricks.Web.Models;
using OrangeBricks.Web.Controllers.Viewings.Commands;
using System;

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
            // Arrange
            var command = new CreateViewingCommand();

            // Act
            _handler.Handle(command);

            // Assert
            _context.Viewings.Received(1).Add(Arg.Any<Models.Viewing>());
        }

        [Test]
        public void HandlerCreatesViewingForCorrectBuyer()
        {
            // Arrange
            var command = new CreateViewingCommand
            {
                BuyerId = "TestBuyer"
            };

            // Act
            _handler.Handle(command);

            // Assert
            _context.Viewings.Received(1).Add(Arg.Is<Models.Viewing>(x => x.BuyerId == "TestBuyer"));
        }

        [Test]
        public void HandlerCreatesViewingForCorrectProperty()
        {
            // Arrange
            var command = new CreateViewingCommand
            {
                BuyerId = "TestBuyer",
                PropertyId = 1,
            };

            // Act
            _handler.Handle(command);

            // Assert
            _context.Viewings.Received(1).Add(Arg.Is<Models.Viewing>(x => x.PropertyId == 1));
        }



        [Test]
        public void HanderCreatesViewingAtCorrectTime()
        {
            // Arrange
            DateTime viewingTime = DateTime.Now;

            var command = new CreateViewingCommand
            {
                BuyerId = "TestBuyer",
                PropertyId = 1,
                ViewingAt = viewingTime
            };

            // Act
            _handler.Handle(command);

            // Assert
            _context.Viewings.Received(1).Add(Arg.Is<Models.Viewing>(x => x.ViewingAt == viewingTime));
        }
    }
}
