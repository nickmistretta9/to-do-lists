# To Do Lists
This project serves as a basic .NET Core MVC application displaying some basic endpoints for 2 different objects, `ToDoLists` and `ToDoListItems`.
There are 2 API controllers, one for each object type, and a few endpoints for each, displaying CRUD operations.

## Data
There is no DAL for this project, and instead uses in memory objects, with the Faker library to supply the data.

## Usage
Clone down the repository, install the npm packages with `npm install` and run the dev script to ensure the styles and JS files are built properly, using `npm run dev`. The project is then free to run with your IIS configuration.
