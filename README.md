# Assignment2

## Appendix A: SQL scripts to create a database.

The script files for the first part of the assignment can be found in the [SQL Scripts](https://github.com/erikkvalvik/Assignment2/tree/main/SQL%20Scripts) folder.

## Appendix B: Reading data with SQL Client

The files for the second part of the assignment can be found in the [Assignment2](https://github.com/erikkvalvik/Assignment2/tree/main/Assignment2) folder.

The [Models](https://github.com/erikkvalvik/Assignment2/tree/main/Assignment2/Models) folder contains all the model classes.

### [Models folder](https://github.com/erikkvalvik/Assignment2/tree/main/Assignment2/Models)
- [Customer.cs](https://github.com/erikkvalvik/Assignment2/tree/main/Assignment2/Models/Customer.cs)
- [CustomerCountry.cs](https://github.com/erikkvalvik/Assignment2/tree/main/Assignment2/Models/CustomerCountry.cs)
- [CustomerGenre.cs](https://github.com/erikkvalvik/Assignment2/tree/main/Assignment2/Models/CustomerGenre.cs)
- [CustomerSpender.cs](https://github.com/erikkvalvik/Assignment2/tree/main/Assignment2/Models/CustomerGenre.cs)

The [Repositories](https://github.com/erikkvalvik/Assignment2/tree/main/Assignment2/Repositories) folder contains all the repositories and their interfaces.
It also contains the [ConnectionHelper](https://github.com/erikkvalvik/Assignment2/tree/main/Assignment2/Repositories/ConnectionHelper.cs) class that sets up the connection string to the database.

### [Repositories folder](https://github.com/erikkvalvik/Assignment2/tree/main/Assignment2/Repositories)
- [ConnectionHelper.cs](https://github.com/erikkvalvik/Assignment2/tree/main/Assignment2/Repositories/ConnectionHelper.cs)
- [CustomerRepository.cs](https://github.com/erikkvalvik/Assignment2/tree/main/Assignment2/Repositories/CustomerRepository.cs)
	- [ICustomerRepository.cs](https://github.com/erikkvalvik/Assignment2/tree/main/Assignment2/Repositories/ICustomerRepository.cs)
- [CustomerCountryRepository.cs](https://github.com/erikkvalvik/Assignment2/tree/main/Assignment2/Repositories/CustomerCountryRepository.cs)
	- [ICustomerCountryRepository.cs](https://github.com/erikkvalvik/Assignment2/tree/main/Assignment2/Repositories/ICustomerCountryRepository.cs)
- [CustomerGenreRepository.cs](https://github.com/erikkvalvik/Assignment2/tree/main/Assignment2/Repositories/CustomerGenreRepository.cs)
	- [ICustomerGenreRepository.cs](https://github.com/erikkvalvik/Assignment2/tree/main/Assignment2/Repositories/ICustomerGenreRepository.cs)
- [HighestSpenderRepository.cs](https://github.com/erikkvalvik/Assignment2/tree/main/Assignment2/Repositories/HighestSpenderRepository.cs)
	- [IHighestSpenderRepository.cs](https://github.com/erikkvalvik/Assignment2/tree/main/Assignment2/Repositories/IHighestSpenderRepository.cs)

**NOTE:** CustomerGenreRepository is not finished, and will not return the correct values. See summary above *GetFavoriteGenre* method in [CustomerGenreRepository.cs](https://github.com/erikkvalvik/Assignment2/tree/main/Assignment2/Repositories/CustomerGenreRepository.cs).