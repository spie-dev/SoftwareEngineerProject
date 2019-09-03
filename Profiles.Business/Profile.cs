using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Profiles.Business
{
    public class Profile
    {
        [Required]
        [DisplayName("First Name")]

        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        public string UserName { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Your password must have more than 6 characters.")]
        public string Password { get; set; }

        [Required]
        [DisplayName("Confirm Password")]
        [Compare("Password", ErrorMessage = "Passwords don't match, please try again.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DisplayName("SPIE Role")]
        public string SPIERole { get; set; }

        [Required]
        public string Company { get; set; }

        [Required]
        [DisplayName("Job Title")]
        public string JobTitle { get; set; }

        [Required]
        [DisplayName("Profile Picture")]
        public string PictureFileName { get; set; }

        public int ID { get; set; }
    }
}
