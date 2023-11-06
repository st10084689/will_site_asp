using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace testing_site_wil.Models
{
    public class Event
    {
        [Key]
        public int ID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        [ValidateNever]
        public string Images { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime EventTime { get; set; }



    }
}
