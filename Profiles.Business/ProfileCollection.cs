using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Profiles.Business;

namespace Profiles.Business
{
    public class ProfileCollection
    {

        public List<Profile> ProfileList;

        public ProfileCollection()
        {
            ProfileList = new List<Profile>()
            {
                new Profile()
                {
                    ID = 1,
                    FirstName = "Jim",
                    LastName = "Bob",
                    Company = "SPIE",
                    SPIERole = "SPIE Member",
                    JobTitle = "UX/UI Designer",
                    PictureFileName = "jimbob.jpg"
                },
                new Profile()
                {
                    ID = 2,
                    FirstName = "Samantha",
                    LastName = "Johnson",
                    Company = "SPIE",
                    SPIERole = "SPIE Fellow",
                    JobTitle = "Optics & Photonics Researcher",
                    PictureFileName = "samanthajohnson.jpg"
                },
                new Profile()
                {
                    ID = 3,
                    FirstName = "Jackie",
                    LastName = "Zope",
                    Company = "NASA",
                    SPIERole = "SPIE Conference Chair",
                    JobTitle = "Astrophysicist",
                    PictureFileName = "jackiezope.jpg"
                },
                 new Profile()
                {
                    ID = 4,
                    FirstName = "Jonathon",
                    LastName = "Watkinson",
                    Company = "Blue Origins",
                    SPIERole = "SPIE Member",
                    JobTitle = "Embedded Optical Engineer",
                    PictureFileName = "jonathonwatkinson.jpg"
                }
            };
        }

        public List<Business.Profile> Search(string searchString)
        {
            var result = from Profile in this.ProfileList
                         where Profile.FirstName.Contains(searchString) || Profile.LastName.Contains(searchString)
                         select Profile;

            return result.ToList<Business.Profile>();
        }

        public Profile GetProfile(int ID)
        {
            return ProfileList.Find(Profile=>Profile.ID==ID);
        }

    }
}
