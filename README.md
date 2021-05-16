## Project Overview 
The current state of the site includes user authentication, where users can upload screenshots to the screenshot page as well as an interactive forum between users. 

## Website Functionality 
![Screenshot Page](https://user-images.githubusercontent.com/56358612/118382696-dc0daa80-b5c5-11eb-8d62-158ddddfa8fc.png)
This page is capable of displaying the images the users store from the sql database as well as uses Azure Blob storage to store the images. Currently, users are able to look at their own uploaded screenshots with the "Your Screenshots" page. The goal is to also have a upvote/downvote system for the screenshots which is currently being worked on as well. 


![Enlarging Image](https://user-images.githubusercontent.com/56358612/118382721-25f69080-b5c6-11eb-922e-c3b201402183.png)
Currently, the code that I have within the project is now capable of enlarging all the images within the database. It currently allows users to do that using javascript and jQuery within the html document. Users are also able to add profile pictures to their profiles, as well as have their profile pictures display with the posts they post in the forum. 



![Forum](https://user-images.githubusercontent.com/56358612/118382818-ff852500-b5c6-11eb-801d-fc00db192d27.png)
The forum on the site allows users to create their own forums for other users to post in. The ultimate goal is to have users not create duplicate forums which should be easy to implement once I actually get to it. Each forum leads to a specific list of posts that relate to that forum. Users can also delete the forums they create after the forum has been made. 



- [x] User authentication
- [x] Images uploaded to database and stored with username
- [x] Users capable of deleting only the images they upload
- [x] Adding user profile pictures
- [x] A forum for users to interact with one another
- [x] Layout that looks appealing to the users
- [x] Adding a dropdownlist 
- [x] Forums should link to specific posts related to that topic
- [ ] Upvoting system for forum posts
- [ ] Display most popular posts
- [ ] Allow users to update a user bio 
- [ ] A page where users can rate the game from the series
- [ ] A star rating system 
