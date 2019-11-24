<%@ Page Title="" Language="C#" MasterPageFile="~/QUANLY.master" AutoEventWireup="true" CodeBehind="QL2.aspx.cs" Inherits="MUFC.QL2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="maincontent" runat="server">
    <table style="width:100%;">
        <tr>
            <td style="width: 197px">Tên cầu thủ</td>
            <td></td>
            <td style="width: 250px">
            <asp:TextBox ID="tbTen" runat="server" Width="209px"></asp:TextBox></td>
            
            <td><asp:Button ID="btTk" runat="server" Text="Tìm kiếm" Height="30px" OnClick="btTk_Click" /></td>
        </tr>
        
        </table>
    <br />
    <asp:Label ID="lThongBao" runat="server" Text=" "></asp:Label>
    <asp:GridView ID="Gv1" runat="server" Width="100%"></asp:GridView>
</asp:Content>
