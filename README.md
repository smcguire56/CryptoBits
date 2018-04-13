# CryptoCoins
# G00330886   Sean McGuire    Mobile Application Development 

This is a UWP app built for displaying the latest and most popular Crypto coins on the market!

## Question
The UWP application should be well designed with a clear purpose in mind.  
Answer the question: 
“Why will the user open this app for a second time?”

As part of the design process. What makes your app better than the others available offering the same function?

## My Thought process
So I wanted to develop an app which could display all the new crypto coins on the market and to do so I needed an API, after some research I found the API from cryptocompare.com and started seeing what results I got back. I wanted the app to notify the users about various different coins and also a feedback section so I could later improve on the app.

## Explanation for how it works

So initially when the user enters the main page of my app they are greeted with a page where they have different options:

Get Coins:
This first button will load the data from cryptocompare's API which loads the data as a JSON object. Using the CoinProxy.cs file to asynchronously load the data, the RootObject file will become full of data and will be later used for various different requests. These requests are then loaded by displaying them as a list view onto the main page, however it is not as detailed here, later we can display the data but with much more information.

Clear Coins:
This is a simple button which just clears whatever data is being displayed on to the list. While clearing the list object, it also clears the items in the child object in the XAML file.

Details Page:
Loads a completely different page where we load the data with much more information for example the upcoming coins on the market, the finished coins and the released.
**How to Set Up:**
1. Clone or download this repo
2. Open git bash or any command prompt window
3. Locate the CryptoBits sln file
4. As long as you have the correct visual studio 2015 version, the app and all the files should load up in visual studio.
5. Click the run button at the top and wait for the app to build and deploy.
6. Once you've followed the previous steps correctly the app should load up.

**Running the app from Visual Studio 2015**, locate the sln file:
```
C:\Users\[USERNAME]\Desktop\CryptoBits\CryptoBits.sln
```

