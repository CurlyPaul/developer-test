﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.Viewings.Commands
{
    public class CreateViewingCommand
    {
        public string BuyerId { get; set; }

        public int PropertyId { get; set; }

        public DateTime ViewingAt { get; set; }
    }
}