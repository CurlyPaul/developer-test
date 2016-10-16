using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.Offers.ViewModels
{
    public class OffersOffBuyerViewModel
    {
        public List<BuyersOfferViewModel> Offers { get; set; }

        public bool HasOffers { get; set; }
    }

    public class BuyersOfferViewModel
    {
        public int Id;
        public int Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; }
        public string PropertyType { get; set; }
        public string StreetName { get; set; }
        public int PropertyId { get; set; }

    }
}