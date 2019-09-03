using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Profiles.Business;

namespace WebApplication.Models.Profile
{
    public class IndexProfileVM
    {
        public ProfileCollection collection;
        public IEnumerable<Profiles.Business.Profile> profile;
    }
}