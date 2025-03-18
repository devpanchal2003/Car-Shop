<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CarDetails.aspx.cs" Inherits="CarShop2024.Customer.CarDetails" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Cars</title>
    <style>
        .car-container {
    display: flex;
    flex-wrap: wrap;
    justify-content: space-around;
    align-items: flex-start;
}

.car-card {
    width: 300px;
    padding: 20px;
    margin-bottom: 20px;
    border: 1px solid #ddd;
    border-radius: 5px;
}

.car-card h3 {
    margin-top: 0;
}

.buy-btn {
    background-color: #007bff;
    color: #fff;
    border: none;
    padding: 8px 16px;
    border-radius: 5px;
    cursor: pointer;
}

.buy-btn:hover {
    background-color: #0056b3;
}

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Available Cars</h2><br />
        <div class="car-container">
            
            <asp:Literal ID="ltCars" runat="server"></asp:Literal>
        </div>
    </form>
</body>
</html>
