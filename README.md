# UserInyerfaceTestsProject
"User Inyerface" is a website made with the intention of creating the worst user interface possible. In this project I wrote automated tests to test different features, navigating through that horrible website UI. I used NUnit, Selenium webdriver, and Aquality Framework.

Structure:
-----------------
Page object model was followed, and 4 tests have been written testing filling in the page's cards, hiding the help form, accepting the cookies, as well as verifying that the timer in the website starts from 0.

All required test data, as well as any configurations are stored in the Resources folder in json format (later deserialized for use in the test).

The Utilities folder contains all Util classes that work with different things, while the Forms folder contains all methods for each Page/Form in the website.
