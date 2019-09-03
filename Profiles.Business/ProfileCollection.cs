using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profiles.Business
{
    public sealed class ProfileCollection
    {

        public List<Profile> ProfileList;

        private ProfileCollection()
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
                    PictureFileName = "jimbob.jpg",
                    UserId="jbob",
                    Password="jbob"
                },
                new Profile()
                {
                    ID = 2,
                    FirstName = "Samantha",
                    LastName = "Johnson",
                    Company = "SPIE",
                    SPIERole = "SPIE Fellow",
                    JobTitle = "Optics & Photonics Researcher",
                    PictureFileName = "samanthajohnson.jpg",
                    UserId="sjohn",
                    Password="sjohn"
                },
                new Profile()
                {
                    ID = 3,
                    FirstName = "Jackie",
                    LastName = "Zope",
                    Company = "NASA",
                    SPIERole = "SPIE Conference Chair",
                    JobTitle = "Astrophysicist",
                    PictureFileName = "jackiezope.jpg",
                    UserId="jzope",
                    Password="jzope"
                },
                 new Profile()
                {
                    ID = 4,
                    FirstName = "Jonathon",
                    LastName = "Watkinson",
                    Company = "Blue Origins",
                    SPIERole = "SPIE Member",
                    JobTitle = "Embedded Optical Engineer",
                    PictureFileName = "jonathonwatkinson.jpg",
                    UserId="jwatkin",
                    Password="jwatkin"
                }
            };


        }

        private static ProfileCollection instance = null;
        public static ProfileCollection Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new ProfileCollection();
                }
                return instance;
            }            
           
        }


        public void SaveProfile(Profile model)
        {
            Profile profile = ProfileList.Where(x => x.ID == model.ID).FirstOrDefault();
            profile.FirstName = model.FirstName;
            profile.LastName = model.LastName;

            profile.SPIERole = model.SPIERole;
            profile.Company = model.Company;
            profile.JobTitle = model.JobTitle;

        }
        public Profile GetProfile(int? ID)
        {
            return ProfileList.Where(x => x.ID == ID).FirstOrDefault();
        }

        public IEnumerable<Profile> GetProfileByName()
        {
            return ProfileList;
        }


    }
}
