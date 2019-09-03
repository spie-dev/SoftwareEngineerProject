using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Profiles.Business
{
    public class Profile
    {
        [Required(ErrorMessage = "Please enter a first name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter a last name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter a SPIE role")]
        [Display(Name = "SPIE Role")]
        public string SPIERole { get; set; }
        [Required(ErrorMessage = "Please enter a company")]
        public string Company { get; set; }
        [Required(ErrorMessage = "Please enter a job title")]
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }
        [Display(Name = "Picture File Name")]
        public string PictureFileName { get; set; }        
        public int ID { get; set; }
        [Required(ErrorMessage = "Please enter a user name")]
        [Display(Name = "User Name")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please enter a password")]
        public string Password { get; set; }
    }
}
