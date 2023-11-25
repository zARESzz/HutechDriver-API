using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HutechDriver.Api.data.Model
{
    public class BookingViewModel
    {
        public int UserId { get; set; }

        public string StartLocation { get; set; }

        public string EndLocation { get; set; }

        public string Distance { get; set; }

        public string Time { get; set; }

        public decimal? Price { get; set; }
    }
}