# SoftwareEngineerProject
This is a simple test project designed for you to show off your technical skills in C# .NET MVC. The setup for this test is pretty simple. SPIE has a section of our website that displays the profiles of various SPIE and SPIE-affiliated people. This code is the initial development of that profiles section. Unfortunately, it has some bugs and missing functionality.

# Bug fixes
* :white_check_mark: On the home page, the search profiles text box doesn't line up with the magnifying glass. Change it so the bottom of the text box lines up with the magnifying glass image
* :white_check_mark: When clicking on a SPIE Profile Name link, it's supposed to send you to the profile information for that particular person. It is currently always displaying Jim Bob's profile. Fix it so it displays the correct profile when you click on it.
* :white_check_mark: An individual profile can be accessed by using the following URL format: /profiles/view/{ID} There are two errors that come up:
  * :white_check_mark: If you enter a non-number as the ID, it errors out (e.g. /profiles/view/asdf). Change it to simply redirect to the home page if a profile is not found
  * :white_check_mark: Depending on how you fix the SPIE Profile Name Link error, if you enter a non-existant profile ID, it may error out (e.g. /profiles/view/123). Make sure it does not

# Functionality Adds
* :white_check_mark: Add the ability to use the search bar, and have it display a list of profiles that have a partial match with either first or last name
  * Currently, the search is case sensitive, searching "bo" would not find Bob.
