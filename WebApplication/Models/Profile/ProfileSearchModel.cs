using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.DAL;

namespace WebApplication.Models.Profile
{
    public class ProfileSearchModel
    {
        public ProfileSearchModel(ProfileModel userProfile)
        {
            FullName = userProfile.FirstName + " " + userProfile.LastName;
            ID = userProfile.Id;
        }

        public static List<ProfileSearchModel> Search(string prefix)
        {
            List<ProfileSearchModel> list = new List<ProfileSearchModel>();

            if (prefix == null || prefix.Length < 1)
                return list;

            prefix = prefix.ToLower().Trim();
            using (var db = new ProfileContext())
            {
                var results = db.Profiles.Where<ProfileModel>(p =>
                    (prefix.Length <= p.FirstName.Length && p.FirstName.ToLower().StartsWith(prefix)) ||
                    (prefix.Length <= p.LastName.Length && p.LastName.ToLower().StartsWith(prefix)) ||
                    (prefix.Length > p.FirstName.Length && prefix.StartsWith(p.FirstName.ToLower()) &&
                     p.LastName.ToLower().StartsWith(prefix.Substring(p.FirstName.Length + 1)))
                );
                foreach (var p in results)
                    list.Add(new ProfileSearchModel(p));
            }
            return list;
        }

        public string FullName;
        public int ID;
    }
}