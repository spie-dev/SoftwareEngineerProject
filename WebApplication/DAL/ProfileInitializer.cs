using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication.Models.Profile;

namespace WebApplication.DAL
{
    public class ProfileInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ProfileContext>
    {
        protected override void Seed(ProfileContext context)
        {
            var profiles = new List<ProfileModel>
            {
                new ProfileModel()
                {
                    Id = 1,
                    FirstName = "Jim",
                    LastName = "Bob",
                    Company = "SPIE",
                    SPIERole = "SPIE Member",
                    JobTitle = "UX/UI Designer",
                    PictureFileName = "jimbob.jpg"
                },
                new ProfileModel()
                {
                    Id = 2,
                    FirstName = "Samantha",
                    LastName = "Johnson",
                    Company = "SPIE",
                    SPIERole = "SPIE Fellow",
                    JobTitle = "Optics & Photonics Researcher",
                    PictureFileName = "samanthajohnson.jpg"
                },
                new ProfileModel()
                {
                    Id = 3,
                    FirstName = "Jackie",
                    LastName = "Zope",
                    Company = "NASA",
                    SPIERole = "SPIE Conference Chair",
                    JobTitle = "Astrophysicist",
                    PictureFileName = "jackiezope.jpg"
                },
                new ProfileModel()
                {
                    Id = 4,
                    FirstName = "Jonathon",
                    LastName = "Watkinson",
                    Company = "Blue Origins",
                    SPIERole = "SPIE Member",
                    JobTitle = "Embedded Optical Engineer",
                    PictureFileName = "jonathonwatkinson.jpg"
                }
            };
            profiles.ForEach(p => context.Profiles.Add(p));
            context.SaveChanges();
        }
    }
}