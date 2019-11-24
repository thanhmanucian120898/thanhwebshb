<%@ Page Title="" Language="C#" MasterPageFile="~/QUANLY.master" AutoEventWireup="true" CodeBehind="QL4.aspx.cs" Inherits="MUFC.QL4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="maincontent" runat="server">
    <table style="width:100%;" >
        <caption style="color:#AF4034;font-size:20px">
            <h3>CẬP NHẬP CẦU THỦ</h3>
        </caption>
        <tr>
            <td style="width: 231px; height: 40px">ID CẦU THỦ</td>
            <td style="height: 40px; width: 378px;">
                <asp:DropDownList ID="dsID" runat="server" Height="16px" Width="117px"></asp:DropDownList></asp:TextBox></td>
            <td><asp:Button ID="btCapnhat" runat="server" Text="Cập nhập" Height="35px" OnClick="btCapnhat_Click" Width="137px" /></td>
            
        </tr>
        <tr>
            <td style="width: 231px">TÊN CẦU THỦ</td>
            <td style="width: 378px"><asp:TextBox ID="tbTen" runat="server" Width="320px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 231px">NĂM SINH</td>
            <td style="width: 378px"><asp:TextBox ID="tbNS" runat="server" Width="320px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 231px">TUỔI</td>
            <td style="width: 378px"><asp:TextBox ID="tbTuoi" runat="server" Width="75px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 231px">QUÊ QUÁN</td>
            <td style="width: 378px"><asp:TextBox ID="tbQQ" runat="server" Width="319px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 231px">GIÁ TRỊ</td>
            <td style="width: 378px"><asp:TextBox ID="tbGT" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 231px">ID_VT</td>
            <td style="width: 378px"><asp:DropDownList ID="dsVT" runat="server" Width="114px"></asp:DropDownList></td>
        </tr>
        </table>
    <asp:Label ID="lThongBao" runat="server" Text=" "></asp:Label>
    <br />
    <asp:GridView ID="Gv1" runat="server" Width="100%"></asp:GridView>
</asp:Content>
