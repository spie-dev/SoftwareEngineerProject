using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Xml;
using System.Web.Hosting;

namespace Profiles.Business
{
    public class ProfileCollection
    {
        private const string c_XmlFileName = "~/XML/ProfileList.xml";

        public List<Profile> ProfileList;

        public ProfileCollection(string filter)
        {
            InitializeProfileList();
            if (filter != null)
            {
                filter = filter.Trim().ToLower();
                if (filter.Length > 0)
                {
                    ProfileList = ProfileList.Where(x => x.FirstName.ToLower().Contains(filter) || x.LastName.ToLower().Contains(filter)).ToList<Profile>();
                }
            }
        }

        public ProfileCollection()
        {
            InitializeProfileList();
        }

        public bool Save(Profile changedProfile)
        {
            // TODO: save it somehow - hard to do with no database - maybe XML?
            bool bSuccess = FillXMLFileFromProfileList(ref ProfileList); // we need to create the XML file if it is not there
            if (bSuccess)
            {
                bSuccess = UpdateProfileNode(ref changedProfile, ref ProfileList);
            }

            return bSuccess;
        }

        private bool IsXMLFileEmpty(ref XmlDocument xDoc)
        {
            bool bIsEmpty = false;
            XmlElement root = xDoc.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("Profile");
            if (nodes.Count == 0)
            {
                bIsEmpty = true;
            }

            return bIsEmpty;
        }

