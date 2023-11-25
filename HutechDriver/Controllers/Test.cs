using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using HutechDriver.Models;
using HutechDriver.Models.EF;

namespace HutechDriver.Controllers
{
    public class TestController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        public IEnumerable<Trip> GetTrips()
        {
            return db.Trips.ToList();
        }
    }
}