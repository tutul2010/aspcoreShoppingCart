using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BethanyPieShop.Models
{
    public class Order
    {
        [BindNever] //that means , this Properties shoild not be the part of model binding 
        public int OrderId { get; set; } //pk

        public List<OrderDetail> OrderLines { get; set; }

       
        [Display(Name = "First name")]
        [StringLength(50)]
        [Required(ErrorMessage = "Please enter your first name")]
        public string FirstName { get; set; }

      
        [Display(Name = "Last name")]
        [StringLength(50)]
        [Required(ErrorMessage = "Please enter your last name")]
        public string LastName { get; set; }

       
        [StringLength(100)]
        [Display(Name = "Address Line 1")]
        [Required(ErrorMessage = "Please enter your address")]
        public string AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        public string AddressLine2 { get; set; }

     
        [Display(Name = "Zip code")]
        [StringLength(10, MinimumLength = 4)]
        [Required(ErrorMessage = "Please enter your zip code")]
        public string ZipCode { get; set; }
      
        [StringLength(50)]
        [Required(ErrorMessage = "Please enter your city")]
        public string City { get; set; }
        [StringLength(10)]
        public string State { get; set; }
       
        [StringLength(50)]
        [Required(ErrorMessage = "Please enter your country")]
        public string Country { get; set; }

        [StringLength(10)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone number")]
        //[Required(ErrorMessage = "Please enter your phone number")]
        [RegularExpression(@"([0-9]{10})",
            ErrorMessage = "The phone number is not entered in a correct format")] //regex for email validation
        public string PhoneNumber { get; set; }
        
        [Required]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
            ErrorMessage = "The email address is not entered in a correct format")] //regex for email validation
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public decimal OrderTotal { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderPlaced { get; set; }
    }
}
