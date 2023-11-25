using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HutechDriver.Api.data.Model
{
    public class NewsAPI
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }  
    }
}