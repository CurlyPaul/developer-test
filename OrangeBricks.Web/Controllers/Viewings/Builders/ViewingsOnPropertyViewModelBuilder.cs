using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OrangeBricks.Web.Controllers.Viewings.ViewModels;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Controllers.Viewings.Builders
{
    public class ViewingsOnPropertyViewModelBuilder
    {
        private readonly IOrangeBricksContext _context;

        public ViewingsOnPropertyViewModelBuilder(IOrangeBricksContext context)
        {
            this._context = context;
        }

        public ViewingsOnPropertyViewModel Build(int propertyId)
        {
            var property = _context.Properties
                .Where(p => p.Id == propertyId)
                .Include(x => x.Viewings)
                .SingleOrDefault();

            var viewings = _context.Viewings.Where(v=> v.PropertyId == propertyId);

            return new ViewingsOnPropertyViewModel()
            {
                PropertyId = property.Id,
                PropertyType = property.PropertyType,
                NumberOfBedrooms = property.NumberOfBedrooms,
                StreetName = property.StreetName,
                HasViewings = viewings.Any(),
                Viewings = viewings.Select(v => new SellersViewingOnPropertyViewModel
                {
                    ViewingAt = v.ViewingAt
                } )
            };
        }
    }
}