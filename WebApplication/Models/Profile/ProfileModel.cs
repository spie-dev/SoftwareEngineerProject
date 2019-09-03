using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models.Profile
{
    public class ProfileModel
    {
        public ProfileModel() {}

        // TODO: Adjust to reasonable values
        public const int MaxLengthFirstName = 40;
        public const int MaxLengthLastName = 40;
        public const int MaxLengthSPIERole = 80;
        public const int MaxLengthCompany = 80;
        public const int MaxLengthJobTitle = 80;
        public const int MaxLengthPictureFileName = 255;

        //
        // data available for external/user modification
        [Required]
        [Display(Name = "First Name")]
        [StringLength(MaxLengthFirstName)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(MaxLengthLastName)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "SPIE Role")]
        [StringLength(MaxLengthSPIERole)]
        public string SPIERole { get; set; }

        [Required]
        [StringLength(MaxLengthCompany)]
        public string Company { get; set; }

        [Required]
        [Display(Name = "Job Title")]
        [StringLength(MaxLengthJobTitle)]
        public string JobTitle { get; set; }

        //
        // data maintained internally/server side
        public int Id { get; set; }
        public string PictureFileName { get; set; }

        //
        // convenience properties
        public string FullName { get { return (LastName.Length > 0) ? FirstName + " " + LastName : FirstName; } }
    }
}