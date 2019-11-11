## Simple Shopping Cart

##### Problem statement:

*You need to write a JavaScript application using any front end framework of your choice*

The application needs to display a list of products to the user.
The user has the ability to add these items to a virtual basket and have the front end update.

The products will need to be retrieved from a web API call to a C# back end. A static list of products is fine.

Once the products are added to the basket the user will have access to a 'go to basket' button to perform a check out of the products.

The checkout page will present the basket items to the user. The user can remove items from the basket here.

The checkout page will call a C# backend to calculate the total shipping cost.
$10 shipping cost for orders less of $50 dollars and less. $20 for orders more than $50.

The checkout page will have a place order button which will post all the products to a C# method and will return success to the page.
Once that is complete the page will navigate to a 'thank you' page.

The focus of the exercise is on the  C# and JavaScript code only.
The pages should be neat but the focus is not the design.

##### Solution

This application was generated using the ASP.NET Core and Angular template: 
https://docs.microsoft.com/en-us/aspnet/core/client-side/spa/angular?view=aspnetcore-3.0&tabs=visual-studio

##### Running

To run the app in developement mode:
1. set an environment variable by running command: SET ASPNETCORE_Environment=Development
2. build the core solution in visual studio
3. navigate to the core solution directory in cmd and run command: dotnet run
4. observe the cmd logs for url

To run the app in a docker container:
1. ensure docker is running and using linux containers
2. open terminal in SimpleShoppingCart\src\SimpleShoppingCart.Core
2. run command: docker build -t simple-shopping-cart-image . <em>(this may take a moment)</em>
3. verify image created successfuly run command: docker images <em>(should see an image name simple-shopping-cart-image)</em>
4. run the continer: docker run -p 8080:80 simple-shopping-cart-image
5. navigate to <http://localhost:8080>
6. trouble shooting: <https://medium.com/@ali.bahrami/deploy-an-angular-asp-net-core-webapi-on-docker-ab3546a06803>
