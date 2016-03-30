<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="newUser.aspx.cs" Inherits="spip.newUser" MasterPageFile="~/Site1.Master" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div class="form-group">
                <asp:Label ID="empNoLbl" runat="server"><strong>EMPLOYEE #:</strong></asp:Label>
                <asp:TextBox ID="empNoTxt" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="fNameLbl" runat="server"><strong>FIRST NAME:</strong></asp:Label>
                <asp:TextBox ID="fNameTxt" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="lNameLbl" runat="server"><strong>LAST NAME:</strong></asp:Label>
                <asp:TextBox ID="lNameTxt" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="titleLbl" runat="server"><strong>TITLE:</strong></asp:Label>
                <asp:TextBox ID="titleTxt" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="leadLbl" runat="server"><strong>LEAD:</strong></asp:Label>
                <asp:RadioButtonList ID="leadRdo" runat="server">
                    <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                    <asp:ListItem Text="No" Value="N"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="form-group">
                <asp:Label ID="mgrLbl" runat="server"><strong>PROJECT MANAGER:</strong></asp:Label>
                <asp:RadioButtonList ID="mgrRdo" runat="server">
                    <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                    <asp:ListItem Text="No" Value="N"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="form-group">
                <asp:Label ID="adminLbl" runat="server"><strong>ADMIN ACCESS:</strong></asp:Label>
                <asp:RadioButtonList ID="adminRDO" runat="server">
                    <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                    <asp:ListItem Text="No" Value="N"></asp:ListItem>
                </asp:RadioButtonList>
            </div>

    <asp:LinkButton ID="btn_save" runat="server" CssClass="btn btn-primary" onclick="btn_save_Click">
        <span class="glyphicon glyphicon-floppy-disk"></span> Save User
    </asp:LinkButton>
    <asp:Label ID="lblInfo" runat="server" Text="Label" Visible="false"></asp:Label>

</asp:Content>