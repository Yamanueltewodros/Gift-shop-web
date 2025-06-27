# GiftShop

GiftShop is an e-commerce web application built using ASP.NET Core MVC. It allows users to browse and purchase various gift items. The application includes features such as user authentication, shopping cart management, order processing, and administrative functionalities for managing items and categories.

## Project Structure

The project follows the Model-View-Controller (MVC) design pattern. Below is an overview of the main components:

- **Models**: Define the data structure and business logic.
- **Views**: Handle the presentation layer and user interface.
- **Controllers**: Manage user input and interactions, updating the model and returning the appropriate view.

## Features

- User Authentication and Authorization
- Shopping Cart Management
- Order Processing
- Admin Panel for Managing Items and Categories
- Responsive Design using Bootstrap

## Installation




1. **Clone the repository**:
    ```bash
    git clone https://github.com/million-mesfin/GiftShop.git
    cd GiftShop
    ```

2. **Install dependencies**:
    ```bash
    dotnet restore
    ```

3. **Update the database**:
    ```bash
    dotnet ef database update
    ```

4. **Run the application**:
    ```bash
    dotnet run
    ```

## Packages

The project uses the following NuGet packages:

- `Microsoft.AspNetCore.Identity.EntityFrameworkCore`
- `Microsoft.EntityFrameworkCore.SqlServer`
- `Microsoft.EntityFrameworkCore.Tools`
- `Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation`
- `Microsoft.AspNetCore.Authentication.Cookies`
- `Microsoft.AspNetCore.Identity.UI`
- `Microsoft.VisualStudio.Web.CodeGeneration.Design`

## Configuration

Ensure you have the correct connection string in the `appsettings.json` file:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=GiftShopDb;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
  // ...existing code...
}
```

## Usage

- **User Registration and Login**: Users can register and log in to their accounts.
- **Browse Items**: Users can browse items by categories.
- **Shopping Cart**: Users can add items to their shopping cart and proceed to checkout.
- **Order Management**: Users can view their orders, and admins can manage all orders.
- **Admin Panel**: Admins can add, edit, and delete items and categories.

## Contributing

Contributions are welcome! Please fork the repository and create a pull request with your changes.

## License

This project is licensed under the MIT License.
