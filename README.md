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

# Project Status
Source repository created in git with two branches (master/develop). Seeded master with package sourced from https://github.com/spie-dev/internproject. Development was committed in incremental chunks, on the develop branch, generally covering individual bugs and feature requests.  Periodic merges with master when milestones were reached.

* Bug Fixes (tagged with [BUG] in repository)
  * [BUG] Profile display and fault tolerance fixes.
    * Corrected GetProfile method to iterate over the profile list and return matching id if available
    * Added throwing of an exception when desired profile id is not available
    * Added try/catch handling to profile view controller to handle bad input and return safely to home page.
  * [BUG] Fixed alignment between profiles search text box and image.

* Miscellaneous Fixes (not tied with bugs or features)
  * Successfully built project under VS2019, but had run-time error launching the web page.
    * A newer version of Microsoft.CodeDom.Providers.DotNetCompilerPlatform.dll resolved the issue.
	* There are (7) additional NuGet package updates available that could be beneficial.
  * [FIX] Cleanup some HTML validation issues
    * Added lang attribute to declare english
    * Added alt attribute to images for improved accessibility
    * Fixed duplicate ids on profile images
    * Obsolete attributes moved to CSS
      * img (border)
      * table (background-color, border, cellspacing, cellpadding)
      * td (align, valign)

* New Features (tagged with [NEW] in repository)
  * [NEW] Added partial name match to profile search box.  This addition resulted in an additional JQuery (jquery-ui) dependency.
  * [NEW] Added ability to edit profile information.
  * [NEW] Added database back end for profile information storage.  This addition resulted in an additional Entity Framework 6.2 dependency.

* Work in progress (tagged with [WIP] in repository) The develop branch may have additional items under development when the time interval expired.  Not yet ready for production, it may offer insight to the intended direction of the development.
  * --none at this time--
  
At present there should not be any additional setup requirements or dependencies other than the ones mentioned above.  There may be slight differences depending on the development environment and packages if attempting to build on something prior to VS2019.
