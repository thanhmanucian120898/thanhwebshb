<%@ Page Title="" Language="C#" MasterPageFile="~/QUANLY.master" AutoEventWireup="true" CodeBehind="QL3.aspx.cs" Inherits="MUFC.QL3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="maincontent" runat="server">
    <table style="width:100%;" >
        <caption style="color:#AF4034;font-size:20px">
            <h3>Thêm cầu thủ mới</h3>
        </caption>
        <tr>
            <td style="width: 231px; height: 40px">ID CẦU THỦ</td>
            <td style="height: 40px"><asp:TextBox ID="tbID" runat="server" Width="78px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 231px">TÊN CẦU THỦ</td>
            <td><asp:TextBox ID="tbTen" runat="server" Width="320px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 231px">NĂM SINH</td>
            <td><asp:TextBox ID="tbNS" runat="server" Width="320px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 231px">TUỔI</td>
            <td><asp:TextBox ID="tbTuoi" runat="server" Width="75px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 231px">QUÊ QUÁN</td>
            <td><asp:TextBox ID="tbQQ" runat="server" Width="319px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 231px">GIÁ TRỊ</td>
            <td><asp:TextBox ID="tbGT" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 231px">ID_VT</td>
            <td><asp:DropDownList ID="dsVT" runat="server" Width="114px"></asp:DropDownList></td>
        </tr>
        </table>
    
    <asp:Label ID="lThongBao" runat="server" Text=" "></asp:Label>
    <br />
    <asp:Button ID="btThem" runat="server" Height="37px" OnClick="btThem_Click1" Text="Thêm cầu thủ" Width="139px" />
    <asp:GridView ID="Gv1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
        <AlternatingRowStyle BackColor="White" />
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <SortedAscendingCellStyle BackColor="#FDF5AC" />
        <SortedAscendingHeaderStyle BackColor="#4D0000" />
        <SortedDescendingCellStyle BackColor="#FCF6C0" />
        <SortedDescendingHeaderStyle BackColor="#820000" />
    </asp:GridView>
    
    
</asp:Content>
