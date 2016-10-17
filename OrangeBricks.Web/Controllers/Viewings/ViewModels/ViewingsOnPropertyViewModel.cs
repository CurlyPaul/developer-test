using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrangeBricks.Web.Controllers.Viewings.ViewModels
{
    public class ViewingsOnPropertyViewModel
    {
        public string PropertyType { get; set; }
        public int NumberOfBedrooms{ get; set; }
        public string StreetName { get; set; }
        public bool HasViewings { get; set; }
        public IEnumerable<SellersViewingOnPropertyViewModel> Viewings { get; set; }
        public int PropertyId { get; set; }
    }

    public class SellersViewingOnPropertyViewModel
    {
        [Display(Name="Time of Viewing")]
        public DateTime ViewingAt { get; set; }
    }
}