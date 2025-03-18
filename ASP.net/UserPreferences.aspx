<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserPreferences.aspx.cs" Inherits="CarShop2024.ASP.net.UserPreferences" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Preferences</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>User Preferences</h2>
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            <br /><br />
            UserName: <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
            <br /><br />
            Theme: <asp:TextBox ID="txtTheme" runat="server"></asp:TextBox>
            <br /><br />
            Language: <asp:TextBox ID="txtLanguage" runat="server"></asp:TextBox>
            <br /><br />
            Gender: <asp:RadioButtonList ID="rblGender" runat="server">
                <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
            </asp:RadioButtonList>
            <br /><br />
            Address: <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
            <br /><br />
            Password: <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            <br /><br />
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
            <asp:Button ID="btnLoad" runat="server" Text="Load" OnClick="btnLoad_Click" />
            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
            <br /><br />
            <asp:GridView ID="gvUserPreferences" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>
