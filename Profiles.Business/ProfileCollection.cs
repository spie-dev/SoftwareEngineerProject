using System.Collections.Generic;
using System.Linq;

namespace Profiles.Business
{
    public class ProfileCollection
    {

        public static List<Profile> ProfileListInstance;
        public List<Profile> ProfileList;

        public ProfileCollection()
        {
            if (ProfileListInstance != null)
            {
                ProfileList = ProfileListInstance;
                return;
            }

            ProfileListInstance = new List<Profile>()
            {
                new Profile()
                {
                    ID = 1,
                    FirstName = "Jim",
                    LastName = "Bob",
                    UserName = "j.bob",
                    Password = "password",
                    ConfirmPassword = "password",
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
                    UserName = "s.johnson",
                    Password = "password2",
                    ConfirmPassword = "password2",
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
                    UserName = "j.zope",
                    Password = "password3",
                    ConfirmPassword = "password3",
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
                    UserName = "j.watkinson",
                    Password = "password4",
                    ConfirmPassword = "password4",
                    Company = "Blue Origins",
                    SPIERole = "SPIE Member",
                    JobTitle = "Embedded Optical Engineer",
                    PictureFileName = "jonathonwatkinson.jpg"
                }
            };

            ProfileList = ProfileListInstance;
        }

        /// <summary>
        /// Get a single profile from an ID
        /// </summary>
        /// <param name="ID">User's ID</param>
        /// <returns>The profile matching the ID</returns>
        public Profile GetProfile(int ID)
        {
            return ProfileList.Find(e => e.ID == ID);
        }

        //public Profile GetProfile(string search)
        //{
        //    return ProfileList.Find(e => e.FirstName == search || e.LastName == search);
        //}

        /// <summary>
        /// Get multiple profiles partially matching the search term
        /// </summary>
        /// <param name="search">Search query</param>
        /// <returns>A list of profiles</returns>
        public List<Profile> GetProfiles(string search)
        {
            if (search != null && search.Length > 0)
            {
                search = search.ToLower();
                return ProfileList.FindAll(e => e.FirstName.ToLower().Contains(search) || e.LastName.ToLower().Contains(search));
            }
            return new List<Profile>();
        }

        /// <summary>
        /// Verifies the login of a user
        /// </summary>
        /// <param name="user">The user's username</param>
        /// <param name="password">The user's password</param>
        /// <returns>The profile of the matching user</returns>
        public Profile Login(string user, string password)
        {
            var result = ProfileList.Find(a => a.UserName.Equals(user) && a.Password.Equals(password));

            if (result != null)
            {
                return result;
            }

            return null;
        }

        /// <summary>
        /// Edits an existing user
        /// </summary>
        /// <param name="profile">The updated profile</param>
        /// <returns>True is successful</returns>
        public bool EditUser(Profile profile)
        {
            var result = ProfileList.FindIndex(a => a.ID == profile.ID);

            if (result >= 0)
            {
                ProfileList[result] = profile;
                ProfileListInstance = ProfileList;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Adds a new user
        /// </summary>
        /// <param name="profile">The profile to be added</param>
        /// <returns>0: ID, 1: Username</returns>
        public string[] AddUser(Profile profile)
        {
            profile.ID = ProfileList.Max(x => x.ID) + 1;
            profile.UserName = profile.FirstName.Substring(0, 1).ToLower() + "." + profile.LastName.ToLower();
            ProfileList.Add(profile);
            ProfileListInstance = ProfileList;
            return new string[] { profile.ID.ToString(), profile.UserName };
        }
    }
}
