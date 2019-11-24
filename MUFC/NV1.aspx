<%@ Page Title="" Language="C#" MasterPageFile="~/NHANVIEN.master" AutoEventWireup="true" CodeBehind="NV1.aspx.cs" Inherits="MUFC.NV1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="maincontent" runat="server">
    <asp:GridView ID="GridView1" Width="100%"  runat="server" HorizontalAlign="Center" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="20" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
     <AlternatingRowStyle BackColor="#CCCCCC" />
     <FooterStyle BackColor="#CCCCCC" />
     <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
     <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
     <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
     <SortedAscendingCellStyle BackColor="#F1F1F1" />
     <SortedAscendingHeaderStyle BackColor="#808080" />
     <SortedDescendingCellStyle BackColor="#CAC9C9" />
     <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>
</asp:Content>
