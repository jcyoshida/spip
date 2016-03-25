<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="spip.admin" MasterPageFile="~/Site1.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:LinkButton ID="btnNew" runat="server" CssClass="btn btn-success" OnClick="btnNew_Click">
        <span class="glyphicon glyphicon-pencil"></span> Edit Goals
    </asp:LinkButton>
</asp:Content>