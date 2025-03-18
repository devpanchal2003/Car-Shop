<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCar.aspx.cs" Inherits="CarShop2024.Customer.AddCar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Car</title>
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
.form1{
    height:20px;
}

/* Form button hover styles */
form button:hover {
    background-color: #555;
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
 <form id="form1" runat="server" enctype="multipart/form-data">
        <div>
            <h2>Add Car Details</h2>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            <br /><br />
            <asp:TextBox ID="txtMake" runat="server" placeholder="Make"></asp:TextBox>
            <br /><br />
            <asp:TextBox ID="txtModel" runat="server" placeholder="Model"></asp:TextBox>
            <br /><br />
            <asp:TextBox ID="txtYear" runat="server" placeholder="Year"></asp:TextBox>
            <br /><br />
            <asp:FileUpload ID="fileUpload" runat="server" />
            <br /><br />
            <asp:TextBox ID="txtPrice" runat="server" placeholder="Price"></asp:TextBox>
            <br /><br />
            <asp:TextBox ID="txtColor" runat="server" placeholder="Color"></asp:TextBox>
            <br /><br />
            <asp:DropDownList ID="ddlEngineType" runat="server">
                <asp:ListItem Text="Select Engine Type" Value="" />
                <asp:ListItem Text="Patrol" Value="Patrol" />
                <asp:ListItem Text="Diesel" Value="Diesel" />
            </asp:DropDownList>
            <br /><br />
            <asp:DropDownList ID="ddlTransmissionType" runat="server">
                <asp:ListItem Text="Select Transmission Type" Value="" />
                <asp:ListItem Text="Electric" Value="Electric" />
                <asp:ListItem Text="Manual" Value="Manual" />
                <asp:ListItem Text="Auto" Value="Auto" />
            </asp:DropDownList>
            <br /><br />
            <asp:TextBox ID="txtHorsePower" runat="server" placeholder="Horse Power"></asp:TextBox>
            <br /><br />
            <asp:TextBox ID="txtFeatures" runat="server" placeholder="Features"></asp:TextBox>
            <br /><br />
            <asp:CheckBox ID="chkAvailability" runat="server" Text="Available" />
            <br /><br />
            <asp:Button ID="btnAddCar" runat="server" Text="Add Car" OnClick="btnAddCar_Click" />
        </div>
    </form>
</body>
</html>

