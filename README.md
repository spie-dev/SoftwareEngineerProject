# SoftwareEngineerProject
This is a simple test project designed for you to show off your technical skills in C# .NET MVC. The setup for this test is pretty simple. SPIE has a section of our website that displays the profiles of various SPIE and SPIE-affiliated people. This code is the initial development of that profiles section. Unfortunately, it has some bugs and missing functionality.

# Your task
Fix the bugs and add as much new functionality as you can in the given amount of time, then add it in a private github repo for us to review. *NOTE* you can use any and all web/book resources, this is a test of your programming skills as if you were on the job.

If you DO get all listed bug fixes/functionality done, feel free to add other functionality you think makes sense, or, if you find other bugs not listed here, fix them as well. Make sure to call out these additions, though, so we can be sure we look at them!

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
* Add the ability for someone to edit a profile and have it update
  * Also can move this ability to edit behind a log in, so random users can't maliciously edit someone else's profile!
* Add the ability for a profile user to log into the website


# How to submit this
1. Update your README.md file to specify what bug fixes and functionality adds you did, as well as any new instructions for set up
2. Send your SPIE contact a zip file of the solution. 