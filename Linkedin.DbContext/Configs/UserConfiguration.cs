using Linkedin.Models;
using Linkedin.Models.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linkedin.DbContext.Configs
{
    public class UserConfiguration: EntityTypeConfiguration<ApplicationUser>
    {
        public UserConfiguration()
        {
            //Recursive many to many -> Connections
            HasMany(user => user.Connections)
                .WithMany()
                .Map(t =>
                {
                    t.ToTable("UserConnections")
                    .MapLeftKey("UserId")
                    .MapRightKey("ConnectionId");
                });

            //Recursive many to many -> Requests
            HasMany(user => user.Requests)
                .WithMany()
                .Map(t =>
                {
                    t.ToTable("UserRequests")
                    .MapLeftKey("UserId")
                    .MapRightKey("RequestId");
                });
        }
    }
}
