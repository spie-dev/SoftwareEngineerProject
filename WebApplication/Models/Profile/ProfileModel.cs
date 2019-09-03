using Profiles.Business;

namespace WebApplication.Models.Profile
{
    public class ProfileModel
    {
        //Fill ProfileModel
        public ProfileModel(int ID)
        {
            ProfileCollection collection = new ProfileCollection();
            Profiles.Business.Profile userProfile = collection.GetProfile(ID);

            //If invalid Profile
            if (userProfile == null)
                return;

            this.ID = userProfile.ID.ToString();
            FullName = userProfile.FirstName + " " + userProfile.LastName;
            SPIERole = userProfile.SPIERole;
            Company = userProfile.Company;
            JobTitle = userProfile.JobTitle;
            PictureFileName = userProfile.PictureFileName;
            Username = userProfile.UserName;
        }

        public string ID;
        public string Username;
        public string FullName;
        public string SPIERole;
        public string Company;
        public string JobTitle;
        public string PictureFileName;
    }
}