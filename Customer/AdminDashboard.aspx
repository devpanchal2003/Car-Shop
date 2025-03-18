<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="CarShop2024.Admin.AdminDashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="styles.css">
    <title>Navbar</title>
    <style>
        body {
    margin: 0;
    padding: 0;
    font-family: Arial, sans-serif;
}

.navbar {
    height: 100vh;
    width: 200px;
    position: fixed;
    top: 0;
    left: 0;
    background-color: #333;
    padding-top: 20px;
}

ul {
    list-style-type: none;
    padding: 0;
    margin: 0;
}

li {
    padding: 10px 0;
    text-align: center;
}

a {
    text-decoration: none;
    color: white;
    display: block;
    padding: 10px;
    transition: background-color 0.3s;
}

a:hover {
    background-color: #555;
}

    </style>
</head>
<body>
    <div class="navbar">
        <ul>
            <li><a href="ViewCustomers.aspx">View Customers</a></li>
            <li><a href="ViewStaff.aspx">View Staff</a></li>
            <li><a href="#">Add Car</a></li>
            <li><a href="#">Add Company</a></li>
            <li><a href="Logout.aspx">Logout</a></li>
        </ul>
    </div>
</body>
</html>
