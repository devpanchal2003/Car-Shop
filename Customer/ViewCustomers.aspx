<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewCustomers.aspx.cs" Inherits="CarShop2024.Admin.ViewCustomers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="styles.css">
    <title>Navbar</title>
    <style>
        .search-bar {
            margin-bottom: 20px;
        }
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
body{
    background-color:;
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
    //display: block;
    padding: 10px;
    transition: background-color 0.3s;
    background-color: #333;
    width:fit-content;
    padding:5px;
}

a:hover {
    background-color: #555;
}
form{
    margin-left:250px;
}
tr{
    height:40px;
}
    </style>
</head>
<body>

<div class="navbar">
    <ul>
        <li><a href="ViewCustomers.aspx">Customers</a></li>
        <li><a href="ViewStaff.aspx">Staffs</a></li>
        <li><a href="AddCustomer.aspx">Add Customer</a></li>
        <li><a href="AddCar.aspx">Add Cars</a></li>
        <li><a href="S_Logout.aspx">Logout</a></li>
        <li><a href="S_ChangePassword.aspx">Change Password</a></li>
        <li><a href="#">Update Profile</a></li>
    </ul>
</div>
    <div>
        <br /><br />
    <form id="form1" runat="server">
        <div class="search-bar">
            <h2>Search Customer Details</h2>
            <label for="txtSearchFirstName">Search by First Name:</label>
            <asp:TextBox ID="txtSearchFirstName" runat="server"></asp:TextBox>
            <label for="txtSearchLastName">Search by Last Name:</label>
            <asp:TextBox ID="txtSearchLastName" runat="server"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
            <h2>-------------------------------------------------------------------------------------------------</h2>
        </div>
        <div>
            <h2>Customer Details</h2>
            <table border="1">
                <tr>
                    <th>ID</th>
                    <th>First Name</th>
                    <th>Last Name</th>
                    <th>Email</th>
                    <th>Contact Number</th>
                    <th>Gender</th>
                    <th>Address</th>
                    <th>Actions</th>
                </tr>
                <asp:Literal ID="ltCustomers" runat="server"></asp:Literal>
            </table>
        </div>
    </form>
        </div>
</body>
</html>
