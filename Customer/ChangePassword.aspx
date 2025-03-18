<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="CarShop2024.Customer.ChangePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Change Password</title>
    <style>
            /* CSS for Login Form */
body {
    font-family: Arial, sans-serif;
    background-color: #f4f4f4;
    margin: 0;
    padding: 0;
}

.container {
    width: 50%;
    margin: 0 auto;
    padding: 20px;
    background-color: #fff;
    border-radius: 5px;
    box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
}

h2 {
    text-align: center;
    margin-bottom: 20px;
}

label {
    display: block;
    margin-bottom: 5px;
}

input[type="text"],
input[type="email"],
input[type="password"] {
    width: 60%;
    padding: 8px;
    margin-bottom: 10px;
    border: 1px solid #ccc;
    border-radius: 3px;
    box-sizing: border-box;
}

button {
    padding: 10px 20px;
    background-color: #007bff;
    color: #fff;
    border: none;
    border-radius: 3px;
    cursor: pointer;
}

button:hover {
    background-color: grey;
}

            /* Header styles */
.header {
    background-color: #333;
    color: white;
    padding: 10px;
    text-align: center;
}

.header h1 {
    margin: 0;
}

nav ul {
    list-style-type: none;
    padding: 0;
}

nav ul li {
    display: inline;
    margin-right: 10px;
}

nav ul li a {
    color: white;
    text-decoration: none;
}

/* Footer styles */
.footer {
    background-color: #333;
    color: white;
    text-align: center;
    padding: 10px;
    position: fixed;
    bottom: 0;
    left: 0;
    width: 100%;
}

.footer p {
    margin: 0;
}
form{
    border:double;
}
        </style>
</head>
<body>
    <div class="header">
    <h1>Welcome to Car Shop</h1>
    <nav>
        <ul>
            <li><a href="C_Dashboard.aspx">Home</a></li>
            <li><a href="UpdateProfile.aspx">Update Profile</a></li>
            <li><a href="ChangePassword.aspx">Change Password</a></li>
            <li><a href="Logout.aspx">Logout</a></li>
        </ul>
    </nav>
</div>
    <center>
    <form id="form1" runat="server">
        <div>
            <h2>Change Password</h2>
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            <br /><br />
            Current Password: <asp:TextBox ID="txtCurrentPassword" runat="server" TextMode="Password"></asp:TextBox><br />
            New Password: <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password"></asp:TextBox><br />
            Confirm New Password: <asp:TextBox ID="txtConfirmNewPassword" runat="server" TextMode="Password"></asp:TextBox><br />
        <center>    
    <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" OnClick="btnChangePassword_Click" />
            </center>
        </div>
    </form>
        </center>
     <div class="footer">
    <p>&copy; 2024 Car Shop. All Rights Reserved.</p>
</div>
</body>
</html>
