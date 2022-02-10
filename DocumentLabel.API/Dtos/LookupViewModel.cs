using DocumentLabel.Domain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DocumentLabel.API.Dtos
{
    public class LookupViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
}
