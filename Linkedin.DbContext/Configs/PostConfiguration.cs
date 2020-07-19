using Linkedin.Models.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linkedin.DbContext.Configs
{
    public class PostConfiguration : EntityTypeConfiguration<Post>
    {
        public PostConfiguration()
        {
            //Many to one with user
            HasRequired(post => post.Author)
                .WithMany(user => user.Posts)
                .HasForeignKey(post => post.AuthorId)
                .WillCascadeOnDelete(false);

            //Many to many with user
            HasMany(post => post.Likes)
                .WithMany(user => user.LikedPosts)
                .Map(t =>
                {
                    t.ToTable("LikedPosts")
                    .MapLeftKey("PostId")
                    .MapRightKey("UserId");
                });
            //1 to many with comment: In CommentConfiguration class

            //Unary 1 to many -> share post
            HasOptional(post => post.SharedPost)
                .WithMany(post => post.PostsSharedMe)
                .HasForeignKey(post => post.SharedPostId)
                .WillCascadeOnDelete(false); 
        }
    }
}
