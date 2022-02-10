using DocumentLabel.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentLabel.Domain
{
    public class DocumentRequestFile: Entity<int>
    {
        public int DocumentRequestId { get; set; }
        public string FileName { get; set; }
    }
}
