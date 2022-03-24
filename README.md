# SoftwareEngineerProject
This is a simple test project designed for you to show off your technical skills in C# .NET MVC. The setup for this test is pretty simple. SPIE has a section of our website that displays the profiles of various SPIE and SPIE-affiliated people. This code is the initial development of that profiles section. Unfortunately, it has some bugs and missing functionality.

# Your task
Fix the bugs and add as much new functionality as you can in the given amount of time, but don't feel the need to spend endless hours on this.  Limit yourself to 10 hours maximum.  *NOTE* you can use any and all web/book resources, this is a test of your programming skills as if you were on the job.

If you DO get all listed bug fixes/functionality done feel free to add other functionality you think makes sense or, if you find other bugs not listed here, fix them as well. Unit tests are always a plus! Make sure to call out these additions so we can be sure we look at them.

# Bug fixes
* On the home page, the search profiles text box doesn't line up with the magnifying glass. Change it so the bottom of the text box lines up with the magnifying glass image
* When clicking on a SPIE Profile Name link, it's supposed to send you to the profile information for that particular person. It is currently always displaying Jim Bob's profile. Fix it so it displays the correct profile when you click on it.
* An individual profile can be accessed by using the following URL format: /profiles/view/{ID} There are two errors that come up:
  * If you enter a non-number as the ID, it errors out (e.g. /profiles/view/asdf). Change it to simply redirect to the home page if a profile is not found
  * Depending on how you fix the SPIE Profile Name Link error, if you enter a non-existent profile ID, it may error out (e.g. /profiles/view/123). Make sure it does not!

# Functionality Adds
* Add the ability to use the search bar, and have it display a list of profiles that have a partial match with either first or last name
* Add the ability for someone to edit a profile and persist these changes
  * Also: Move the ability to edit behind a log-in so random users can't maliciously edit someone else's profile!
* Add the ability for a profile user to log into the website


# How to access and submit this project

1. Initialize a new local .git repository (git init .)
2. Inside your new repo, run 'git pull [URL of SPIE project here]'. You can access this pull link by clicking the green 'clone/download' button in the upper right corner of the Code tab on Github. You should now have all the starter files that you need.
3. Open the WebApplication.sln with Visual Studio. Use Ctrl+Shift+b to build the project, then click the "IIS Express" toolbar button at the top to run the website.
4. Go about your bug fixes / enhancements (preferably committing often throughout - no need to git-push anything).
5. Update your README.md file to specify what bug fixes and functionality adds you did, as well as any new instructions for set-up.
6. When you're finished, create a git bundle with the command 'git bundle create your_name.bundle master' and send the generated bundle file to your SPIE contact.

In order to verify your git bundle, you can un-bundle the repo by cloning the bundle file (git clone your_name.bundle).  Then change into the new directory that was generated, and run 'git pull origin master'.  At this point, the directory should look exactly as you left it before you bundled!
