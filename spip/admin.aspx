<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="spip.admin" MasterPageFile="~/Site1.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-2">
            <asp:LinkButton ID="btnNew" runat="server" CssClass="btn btn-primary btn-block" OnClick="btnNew_Click">
                <span class="glyphicon glyphicon-pencil"></span> Edit Goals
            </asp:LinkButton>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-2">
            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-primary btn-block" OnClick="btnObj_Click">
                <span class="glyphicon glyphicon-pencil"></span> Edit Objectives
            </asp:LinkButton>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-2">
            <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn btn-primary btn-block" OnClick="LinkButton2_Click">
                <span class="glyphicon glyphicon-pencil"></span> Add/Edit Strategies
            </asp:LinkButton>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-2">
            <asp:LinkButton ID="LinkButton3" runat="server" CssClass="btn btn-primary btn-block" OnClick="LinkButton3_Click">
                <span class="glyphicon glyphicon-user"></span> Add/Edit Users
            </asp:LinkButton>
        </div>
    </div>
</asp:Content>