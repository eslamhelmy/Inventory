using DocumentLabel.Domain.Base;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentLabel.Domain.Shared
{
    public class Lookup: Entity<int>
    {
        public LookupTypeEnum Type { get; init; }
        public ICollection<LookupLocale> Locales { get; set; }
    }

    public class LookupLocale : Entity<int>
    {
        public int LookupId { get; set; }
        public virtual Lookup Lookup { get; set; }
        public LanguageEnum Language { get; init; }
        public string Text { get; set; }
    }
}
