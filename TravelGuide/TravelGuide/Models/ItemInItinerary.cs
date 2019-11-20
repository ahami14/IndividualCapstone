using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TravelGuide.Models
{
    public class ItemInItinerary
    {
        [Key]

        public int ItemId { get; set;  }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0: yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date")]
        public DateTime DateOfEvent { get; set; }


        [Required]
        [Display(Name = "Location")]
        public string LocationOfEvent { get; set; }


        [Required]
        [Display(Name = "Event")]
        public string EventName { get; set; }


        [Required]
        [Display(Name = "Details")]
        public string DetailsOfEvent { get; set; }


        [ForeignKey("Itinerary")]
        public int? ItineraryId { get; set; }
        public Itinerary Itinerary { get; set; }

    }
}