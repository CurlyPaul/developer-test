using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.Property.ViewModels
{
    public class BookViewingViewModel
    {
        public int PropertyId { get; set; }
        public string PropertyType { get; set; }
        public string StreetName { get; set; }

        [Display(Name = "Time of Viewing")]
        public DateTime ViewingAt { get; set; }
    }
}