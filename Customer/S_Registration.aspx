<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="S_Registration.aspx.cs" Inherits="CarShop2024.Staff.S_Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
    font-family: Arial, sans-serif;
    background-color: #f4f4f4;
    margin: 0;
    padding: 0;
}

form {
    width: 300px;
    margin: 50px auto;
    padding: 20px;
    border: 1px solid #ccc;
    background-color: #fff;
    border-radius: 5px;
    box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
}

h2 {
    text-align: center;
}

label {
    display: block;
    margin-bottom: 5px;
}

input[type="text"],
input[type="password"],
input[type="submit"] {
    width: 100%;
    padding: 8px;
    margin-bottom: 10px;
    border: 1px solid #ccc;
    border-radius: 4px;
    box-sizing: border-box;
}

input[type="submit"] {
    background-color: #007bff;
    color: white;
    cursor: pointer;
}

input[type="submit"]:hover {
    background-color: #0056b3;
}
/* Header styles */
.header {
    background-color: #333;
    color: #fff;
    padding: 10px 0;
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
    display: inline-block;
    margin-right: 10px;
}

nav ul li a {
    color: #fff;
    text-decoration: none;
}

/* Footer styles */
.footer {
    background-color: #333;
    color: #fff;
    text-align: center;
    padding: 10px 0;
    position: fixed;
    bottom: 0;
    width: 100%;
}

.footer p {
    margin: 0;
}

    </style>
</head>
<body>
    <div class="header">
    <h1>Welcome to Car Shop</h1>
    
</div>
    <form id="form1" runat="server">
        <div>
            <h2>Registration Form</h2>
            <asp:Label ID="Label1" runat="server" ForeColor="Red" Text=""></asp:Label>
            <br />
            Email: <asp:TextBox ID="reg_email" runat="server"></asp:TextBox><br />
            Password: <asp:TextBox ID="reg_password" runat="server" TextMode="Password"></asp:TextBox><br />
            Confirm Password: <asp:TextBox ID="reg_confirm_password" runat="server" TextMode="Password"></asp:TextBox><br />
            <asp:Button ID="submit" runat="server" Text="Submit" OnClick="submit_Click" />
            <center><a href="S_Login.aspx">Login.aspx</a></center>
        </div>
    </form>
    <div class="footer">
    <p>&copy; 2024 Car Shop. All Rights Reserved.</p>
</div>
</body>
</html>
