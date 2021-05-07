You might be wondering "I didn't see you use this anywhere".

Well this is just a demonstration to show that this type of package is really necessary.

In this demo, it's not really important because we're using API key, for the CatsClient, not some kind of JWT Token or similar.
Imaging if we need to use JWT token, we will need an Authorize package which will use this package as a SecureStorage to store the Jwt.
Then we will need to build the HttpClient base on the JWT we have just generated. Then the CatClients will need to reference this package.

But for the scope of the demo, this package is not really being used.