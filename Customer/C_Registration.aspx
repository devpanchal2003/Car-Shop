<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="C_Registration.aspx.cs" Inherits="CarShop2024.C_Registration" %>

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
    padding: 50px;
    border-radius: 5px;
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


    </style>
</head>
<body>
    <div class="header">
        <h1>Car Shop</h1>
    </div>
    <form id="form1" runat="server">
        <div>
            <h2>Registration Form</h2>
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
            
            <a href="C_Login.aspx">Login</a>
                </center>
        </div>
    </form>
    <div class="footer">
        &copy; 2024 Car Shop. All Rights Reserved.
    </div>
</body>
</html>
