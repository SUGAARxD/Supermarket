# Supermarket

## Overview

This is a C# project utilizing WPF (.NET Framework) and MVVM (Model-View-ViewModel) design pattern to create a application for managing a supermarket. The application consists of two main modules: administration and cashier.

## Technologies Used
- C#
- WPF (Windows Presentation Foundation)
- SQL Server
- MVVM (Model-View-ViewModel)

## Main Features
- Manage products, producers, categories, stocks and users
- Handle user authentication with different roles (administrator and cashier)
- Generate and view sales receipts

### 1. Administration Module

- **CRUD operations on all tables**
- **Specific reports like** :
  * List all products from a selected manufacturer by categories.
  * Display the total value of each product category in the supermarket.
  * View daily earnings for a selected user and month.
  * Display data from the largest receipt of the day.

![image](https://github.com/SUGAARxD/Supermarket/assets/80158909/3bc46558-a5af-4880-b27f-1d1ba40a27ba)
![image](https://github.com/SUGAARxD/Supermarket/assets/80158909/83bc2af6-098e-4f15-ae2b-15872e1e942a)
![image](https://github.com/SUGAARxD/Supermarket/assets/80158909/b684e5b3-a87b-46c0-bd0a-e38065adee34)


### 2. Cashier Module

- **Product search**:
  - Search products by name, barcode, expiration date, manufacturer, or category.

- **Receipt management**:
  - Add products to receipts, displaying their correct prices.
  - Remove products from receipts.

![image](https://github.com/SUGAARxD/Supermarket/assets/80158909/2f6a5d04-a3e2-4a5b-a460-baabf1555bee)

## Security Considerations

- The database is structured in the third normal form.
- The application avoids SQL injection by using stored procedures.
