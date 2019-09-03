This is a simple test project designed for you to show off your technical skills in C# .NET MVC. The setup for this test is pretty simple. SPIE has a section of our website that displays the profiles of various SPIE and SPIE-affiliated people. This code is the initial development of that profiles section. Unfortunately, it has some bugs and missing functionality.

# Your task
Fix the bugs and add as much new functionality as you can in the given amount of time, then add it in a private github repo for us to review. You are NOT expected to get all of this done, it is instead a wide array of functionality so you can show your full array of skills. *NOTE* you CAN use any and all web/book resources, this is a test of your programming skills as if you were on the job, not a school quiz.

If you DO get all listed bug fixes/functionality done, feel free to add other functionality you think makes sense, or, if you find other bugs not listed here, fix them as well. Make sure to call out these additions, though, so we can be sure we look at them!

The bug fixes should be *production level* fixes. So things to think about:
1. Will this work with more/less data than is provided?
2. Does it do enough try/catches to prevent the website from blowing up if something goes weird?
3. Do you need to add comments or refactor code so it's clear for future devs to maintain?

# How to get this project
Pull down a zip of this by clicking the "Clone or download" link on the upper right of this repo, and select "Download Zip". Unzip into your "My Documents" folder, and open the WebApplication.sln with visual studio. Use ctrl+shift+b to build the project, then click the "IIS Express" at the top to run the website.

# Bug fixes
* On the home page, the search profiles text box doesn't line up with the magnifying glass. Change it so the bottom of the text box lines up with the magnifying glass image
* When clicking on a SPIE Profile Name link, it's supposed to send you to the profile information for that particular person. It is currently always displaying Jim Bob's profile. Fix it so it displays the correct profile when you click on it.
* An individual profile can be accessed by using the following URL format: /profiles/view/{ID} There are two errors that come up:
  * If you enter a non-number as the ID, it errors out (e.g. /profiles/view/asdf). Change it to simply redirect to the home page if a profile is not found
  * Depending on how you fix the SPIE Profile Name Link error, if you enter a non-existant profile ID, it may error out (e.g. /profiles/view/123). Make sure it does not

# Functionality Adds
* Add the ability to use the search bar, and have it display a list of profiles that have a partial match with either first or last name
  * *NOTE* this should NOT do the search logic in the view itself, this isn't display logic, so it shouldn't go in the display part of the website!
* Add the ability for someone to edit a profile and have it update
  * Also can move this ability to edit behind a log in, so random users can't maliciously edit someone else's profile!
* Add the ability for a profile user to log into the website


# How to submit this
1. Create a new private repo in GitHub
2. Install the Github extension for visual studio (in visual studio, click tools->"extensions and updates" and search for "Github Extension for Visual Studio")
3. Connect to GitHub and the repo with Visual studio. Use the [extension's website](https://visualstudio.github.com/) to see screenshots of how to connect
4. Update your README.md file to specify what bug fixes and functionality adds you did, as well as any new instructions for set up
5. Push your modified code to your private repo
6. Send your SPIE contact an invite to the repo

# Steve Duncan bug fixes and changes
I tried to follow the instructions exactly and keep the changes to a minimum. Although I was tempted to create a database to support the edit functionality, I decided not to require your team to setup a local database and associated objects simply to run the project. For this simple project, I just store the profiles in an XML file if edits have been made. Of course I would never do this in a deployed web application, but I needed some type of storage and I am most familiar with working with XML files in C#. The only significant change I made was to NOT open profile detail pages in a new tab since it was bugging me to have multiple tabs open, especially when there is navigation back to the main profile list page in the layout. Also, in order to login to the profile main page, use one of the user names of the profiles (which are just the first and last names concatenated) and a password of "secret" (without the quotes). "jimbob" is a good username to use as a non-admin. To login as an admin to get to /admin (the edit profile functionality), enter a username of "admin" and a password of "password" (without the quotes).

# Bug fixes
* I was unable to use CSS to get the bottoms of the textbox and button to line up, even after wrapping them in a div and experimenting with the position. I could remove the float and get them to line up inside a div, but then there would be a gap between the textbox and button that was not there before. I could probably fix this with negative margins along with trial and error, but decided to just put the 2 elements in a single cell table and align them to the bottom of the cell. If this was production I would have just removed the float and either shrunk the button down to the correct size or made a new button with the correct height.
* To get an existing profile, when the ProfileList is built, the ProfileModel constructor searches the ProfileList for a profile with a matching ID. If it finds one, it fills in the members of the ProfileModel. This isn't much different from what it was doing before.
* If a non-numeric is passed as the ID to the ProfileController, a TryParse will catch this and not even try to create a ProfileModel object. In this case the user is just passed back to Home/Index.
* If you enter a non-existent ID in the URL, the ProfileModel constructor will not find a match which will give you back ProfileModel with an IsValid property set as false. In this case I just send the user back to the main index screen.

# Functionality Adds
* The search is implemented in an overloaded ProfileCollection constructor that takes a cleaned up filter string as a parameter. I strip out invalid characters in the view so that special characters don't get passed into the constructor. The search (or filter) results are simply displayed in the list of profiles on the right side of the main profiles page (only 3 profiles maximum are shown). The list could use some paging controls if we had more data, but it would not make sense just to put paging on the search results and not on the full unfiltered list.
* Since only the edit functionality was asked for, I only added that functionality. As I stated above, I am using an XML file for persistent storage ONLY if an edit has been made. The XML file will not be written until the first edit has been made. Ideally I would have a database available to persist data, but for such a small example and with no way to add additional records, the XML file seems to work. I have never tried writing to an XML file in a web application, so I was dubious as to whether it would actually work and I'm still not sure if it would work on an actual web server. If a database was available, adding delete and create functionality would be fairly easy.
* For security, I simply added the [Authorize] annotation to the AdminController and HomeController to protect all Result methods in those classes. I keep track of whether it is the Admin who is logged in with a Session variable. If there was a Membership database available, I would probably use that to control access, although I see that Identity may have replaced Membership. I have yet to explore Identity, but that is probably a better choice than Membership and far superior to handling the AuthCookie myself (which is done in the AccountController in my project).