        private void InitializeProfileList()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(HostingEnvironment.MapPath(c_XmlFileName));
            if (IsXMLFileEmpty(ref xDoc))
            {
                // load from initialization if we haven't populated the XML storage yet
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
                        Username = "jimbob",
                        Password = "secret"
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
                        Username = "samanthajohnson",
                        Password = "secret"
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
                        Username = "jackiezope",
                        Password = "secret"
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
                        Username = "jonathonwatkinson",
                        Password = "secret"
                    }
                };
            }
            else
            {
                // Load the ProfileList from the XML file
                ProfileList = new List<Profile>();
                FillProfileListFromXML(ref ProfileList);
            }
        }

        // find the profile in the ProfileList with the ID; return null if no match is found
        public Profile GetProfile(int ID)
        {
            Profile foundProfile = null;

            if (ProfileList.Exists(p => p.ID == ID))
            {
                foundProfile = ProfileList.Find(p => p.ID == ID);
            }
            
            return foundProfile;
        }

        public bool ValidateUserPermission(string username, string password)
        {
            bool bFound = false;

            Profile prof = ProfileList.Find(p => p.Username == username && p.Password == password);
            if (prof != null)
            {
                bFound = true;
            }

            return bFound;
        }

        private bool UpdateProfileNode(ref Profile changedProfile, ref List<Profile> updatedProfileList)
        {

            bool bSuccess = true;

            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(HostingEnvironment.MapPath(c_XmlFileName));
                XmlNode node = xDoc.SelectSingleNode("/Profiles/Profile[@ID='" + changedProfile.ID.ToString() + "']");
                node.RemoveAll();

                // we need to add the ID attribute back since we just deleted it!
                XmlAttribute attrProfileChild = xDoc.CreateAttribute("ID");
                attrProfileChild.InnerText = changedProfile.ID.ToString();
                node.Attributes.Append(attrProfileChild);

                XmlElement elem = xDoc.CreateElement("FirstName");
                elem.InnerText = changedProfile.FirstName.Trim();
                node.AppendChild(elem);
                elem = xDoc.CreateElement("LastName");
                elem.InnerText = changedProfile.LastName.Trim();
                node.AppendChild(elem);
                elem = xDoc.CreateElement("Company");
                elem.InnerText = changedProfile.Company.Trim();
                node.AppendChild(elem);
                elem = xDoc.CreateElement("SPIERole");
                elem.InnerText = changedProfile.SPIERole.Trim();
                node.AppendChild(elem);
                elem = xDoc.CreateElement("JobTitle");
                elem.InnerText = changedProfile.JobTitle.Trim();
                node.AppendChild(elem);
                elem = xDoc.CreateElement("PictureFileName");
                elem.InnerText = changedProfile.PictureFileName.Trim();
                node.AppendChild(elem);
                elem = xDoc.CreateElement("Username");
                elem.InnerText = changedProfile.Username.Trim();
                node.AppendChild(elem);
                elem = xDoc.CreateElement("Password");
                elem.InnerText = changedProfile.Password.Trim();
                node.AppendChild(elem);

                xDoc.Save(HostingEnvironment.MapPath(c_XmlFileName));
            }
            catch
            {
                bSuccess = false;
            }

            return bSuccess;
        }

        private bool FillXMLFileFromProfileList(ref List<Profile> profiles)
        {
            bool bSuccess = true;

            try
            {
                Profile newProfile = new Profile();

                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(HostingEnvironment.MapPath(c_XmlFileName));

                // make sure the XML file is empty (or it will keep growing)
                XmlElement root = xDoc.DocumentElement;
                XmlNodeList nodes = root.SelectNodes("Profile");
                if (nodes.Count == 0)
                {
                    foreach (Profile prof in profiles)
                    {
                        XmlElement elemProfileRoot = xDoc.CreateElement("Profile");

                        XmlAttribute attrProfileChild = xDoc.CreateAttribute("ID");
                        attrProfileChild.InnerText = prof.ID.ToString();
                        elemProfileRoot.Attributes.Append(attrProfileChild);

                        XmlElement elemProfileChild = xDoc.CreateElement("FirstName");
                        elemProfileChild.InnerText = prof.FirstName;
                        elemProfileRoot.AppendChild(elemProfileChild);

                        elemProfileChild = xDoc.CreateElement("LastName");
                        elemProfileChild.InnerText = prof.LastName;
                        elemProfileRoot.AppendChild(elemProfileChild);

                        elemProfileChild = xDoc.CreateElement("SPIERole");
                        elemProfileChild.InnerText = prof.SPIERole;
                        elemProfileRoot.AppendChild(elemProfileChild);

                        elemProfileChild = xDoc.CreateElement("Company");
                        elemProfileChild.InnerText = prof.Company;
                        elemProfileRoot.AppendChild(elemProfileChild);

                        elemProfileChild = xDoc.CreateElement("JobTitle");
                        elemProfileChild.InnerText = prof.JobTitle;
                        elemProfileRoot.AppendChild(elemProfileChild);

                        elemProfileChild = xDoc.CreateElement("PictureFileName");
                        elemProfileChild.InnerText = prof.PictureFileName;
                        elemProfileRoot.AppendChild(elemProfileChild);

                        elemProfileChild = xDoc.CreateElement("Username");
                        elemProfileChild.InnerText = prof.Username;
                        elemProfileRoot.AppendChild(elemProfileChild);

                        elemProfileChild = xDoc.CreateElement("Password");
                        elemProfileChild.InnerText = prof.Password;
                        elemProfileRoot.AppendChild(elemProfileChild);

                        root.AppendChild(elemProfileRoot);
                    }
                    xDoc.Save(HostingEnvironment.MapPath(c_XmlFileName));
                }
            }
            catch
            {
                bSuccess = false;
            }

            return bSuccess;
        }

        private bool FillProfileListFromXML(ref List<Profile> profiles)
        {
            bool bSuccess = true;

            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(HostingEnvironment.MapPath(c_XmlFileName));
                XmlElement root = xDoc.DocumentElement;
                XmlNodeList nodes = root.SelectNodes("Profile");
                foreach (XmlNode node in nodes)
                {
                    Profile newProfile = new Profile();
                    newProfile.ID = Convert.ToInt32(node.Attributes["ID"].Value);
                    foreach (XmlNode child in node.ChildNodes)
                    {
                        switch (child.Name)
                        {
                            case "FirstName":
                                newProfile.FirstName = child.InnerText.Trim();
                                break;
                            case "LastName":
                                newProfile.LastName = child.InnerText.Trim();
                                break;
                            case "SPIERole":
                                newProfile.SPIERole = child.InnerText.Trim();
                                break;
                            case "Company":
                                newProfile.Company = child.InnerText.Trim();
                                break;
                            case "JobTitle":
                                newProfile.JobTitle = child.InnerText.Trim();
                                break;
                            case "PictureFileName":
                                newProfile.PictureFileName = child.InnerText.Trim();
                                break;
                            case "Username":
                                newProfile.Username = child.InnerText.Trim();
                                break;
                            case "Password":
                                newProfile.Password = child.InnerText.Trim();
                                break;
                            default:
                                break;
                        }
                    }
                    profiles.Add(newProfile);
                }
            }
            catch
            {
                bSuccess = false;
            }

            return bSuccess;
        }
    }
}
