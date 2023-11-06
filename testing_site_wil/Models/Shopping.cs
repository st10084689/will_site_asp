using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace testing_site_wil.Models
{
    public class Shopping
    {       [Key]
            public int ID { get; set; }

            public string Title { get; set; }

            public string Description { get; set; }

            public Double Price { get; set; }

            [ValidateNever]
            public string Images { get; set; }
        
    }
}
