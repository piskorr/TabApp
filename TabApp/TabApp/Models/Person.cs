using System;
using System.ComponentModel.DataAnnotations;

namespace TabApp.Models
{
    public class Person
    {
        public int ID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [StringLength(30, MinimumLength = 3)]
        [Required]
        public String Name { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [StringLength(30, MinimumLength = 3)]
        [Required]
        public String Surname { get; set; }

        [StringLength(60)]
        [Required]
        public String Address { get; set; }

        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }

        [Display(Name = "Phone Number")]
        [RegularExpression(@"^[0-9]*$")]
        [StringLength(9, MinimumLength = 9)]
        [Required]
        public String PhoneNumber {get; set; }

        public virtual Worker Worker { get; set; }
    }

}