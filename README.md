# TVShowChallenge

To run the project, add a migration using the "add-migration initial" command, if using the Packge Manager Console in Visual Studio, or via the CLI, using the "dotnet ef migrations add InitialCreate" command.
After that, use the update-database command in the PM Console, or dotnet ef database update, in the CLI. The project to run the migration is TVShowTracker.Infra.Data .

Once the migration is done, just select the WebUi project as initial and run the application.