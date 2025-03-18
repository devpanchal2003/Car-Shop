<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="C_Login.aspx.cs" Inherits="CarShop2024.Customer.C_Login" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <title></title>
        <script type="text/javascript">
    history.pushState(null, null, document.URL);
    window.addEventListener('popstate', function () {
        history.pushState(null, null, document.URL);
    });
        </script>
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
    width: 50%;
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
    background-color: #0056b3;
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
.container{
    border:solid;
}
        </style>
</head>
<body>
    <div class="header">
    <h1>Welcome to Car Shop</h1>
    <nav>
        <%--<ul>
            <li><a href="">Home</a></li>
            <li><a href="#">Update Profile</a></li>
            <li><a href="#">Change PAssword</a></li>
            <li><a href="Logout.aspx">Logout</a></li>
        </ul>--%>
    </nav>
</div>
    <center>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Login</h2>
            <asp:Label ID="Label1" runat="server" ForeColor="Red" Text=""></asp:Label>
            <br />
            Email: <asp:TextBox ID="reg_email" runat="server"></asp:TextBox><br />
            Password: <asp:TextBox ID="reg_password" runat="server" TextMode="Password"></asp:TextBox><br />
            <asp:Button ID="login_submit" runat="server" Text="Login" OnClick="login_submit_Click" /><br /><br />
            <a href="C_Registration.aspx">Registration</a><br />
            <a href="ForgotPassword.aspx">ForgotPassword</a>
        </div>
    </form>
        </center>
    <div class="footer">
    <p>&copy; 2024 Car Shop. All Rights Reserved.</p>
</div>
</body>
</html>