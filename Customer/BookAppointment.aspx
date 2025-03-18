<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookAppointment.aspx.cs" Inherits="CarShop2024.BookTestdrive" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Book Appointment</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Book a Test Drive</h2>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
            <input id="txtPreferredTime" type="datetime-local" runat="server" required /><br /><br />
            <asp:DropDownList ID="ddlCars" runat="server" required></asp:DropDownList><br /><br />
            <asp:Button ID="btnBookAppointment" runat="server" Text="Book Appointment" OnClick="btnBookAppointment_Click" />
        </div>
    </form>
</body>
</html>
