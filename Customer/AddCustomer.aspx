<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCustomer.aspx.cs" Inherits="CarShop2024.Customer.AddStaff" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration</title>
    <style>
        /* Body styles */
body {
    font-family: Arial, sans-serif;
    margin: 0;
    padding: 0;
}

/* Header styles */
.header {
    background-color: #333;
    color: white;
    text-align: center;
    height:20px;
    padding: 10px 0;
}

/* Footer styles */
.footer {
    background-color: #333;
    color: white;
    text-align: center;
    padding: 10px 0;
    position: fixed;
    bottom: 0;
    left: 0;
    width: 100%;
}

/* Form container styles */
.form-container {
    max-width: 500px;
    margin: 0 auto;
    padding: 20px;
}

/* Form styles */
form {
    background-color: #f9f9f9;
    width:50%;
    height:50%;
    padding: 50px;
    border-radius: 5px;
    text-align:left;
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
}

/* Form input styles */
form input[type="text"],
form input[type="email"],
form input[type="tel"],
form input[type="password"] {
    width: 100%;
    padding: 10px;
    margin-bottom: 10px;
    border: 1px solid #ccc;
    border-radius: 3px;
    box-sizing: border-box;
}

/* Form button styles */
form button {
    width: 100%;
    padding: 10px;
    background-color: #333;
    color: white;
    border: none;
    border-radius: 3px;
    cursor: pointer;
}

/* Form button hover styles */
form button:hover {
    background-color: #555;
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
    <%--<div class="header">
        <h7>Add Customer</h7>
    </div>--%>
    <center>
    <form id="form1" runat="server">
        <h3 style="text-align:center">Add Customer</h3>
        <div>
            <asp:Label ID="Label1" runat="server" ForeColor="Red" Text=""></asp:Label>
            <br />
            First Name: <asp:TextBox ID="reg_firstname" runat="server"></asp:TextBox><br />
            Last Name: <asp:TextBox ID="reg_lastname" runat="server"></asp:TextBox><br />
            Email: <asp:TextBox ID="reg_email" runat="server"></asp:TextBox><br />
            Contact Number: <asp:TextBox ID="reg_contact" runat="server"></asp:TextBox><br />
            Gender: <asp:RadioButton ID="rbmale" runat="server" Text="Male" /><asp:RadioButton ID="rbfemale" runat="server" Text="Female" /><br />
            Address: <asp:TextBox ID="reg_address" runat="server"></asp:TextBox><br />
            Password: <asp:TextBox ID="reg_password" runat="server" TextMode="Password"></asp:TextBox><br />
            Confirm Password: <asp:TextBox ID="reg_confirm_password" runat="server" TextMode="Password"></asp:TextBox><br />
            <center>
            <asp:Button ID="submit" runat="server" Text="Register" OnClick="submit_Click" /><br />
            
            <%--<a href="C_Login.aspx">Login</a>--%>
                </center>
        </div>
    </form>
        </center>
</body>
</html>

