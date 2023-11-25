using HutechDriver.Api.data.Model;
using HutechDriver.Models;
using HutechDriver.Models.EF;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;

namespace HutechDriver.Api.Driver
{
    [RoutePrefix("api/trip")]
    public class TripController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        [HttpPost("Booking")]
        public async Task<HttpResponseMessage> Booking([FromBody] Trip trip)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            db.Trips.Add(trip);
            await db.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, "Đặt xe thành công");
        }
    }
}
