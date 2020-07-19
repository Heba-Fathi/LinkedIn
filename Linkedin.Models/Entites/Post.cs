using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linkedin.Models.Entites
{
    [Table("Post")]
    public class Post
    {
        public Post()
        {
            Id = Guid.NewGuid();
            Comments = new HashSet<Comment>();
            Likes = new HashSet<ApplicationUser>();
            PostsSharedMe = new HashSet<Post>();
        }
        [Key]
        public Guid Id { get; set; }
        public string Status { get; set; }
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }
        public string AuthorId { get; set; }
        public virtual ApplicationUser Author { get; set; }
        public virtual ICollection<ApplicationUser> Likes { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public Guid? SharedPostId { get; set; }
        public virtual Post SharedPost { get; set; }
        public virtual ICollection<Post> PostsSharedMe { get; set; }
        public DateTime Date { get; set; }

    }
}
