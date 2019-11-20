using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TravelGuide.Models
{
    public class Itinerary
    {
        [Key]

        public int ItineraryId { get; set; }

        [Display(Name = "Itinerary Name")]
        public string ItineraryName { get; set; }


        [ForeignKey("Customer")]
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}