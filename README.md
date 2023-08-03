# Operation Distribution App Web API

## About the Project

The project involves executing operational distribution functions for workers in a multi-layered architecture developed using .NET Core WebAPI and Angular.

## Technologies Used

- **Backend**: .NET Core 7.0
- **Frontend**: Angular 15.2
- **Database**: SQL Server 2019

## Setup and Execution

### Backend

Navigate to the backend directory:

```bash
cd /path/to/your/backend
```

Restore the necessary packages:

```bash
dotnet restore
```

For database migrations:

```bash
dotnet ef database update
```

Run the application:

```bash
dotnet run
```

### Frontend

Navigate to the frontend directory:

```bash
cd /path/to/your/frontend
```

Install the required node modules:

```bash
npm install
```

Start the Angular application:

```bash
ng serve
```

You can now view the application in your browser at **http://localhost:4200**.

### Contributing

If you would like to contribute:

- Fork the repository.
- Create your feature branch (git checkout -b my-new-feature).
- Commit your changes (git commit -am 'Add some feature').
- Push your branch (git push origin my-new-feature).
- Create a new Pull Request.

### License

This project is licensed under the MIT license. For more information, refer to the **LICENSE** file.
