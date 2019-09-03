using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication.Models.Profile;

namespace WebApplication.DAL
{
    public class ProfileContext : DbContext
    {
        public ProfileContext() : base("ProfileContext")
        { }

        public DbSet<ProfileModel> Profiles { get; set; }
    }
}