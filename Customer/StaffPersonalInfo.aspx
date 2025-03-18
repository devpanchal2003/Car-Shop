<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StaffPersonalInfo.aspx.cs" Inherits="CarShop2024.Staff.StaffPersonalInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Staff Personal Information</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Staff Personal Information</h2>
            <hr />
            <div>
                First Name: <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox><br />
                Last Name: <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox><br />
                Address: <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox><br />
                Gender: <asp:DropDownList ID="ddlGender" runat="server">
                            <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                            <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                        </asp:DropDownList><br />
                Contact Number: <asp:TextBox ID="txtContactNumber" runat="server"></asp:TextBox><br />
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
            </div>
        </div>
    </form>
</body>
</html>

