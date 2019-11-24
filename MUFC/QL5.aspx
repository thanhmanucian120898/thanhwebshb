<%@ Page Title="" Language="C#" MasterPageFile="~/QUANLY.master" AutoEventWireup="true" CodeBehind="QL5.aspx.cs" Inherits="MUFC.QL5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="maincontent" runat="server">
    <asp:GridView ID="Gv3" runat="server" OnRowDeleting="Gv3_RowDeleting" Width="100%" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="Gv3_PageIndexChanging" PageSize="4">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField HeaderText="THANH LÝ" ShowDeleteButton="True" ShowHeader="True" />
        </Columns>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" BorderWidth="30px" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <SortedAscendingCellStyle BackColor="#FDF5AC" />
        <SortedAscendingHeaderStyle BackColor="#4D0000" />
        <SortedDescendingCellStyle BackColor="#FCF6C0" />
        <SortedDescendingHeaderStyle BackColor="#820000" />
    </asp:GridView>
    <asp:Label ID="lThongBao" runat="server" Text=" "></asp:Label>
</asp:Content>
