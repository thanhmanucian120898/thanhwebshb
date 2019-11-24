<%@ Page Title="" Language="C#" MasterPageFile="~/NHANVIEN.master" AutoEventWireup="true" CodeBehind="TTCT.aspx.cs" Inherits="MUFC.TTCT" %>
<asp:Content ID="Content1" ContentPlaceHolderID="maincontent" runat="server">
    <table>
        <tr>
            <td>ID:</td><td>
            <asp:TextBox ID="tbID" runat="server" Width="83px"></asp:TextBox>
            </td>
            <td>Tên:</td><td>
            <asp:TextBox ID="tbTen" runat="server"></asp:TextBox>
            </td>
            <td>Vị trí thi đấu:</td><td>
            <asp:DropDownList ID="dsVT" runat="server">
            </asp:DropDownList>
            </td>
            <td>Hình ảnh:</td><td>
            
                <!--Đoạn này giúp chọn file hình ảnh có đuôi JPG -->
            
            <asp:FileUpload ID="FileUploadControl" runat="server" OnLoad="FileUploadControl_Load" Width="162px" />
<asp:RegularExpressionValidator ID="regexValidator" runat="server"
     ControlToValidate="FileUploadControl"
     ErrorMessage="Only JPEG images are allowed" 
     ValidationExpression="(.*\.([Jj][Pp][Gg])|.*\.([Jj][Pp][Ee][Gg])$)">
</asp:RegularExpressionValidator>
                <!--End: Đoạn này giúp chọn file hình ảnh có đuôi JPG -->
            </td>
        </tr>
    </table>
    <asp:Label ID="lThongBao" runat="server" Text="Chỗ hiện thông báo!!!"></asp:Label>
    <br />
    <asp:Button ID="bThemMoi" runat="server" OnClick="bThemMoi_Click" Text="Thêm" />
    <br />
    <p>
        <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
        
        <asp:DataList ID="DataList1" runat="server" RepeatDirection="Horizontal" Width="1114px" RepeatColumns="3" CellPadding="4" ForeColor="#333333" Height="430px">
            <AlternatingItemStyle BackColor="White" />
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <ItemStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <ItemTemplate>
                <asp:Table ID="Table1" runat="server" Width="256px">
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server">
                    ID: <asp:Label ID="lId" runat="server" Text='<%# Eval("ID") %>'></asp:Label><br />
                    Tên:        <asp:Label ID="lTenHang" runat="server" Text='<%# Eval("Ten") %>'></asp:Label><br />
                    Vị trí:        <asp:Label ID="lLoaiHang" runat="server" Text='<%# Eval("ID_VT") %>'></asp:Label>

                        </asp:TableCell>
                        <asp:TableCell runat="server">
                            <asp:Image ID="hinhAnh" runat="server" Height="170" Width="150" ImageUrl='<%#Bind("hinhAnh","~/files/img/{0}")%>' />

                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </ItemTemplate>
            <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        </asp:DataList>
    </p>
</asp:Content>
