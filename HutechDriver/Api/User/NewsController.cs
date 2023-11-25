using HutechDriver.Api.data.Model;
using HutechDriver.Models;
using HutechDriver.Models.EF;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HutechDriver.Api.User
{
  
    public class NewsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        //api/news
        [HttpGet]
        public IEnumerable<News> GetNews()
        {
            return db.News.ToList();
        }
        [HttpGet]
        [Route("api/news/detail/{id}")]
        public IHttpActionResult Detail(int id)
        {
            var item = db.News.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }
    }
}
