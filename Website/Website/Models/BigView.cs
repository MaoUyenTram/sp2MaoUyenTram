using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Models
{
    public class BigView
    {
        public Answers Answers{get; set;}
        public Questions Questions { get; set; }

        public BigView()
        {
        }
    }
}