﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkedIn.Web.Models
{
    public class CommentViewModel
    {
        public string Content { get; set; }
        public Guid PostId { get; set; }
    }
}