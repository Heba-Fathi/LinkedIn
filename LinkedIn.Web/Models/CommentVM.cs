using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkedIn.Web.Models
{
    public class CommentVM
    {
        public string Content { get; set; }
        public string PicURL { get; set; }
        public string AuthorName { get; set; }
        public DateTime Date { get; set; }
        public Guid PostId { get; set; }
        public string AuthorId { get; set; }

    }
}