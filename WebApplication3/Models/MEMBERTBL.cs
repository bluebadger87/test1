﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class MEMBERTBL
    {
        [Key]
        public string MEMBERID { get; set; }
        public string MEMBERNAME { get; set; }
        public string MEMBERADDRESS { get; set; }
    }
}