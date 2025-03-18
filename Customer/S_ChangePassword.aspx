<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="S_ChangePassword.aspx.cs" Inherits="CarShop2024.Staff.S_ChangePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Change Password</title>
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
            <h2>Change Password</h2>
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            <br /><br />
            Current Password: <asp:TextBox ID="txtCurrentPassword" runat="server" TextMode="Password"></asp:TextBox><br />
            New Password: <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password"></asp:TextBox><br />
            Confirm New Password: <asp:TextBox ID="txtConfirmNewPassword" runat="server" TextMode="Password"></asp:TextBox><br />
            <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" OnClick="btnChangePassword_Click" />
        </div>
    </form>
</body>
</html>
