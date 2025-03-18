<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StaffHomePage.aspx.cs" Inherits="CarShop2024.Staff.StaffHomePage" %>
<!DOCTYPE html>
<html lang="en">
<head>
<meta charset="UTF-8">
<meta name="viewport" content="width=device-width, initial-scale=1.0">
<title>Left Sided Navbar</title>
<style>
    /* Resetting default margin and padding */
    * {
        margin: 0;
        padding: 0;
        box-sizing: border-box;
    }

    body {
        font-family: Arial, sans-serif;
    }

    .navbar {
        position: fixed;
        left: 0;
        top: 0;
        height: 100%;
        width: 200px;
        background-color: #333;
        padding-top: 20px;
    }

    .navbar ul {
        list-style-type: none;
        padding: 0;
    }

    .navbar li {
        margin-bottom: 10px;
    }

    .navbar li a {
        display: block;
        color: #fff;
        text-decoration: none;
        padding: 10px;
        border-radius: 5px;
        transition: background-color 0.3s;
    }

    .navbar li a:hover {
        background-color: #555;
    }
</style>
</head>
<body>

<div class="navbar">
    <ul>
        <li><a href="ViewCustomers.aspx">Customers</a></li>
        <li><a href="ViewStaff.aspx">Staffs</a></li>
        <li><a href="#">Add Cars</a></li>
        <li><a href="S_Logout.aspx">Logout</a></li>
        <li><a href="S_Logout.aspx">Appointments</a></li>
        <li><a href="S_ChangePassword.aspx">Change Password</a></li>
        <li><a href="#">Update Profile</a></li>
    </ul>
</div>

</body>
</html>
