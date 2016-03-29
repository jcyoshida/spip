<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editObj.aspx.cs" Inherits="spip.editObj" MasterPageFile="~/Site1.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-group">
        <asp:label for="disabledTextInput" id="lbldti" runat="server"></asp:label>
        <br /><br />
        <asp:Label ID="objDescLbl" runat="server"><strong>Title:</strong></asp:Label>
        <asp:TextBox ID="objDescTxt" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
        <br /><br />
        <asp:Label ID="objLongDescLbl" runat="server"><strong>Other Description:</strong></asp:Label>
        <asp:TextBox ID="objLongDescTxt" CssClass="form-control" runat="server" TextMode="MultiLine" Rows="5"></asp:TextBox>
    </div>
    <asp:LinkButton ID="btn_save" runat="server" CssClass="btn btn-primary" OnClick="btn_save_Click">
        <span class="glyphicon glyphicon-floppy-disk"></span> Save Changes
    </asp:LinkButton>
    <asp:Label ID="lblInfo" runat="server" Text="Label" Visible="false"></asp:Label>
</asp:Content>