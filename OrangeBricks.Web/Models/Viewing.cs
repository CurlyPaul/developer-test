using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Models
{
    public class Viewing
    {
        [Key]
        public int Id { get; set; }

        public string BuyerId { get; set; }

        public int PropertyId { get; set; }

        public DateTime ViewingAt { get; set; }
    }
}