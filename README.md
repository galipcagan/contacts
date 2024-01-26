# Contacts CRUD APP
I developed this application with the mindset of domain driven design and SOLID principles. Contacts.Infrastructure is my database layer. Web.Shared is the domain where most of the logic exists. Web.Client is where I used Blazor. Web.Server is my project that handles the API's.

Web.Server should be set as start up project to run the application.

Improvements:

- Validations within ContactService.cs
- Utilizing appsetting.json for URL parameters 
- Adding a unit test project
- Changing UI