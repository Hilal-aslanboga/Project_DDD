﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_DDD.DomainLayer.Entities.Concrete;
using Project_DDD.InfrastructureLayer.Mapping.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_DDD.InfrastructureLayer.Mapping.Concrete
{
   public class SubAttributesMap:BaseMap<SubAttributes>
    {
        public override void Configure(EntityTypeBuilder<SubAttributes> builder)
        {
            builder.HasKey(x => x.Id);
            base.Configure(builder);
        }
    }
}
