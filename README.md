# SecureAPI
A Secure REST APi created in .Net Core using JWT Authentication and Entity Framework Code first approach.
 JWT Authentication is used for securing API requests. Each token generated by API for logged in user	will last for 20 minutes, post which if any request is made will be considered Unauthorzed (401).
	This value can be changed from App.Settings.json file under key- DurationInMinutes
