<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Appointments.aspx.cs" Inherits="CarShop2024.Appointments" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Book Appointment</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Book Appointment</h2>
        <div>
            <table>
                <tr>
                    <th>Appointment ID</th>
                    <th>Customer Name</th>
                    <th>Appointment Date</th>
                    <th>Car Make</th>
                    <th>Car Model</th>
                    <th>Status</th>
                    <th>Action</th>
                </tr>
                <asp:Literal ID="appoint" runat="server"></asp:Literal>
            </table>
        </div>
    </form>
</body>
</html>
