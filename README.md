### This is a simple .Net Blazor web app.
It requires a running [server](https://github.com/reczkok/MedicalClinicAppServer/tree/main?tab=readme-ov-file) to operate. 
It fetches data via a REST server from a MongoDB Atlas and allows the user to:
- list the data
- add new records
- delete and edit existing records
- sort listed records
- search by a chosen field (or multiple fields)

### The simplest way to run the app is using the dotnet cli:

1. Run the [server](https://github.com/reczkok/MedicalClinicAppServer/tree/main?tab=readme-ov-file).
2. <img width="367" alt="image" src="https://github.com/reczkok/MedicalClinicWebApp/assets/66403540/6f75fc41-d6af-4287-abf4-8dd0fc927060"> You will see the port the server is bound to.
3. Now run this app with the server port as a parameter (in case it is not provided - it defaults to 5160).
```
dotnet run <port_nr>
```
4. You are good to go :D Access the app using the correct port on localhost.

### App preview

<img width="1664" alt="image" src="https://github.com/reczkok/MedicalClinicWebApp/assets/66403540/44512ec8-605d-4fa0-abc8-268a66f544e4">
