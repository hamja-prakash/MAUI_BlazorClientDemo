using System.ComponentModel.DataAnnotations;

namespace BlazorSample.WebComponent.Models
{
    public class TBLUser
    {
        [Key]
        public int CustomerId { get; set; }
        [Required(ErrorMessage ="Enter First Name")]      
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Enter Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Enter Email")]
        [EmailAddress(ErrorMessage = "Enter valid Email")]
        public string EmailId { get; set; }
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Enter valid Phone Number")]
        public string? Phonenumber { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public DateTime? Createdon { get; set; }
        public int? Createdby { get; set; }
        public DateTime? Modifiedon { get; set; }
        public int? Modifiedby { get; set; }
        public bool? IsActive { get; set; }

        [Required(ErrorMessage ="Enter Zip Code")]
        [RegularExpression(@"\d{5}$", ErrorMessage = "Enter valid Zip Code")]
        public string? ZipCode { get; set; }
    }
}

