using Linkedin.Models.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linkedin.DbContext.Configs
{
    public class CommentConfiguration : EntityTypeConfiguration<Comment>
    {
        public CommentConfiguration()
        {
            
            //Many to one with user
            HasRequired(comment => comment.Author)
                .WithMany(user => user.Comments)
                .HasForeignKey(comment => comment.AuthorId)
                .WillCascadeOnDelete(false);

            //Many to many with user
            HasMany(comment => comment.Likes)
                .WithMany(user => user.LikedComments)
                .Map(t =>
                {
                    t.ToTable("LikedComments")
                    .MapLeftKey("CommentId")
                    .MapRightKey("UserId");
                });

            //Many to one with post
            HasRequired(comment => comment.Post)
                .WithMany(post => post.Comments)
                .HasForeignKey(comment => comment.PostId)
                .WillCascadeOnDelete(false);

            //Recursive many to many -> Replies
            HasMany(comment => comment.Replies)
                .WithMany()
                .Map(t =>
                {
                    t.ToTable("CommentReplies")
                    .MapLeftKey("CommentId")
                    .MapRightKey("ReplyId");
                });
        }
    }
}
