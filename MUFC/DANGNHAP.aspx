<%@ Page Title="" Language="C#" MasterPageFile="~/TAIKHOAN.Master" AutoEventWireup="true" CodeBehind="DANGNHAP.aspx.cs" Inherits="MUFC.DANGNHAP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
  <div class="login">
  	<h1 class="login-heading">
      <strong>WELCOME TO SHBDN</strong> </h1>
      <asp:TextBox ID="tbTenDangNhap" runat="server" placeholder="TÊN ĐĂNG NHẬP" CssClass="input-txt"></asp:TextBox>
      <asp:TextBox ID="tbMatKhau" runat="server" placeholder="MẬT KHẨU" CssClass="input-txt" TextMode="Password"></asp:TextBox>
      <asp:Button ID="btLogin" runat="server" Text="ĐĂNG NHẬP" CssClass="btn" OnClick="btLogin_Click" />
          </div>
   
  </div>
            <asp:Label ID="lThongBao" runat="server" ></asp:Label>

  
  

    <script  src="js/index.js"></script>
</asp:Content>
