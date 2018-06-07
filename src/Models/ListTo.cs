using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApi.Models
{
    public class ListTo
    {
        public long id { get; set; }
        public String title { get; set; }
        public String text { get; set; }
        public String priority { get; set; }
    }
}