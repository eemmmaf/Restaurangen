using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Restaurangen.Models
{
    public class Booking
    {
        //Bokningsnummer/ID
        [Display(Name = "Bokningsnummer")]
        public int Id { get; set; }

        //Förnamn
        [Display(Name = "Förnamn")]
        [StringLength(60, MinimumLength = 1)]
        [Required]
        public string? Fname { get; set; }

        //Efternamn
        [Display(Name = "Efternamn")]
        [StringLength(60, MinimumLength = 1)]
        [Required]
        public string? Lname { get; set; }


        //Mailadress till kund
        [Display(Name = "Mailadress")]
        [StringLength(100, MinimumLength = 1)]
        [Required]
        public string? Email { get; set; }

        //Telefonnr till kund
        [Display(Name = "Telefon")]
        [Required]
        public string? Phone { get; set; }


        //Önskemål
        [Display(Name = "Önskemål")]
        public string? Other { get; set; }


        //Datum för bokning
        [Display(Name = "Datum")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }


        //Namn
        [Display(Name = "Tid (00:00)")]
        // Format som godkänns är 00:00
        [RegularExpression("^(0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$")]
        [Required]
        public string? Time { get; set; }


        //Antal personer
        [Display(Name = "Antal personer")]
        public int Persons { get; set; }




    }
}
