
using DocumentLabel.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentLabel.Infrastructure.ModelBuilderExtensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
          
            modelBuilder.Entity<Lookup>().HasData(
                new Lookup
                {
                    Id = 1,
                    Type = LookupTypeEnum.Tag,
                  
                },
                new Lookup
                {
                    Id = 2,
                    Type = LookupTypeEnum.Tag,
                  
                },
                new Lookup
                {
                    Id = 3,
                    Type = LookupTypeEnum.DocumentRequestType,
                  
                },
                new Lookup
                {
                    Id = 4,
                    Type = LookupTypeEnum.DocumentRequestType,
                 
                }
            );

            modelBuilder.Entity<LookupLocale>().HasData(
               new LookupLocale
               {
                   Id = 1,
                   LookupId = 1,
                   Language = LanguageEnum.English,
                   Text = "Public"
               },
               new LookupLocale
               {
                   Id = 2,
                   LookupId = 2,
                   Language = LanguageEnum.English,
                   Text = "Confidential"
               },
               new LookupLocale
               {
                   Id = 3,
                   LookupId = 3,
                   Language = LanguageEnum.English,
                   Text = "IAM"
               },
               new LookupLocale
               {
                   Id = 4,
                   LookupId = 4,
                   Language = LanguageEnum.English,
                   Text = "POL"
               }
           );
        }
    }
}
