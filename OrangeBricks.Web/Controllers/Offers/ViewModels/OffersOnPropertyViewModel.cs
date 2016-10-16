using System;
using System.Collections.Generic;

namespace OrangeBricks.Web.Controllers.Offers.ViewModels
{
    public class OffersOnPropertyViewModel
    {
        public string PropertyType { get; set; }
        public int NumberOfBedrooms{ get; set; }
        public string StreetName { get; set; }
        public bool HasOffers { get; set; }
        public IEnumerable<SellersOfferViewModel> Offers { get; set; }
        public int PropertyId { get; set; }
    }

    public class SellersOfferViewModel
    {
        public int Id;
        public int Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsPending { get; set; }
        public string Status { get; set; }
    }
}