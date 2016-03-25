<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editGoal.aspx.cs" Inherits="spip.editGoal" MasterPageFile="~/Site1.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-group">
        <asp:label for="disabledTextInput" id="lbldti" runat="server"></asp:label>
        <br /><br />
        <asp:Label ID="goalDescLbl" runat="server"><strong>Title:</strong></asp:Label>
        <asp:TextBox ID="goalDescTxt" CssClass="form-control" runat="server"></asp:TextBox>
        <br /><br />
        <asp:Label ID="goalLongDescLbl" runat="server"><strong>Other Description:</strong></asp:Label>
        <asp:TextBox ID="goalLongDescTxt" CssClass="form-control" runat="server" TextMode="MultiLine" Rows="5"></asp:TextBox>
    </div>
    <asp:LinkButton ID="btn_save" runat="server" CssClass="btn btn-primary" OnClick="btn_save_Click">
        <span class="glyphicon glyphicon-floppy-disk"></span> Save Changes
    </asp:LinkButton>
    <asp:Label ID="lblInfo" runat="server" Text="Label" Visible="false"></asp:Label>
</asp:Content>