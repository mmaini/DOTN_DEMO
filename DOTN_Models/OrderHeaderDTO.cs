using System.ComponentModel.DataAnnotations;

namespace DOTN_Models
{
    public class OrderHeaderDTO
    {
        public int Id { get; set; }
        [Required]
        public string UserId {get;set; }
        [Required]
        [Display(Name ="Order total")]
        public double OrderTotal { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        [Display(Name = "Shipping date")]
        public DateTime ShippingDate { get; set; }
        [Required]
        public string Status { get; set; }


        //stripe payment
        public string? SessionId { get; set; }   
        public string? PaymentIntentId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        [Display(Name = "Postal code")]
        public string PostalCode { get; set; }

        [Required]
        public string Email { get; set; }

        public string? Tracking { get; set; }
        public string? Carrier { get; set; }

    }
}
