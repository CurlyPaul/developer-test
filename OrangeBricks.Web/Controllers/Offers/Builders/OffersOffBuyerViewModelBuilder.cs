using OrangeBricks.Web.Controllers.Offers.ViewModels;
using OrangeBricks.Web.Controllers.Property.ViewModels;
using OrangeBricks.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.Offers.Builders
{
    public class OffersOffBuyerViewModelBuilder
    {
        private readonly IOrangeBricksContext _context;

        public OffersOffBuyerViewModelBuilder(IOrangeBricksContext context)
        {
            _context = context;
        }

        public OffersOffBuyerViewModel Build(string buyerId)
        {

            var offers = _context.Offers.Where(o => o.BuyerId == buyerId);

            return new OffersOffBuyerViewModel
            {
                HasOffers = offers.Any(),
                Offers = offers
                .Select(o => new BuyersOfferViewModel() { 
                         Id = o.Id,
                         Amount = o.Amount,
                         CreatedAt = o.CreatedAt,
                         Status = o.Status.ToString(),
                         StreetName = o.Property.StreetName,
                         PropertyType = o.Property.PropertyType,

                       
                }).ToList()
            };

        }

    }
}