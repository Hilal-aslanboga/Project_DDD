using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_DDD.DomainLayer.Entities.Concrete;
using Project_DDD.InfrastructureLayer.Mapping.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_DDD.InfrastructureLayer.Mapping.Concrete
{
    public class AppUserMap:BaseMap<AppUsers>
    {
        public override void Configure(EntityTypeBuilder<AppUsers> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserName).IsRequired(true);
            builder.Property(x => x.NormalizedUserName).IsRequired(false);
            builder.Property(x => x.FullName).IsRequired(false);
            builder.Property(x => x.CompanyName).IsRequired(false);
            builder.Property(x => x.ImagePath).IsRequired(false);
            base.Configure(builder);
        }
    }
}
