using OrangeBricks.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.Viewings.Commands
{
    public class CreateViewingCommandHandler
    {
        private IOrangeBricksContext _context;

        public CreateViewingCommandHandler(IOrangeBricksContext context)
        {
            this._context = context;
        }

        public void Handle(CreateViewingCommand commmand)
        {
            var viewing = new Models.Viewing
            {
               
            };

            _context.Viewings.Add(viewing);

            _context.SaveChanges();
        }
    }
}