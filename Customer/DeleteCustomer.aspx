<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteCustomer.aspx.cs" Inherits="CarShop2024.Customer.DeleteCustomer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Delete Customer</title>
    <link rel="stylesheet" href="styles.css"> <!-- Assuming your CSS file is named styles.css -->
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
    <!-- Include the navbar directly in the page -->
    <div class="navbar">
        <ul>
            <li><a href="ViewCustomers.aspx">Customers</a></li>
            <li><a href="ViewStaff.aspx">Staffs</a></li>
            <li><a href="#">Add Cars</a></li>
            <li><a href="S_Logout.aspx">Logout</a></li>
            <li><a href="S_ChangePassword.aspx">Change Password</a></li>
            <li><a href="#">Update Profile</a></li>
        </ul>
    </div>

    <form id="form1" runat="server">
        <div>
            <h2>Delete Customer</h2>
            <asp:Label ID="lblMessage" runat="server" CssClass="message" Visible="false"></asp:Label>
            <div>
                <label for="txtCustomerId">Customer ID:</label>
                <asp:TextBox ID="txtCustomerId" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
            </div>
        </div>
    </form>
</body>
</html>
