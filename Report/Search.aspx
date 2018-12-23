<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Report.Search" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
                <td>Từ ngày:</td>
                <td>
                    <asp:TextBox ID="txtFromDate" runat="server" Width="157px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Tới ngày:</td>
                <td>
                    <asp:TextBox ID="txtToDate" runat="server" Width="156px"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>Khu vực:</td>
                <td>
                    <asp:DropDownList ID="ddlCity" runat="server">
                        <asp:ListItem Value="Hanoi">Hà Nội</asp:ListItem>
                        <asp:ListItem Value="Danang">Đà Nẵng</asp:ListItem>
                        <asp:ListItem Value="Hochiminh">Hồ Chí Minh</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>

            <tr>
                <td>Trạng thái</td>
                <td>
                    <asp:DropDownList ID="ddlStatus" runat="server">
                        <asp:ListItem Value="1">Thành công</asp:ListItem>
                        <asp:ListItem Value="-1">Thất bại</asp:ListItem>
                        <asp:ListItem Value="0">Đang xử lý</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td>SP tìm kiếm</td>
                <td>
                    <asp:DropDownList ID="ddlSPName" runat="server">
                        <asp:ListItem Value="SP_ListTrans_1">SP_ListTrans_1</asp:ListItem>
                        <asp:ListItem Value="SP_ListTrans_2">SP_ListTrans_2</asp:ListItem>
                        <asp:ListItem Value="SP_ListTrans_3">SP_ListTrans_3</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td></td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Tìm kiếm" OnClick="Button1_Click" /></td>
            </tr>
        </table>

    </form>
</body>
</html>
