<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="CarShop2024.Customer.ForgotPassword" %>

<!DOCTYPE html>
<html>
<head>
    <title>Forgot Password</title>
    <style>
        body {
            background-color: #f0f0f0; /* Set background color of the body */
            font-family: Arial, sans-serif; /* Set default font family */
            margin: 0;
            padding: 0;
        }

        .limiter {
            width: 100%;
            margin: 0 auto;
        }

        .container-login100 {
            display: flex;
            flex-wrap: wrap;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }

        .wrap-login100 {
            align-items:center;
            width: 50%;
            max-width: 1100px;
            background: #fff;
            border-radius: 10px;
            overflow: hidden;
            position: relative;
           
            justify-content: space-between;
        }

        .login100-more {
            background-size: cover;
            background-position: center;
            flex-basis: 50%;
        }

        .login100-form {
            margin-left:10%;
            width: 73%;
            padding: 80px 30px 90px 30px;
            display: flex;
            flex-direction: column;
            justify-content: center;
            align-items: center;
            flex-basis: 50%;
        }

        .input {
            border: 1px solid #ccc;
            border-radius: 5px;
            padding: 10px;
            margin-bottom: 20px;
            width: 100%;
        }

        .login100-form-btn {
            background-color: #333;
            color: #fff;
            border: none;
            border-radius: 5px;
            padding: 10px 20px;
            cursor: pointer;
            transition: background-color 0.3s;
        }

        .login100-form-btn:hover {
            background-color: #555;
        }

        .container-login100-form-btn {
            text-align: center;
            margin-top: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="limiter">
            <div class="container-login100">
                <div class="wrap-login100">
                    <asp:Panel ID="pnlForgotPassword" runat="server" CssClass="login100-form validate-form">
                        <h2>Forgot Password</h2><br /><br /><br /><br />
                      
                        <br />
                        <br /><br />
                        <asp:TextBox ID="Email" runat="server" CssClass="input" placeholder="Enter Your Email"></asp:TextBox>
                          <asp:Label ID="lblMessage" runat="server" Text=""  ForeColor="Red" ></asp:Label><br /><br />
                        <asp:Button ID="btnRequestOTP" runat="server" CssClass="login100-form-btn" OnClick="btnRequestOTP_Click" Text="Request OTP" />
                        <asp:TextBox ID="txtOTP" runat="server" CssClass="input" placeholder="Enter OTP" Visible="false"></asp:TextBox>
                        <asp:Button ID="btnVerifyOTP" runat="server" Text="Verify OTP" CssClass="login100-form-btn" OnClick="btnVerifyOTP_Click" Visible ="false" />
                         <div>
                      <asp:Label ID="txterror" runat="server" ForeColor="Red"></asp:Label>
                    </div>
                        <br />
                        <br />
                        <br /><br />
                        <div class="container-login100-form-btn">
                            <a href="login.aspx">Back to Login</a>
                        </div>
                    </asp:Panel>
                
                </div>
            </div>
        </div>
    </form>
</body>
</html>
