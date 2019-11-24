<%@ Page Title="" Language="C#" MasterPageFile="~/QUANLY.master" AutoEventWireup="true" CodeBehind="QL1.aspx.cs" Inherits="MUFC.QL1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="maincontent" runat="server">

    <asp:GridView ID="Gv2" runat="server" CellPadding="8" ForeColor="#333333" GridLines="None" Width="100%" OnPageIndexChanging="Gv1_PageIndexChanging" AllowPaging="True" Height="238px" PageSize="5" ShowFooter="True">
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
    <p>
    </p>

</asp:Content>
