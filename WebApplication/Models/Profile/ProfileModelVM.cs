using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Profiles.Business;


namespace WebApplication.Models.Profile
{
    
    public class ProfileModelVM
    {
        public ProfileCollection collection;
        public ProfileModelVM(int? ID)
        {
            collection = ProfileCollection.Instance;

            Profiles.Business.Profile userProfile = collection.GetProfile(ID);

            if (userProfile != null)
            {
                Id = userProfile.ID;
                userId = userProfile.UserId;
                FullName = userProfile.FirstName + " " + userProfile.LastName;
                SPIERole = userProfile.SPIERole;
                Company = userProfile.Company;
                JobTitle = userProfile.JobTitle;
                PictureFileName = userProfile.PictureFileName;
            }
        }

        public void SaveProfile(ProfileModelVM model)
        {
            Profiles.Business.Profile profileModel = new Profiles.Business.Profile();
            profileModel.ID = model.Id;            
            profileModel.FirstName = model.FullName.Split(' ')[0];
            profileModel.LastName  = model.FullName.Split(' ')[1];
            profileModel.SPIERole = model.SPIERole;
            profileModel.Company = model.Company;
            profileModel.JobTitle = model.JobTitle;
            collection.SaveProfile(profileModel);

        }
        public ProfileModelVM()
        {
            collection = ProfileCollection.Instance;
        }

        public int Id { get; set; }

        public string userId { get; set; }
        public string FullName { get; set; }
        public string SPIERole { get; set; }
        public string Company { get; set; }
        public string JobTitle { get; set; }
        public string PictureFileName { get; set; }

        public bool Empty
        {
            get
            {
                return (
                        string.IsNullOrWhiteSpace(FullName) &&
                        string.IsNullOrWhiteSpace(SPIERole) &&
                        string.IsNullOrWhiteSpace(Company) &&
                        string.IsNullOrWhiteSpace(JobTitle) &&
                        string.IsNullOrWhiteSpace(PictureFileName));
            }
        }

        
    }
}