# Claranet Challenge Newsletter Registration Management

## Description

This project is a web application developed in Angular on the frontend and .NET Core on the backend, which allows the management of newsletter registration.

## Features

- Registration of new users to receive the newsletter.

## System Requirements

- Node.js
- Angular CLI
- .NET Core SDK

## Environment Configuration

1. Clone this repository on your local machine:

   ```
   git clone https://github.com/jcesarauj/ClaranetChallenge.git
   ```

2. Open a terminal in the root folder of the `ClaranetChallenge` project.

3. Navigate to the `frontend` folder and run the following command to install the dependencies:

   ```
   npm install
   ```

4. Navigate to the `backend` folder and run the following command to restore the .NET Core dependencies:

   ```
   dotnet restore
   ```

## Creating the database

1. Open a terminal in the `ClaranetChallenge\backend\docker` folder and run the following command to start the database in a docker container:

```
   docker-compose up -d
```

## Running the Application

1. Open a terminal in the `ClaranetChallenge/frontend` folder and run the following command to start the Angular development server:

   ```
   ng serve
   ```

2. Open another terminal in the `ClaranetChallenge/backend` folder and run the following command to start the .NET Core development server:

   ```
   dotnet run
   ```

3. Access the application in your browser via the following address:

   ```
   http://localhost:4200
   ```

## Contribution

If you wish to contribute to this project, please follow the steps below:

1. Make a fork of this repository.

2. Create a new branch with your feature:

   ```
   git checkout -b my-new-feature
   ```

3. Make the necessary changes to the code.

4. Make sure that the project is working properly.

5. Commit your changes:

   ```
   git commit -m 'Implementing my new feature'
   ```

6. Make a push to the branch:

   ```
   git push origin my-new-feature
   ```

7. Send a pull request to this repository.

## License

This project is licensed under the [MIT License](LICENSE).
