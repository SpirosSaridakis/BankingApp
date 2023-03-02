# Padanian Bank

This application was created for academic purposes. We used c# and the .NET Framework(CORE 3.1) to create the back-end of our website and to design the front end of our application we used the Views provided by the framework as well. This website can be used by either customers or employees of the bank, we did that by adding two roles. The application communicates with an sql server(we used a built in one in visual studio).
Note: There is a text file in this repository containing a script used to create all the database tables.

# App Functionalities

* Customers are able to create accounts that can have different currencies and types(Salary, Savings, Investor, Business).
* Basic ATM functionality(Deposit, withdraw, transfer) for customers and employees.
* Customers can view the account history of accounts that they own and employees can do the same for all of the accounts that are registered.
* Employees are able to change the account type and search for specific accounts.
* Both customers and employees are able to view some statistics about the bank such as the number of accounts registered, the cash reserves of the bank, how many           transactions were completed in the current day and the number of accounts in each category. 

# Technical Details

### Back-End
* This project is built as a REST-API, we use the controller methods to handle http requests.
* Most of the work is done by the Accounts Controller which uses methods offered to it from the IPadanianService, an interface used for dependency injection.
* The IPadanianService interface is implemented in the Padanian_Service class in which most of the business logic is handled.
* We used 3 model classes, Accounts, Transactions which represent the equivalent entities and the StatData class which is used for the bank statistics functions.
* As said in the description of the project, we use 2 roles to allow only authorized users to view the requested data, each user is able to view the accounts that are     registered using their user-id(which is the same user-id that a user gets when registering an account).
* Every new account that is created is automatically assigned the role of "Customer".
* To create an account with the "Employee" role, you need to input it directly to the database(By first creating an account and then entering the user-id in the           AspNetUserRoles table). Also, if need be you need to add the two roles("Customer" and "Employee" in the database along with the id of each role in the AspNetRoles       table)

### Front-End
* Our controllers return Views in which the needed information is displayed.
* Not all views are available to every role, for example, a user can view all their accounts but an employee has to search for a specific account.
* The Views are written in CSHTML.

### Testing
* We tested the application with conventional user testing during the development of the application.
* We did discover some problems during our testing and most of the bugs were eliminated.
