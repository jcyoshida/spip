<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editGoal.aspx.cs" Inherits="spip.editGoal" MasterPageFile="~/Site1.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-group">
        <asp:label for="disabledTextInput" id="lbldti" runat="server"></asp:label>
        <br />
        <asp:Label ID="goalDescLbl" runat="server">Title:</asp:Label>
        <asp:TextBox ID="goalDesc" CssClass="form-control" runat="server"></asp:TextBox>
        <asp:TextBox ID="goalLongDesc" CssClass="form-control" runat="server" TextMode="MultiLine" Rows="5"></asp:TextBox>
    </div>
    
    <asp:Label ID="lblInfo" runat="server" Text="Label" Visible="false"></asp:Label>
</asp:Content>