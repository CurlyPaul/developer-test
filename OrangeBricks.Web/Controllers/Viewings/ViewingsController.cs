using OrangeBricks.Web.Attributes;
using OrangeBricks.Web.Controllers.Property.Builders;
using OrangeBricks.Web.Controllers.Viewings.Commands;
using Microsoft.AspNet.Identity;
using OrangeBricks.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrangeBricks.Web.Controllers.Viewings.Builders;

namespace OrangeBricks.Web.Controllers.Viewings
{
    public class ViewingsController : Controller
    {
        private readonly IOrangeBricksContext _context;

        public ViewingsController(IOrangeBricksContext context)
        {
            _context = context;
        }

        [OrangeBricksAuthorize]
        public ActionResult BookViewing(int propertyId)
        {
            var builder = new BookViewingViewModelBuilder(_context);
            var viewModel = builder.Build(propertyId);
            return View(viewModel);
        }

        [HttpPost]
        [OrangeBricksAuthorize(Roles = "Buyer")]
        public ActionResult BookViewing(CreateViewingCommand command)
        {
            var handler = new CreateViewingCommandHandler(_context);

            command.BuyerId = User.Identity.GetUserId();

            handler.Handle(command);

            return RedirectToAction("Index", "Property");
        }

        [OrangeBricksAuthorize(Roles = "Seller")]
        public ActionResult OnProperty(int Id)
        {
            var builder = new ViewingsOnPropertyViewModelBuilder(_context);
            var viewModel = builder.Build(Id);

            return View(viewModel);

        }
    }
}