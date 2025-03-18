<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewStaff.aspx.cs" Inherits="CarShop2024.Admin.ViewStaff" %>

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
    <form id="form1" runat="server">
        <div>
            <h2>Staff Details</h2>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="PasswordHash" HeaderText="Password Hash" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
