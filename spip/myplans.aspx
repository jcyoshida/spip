<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="myplans.aspx.cs" Inherits="spip.myplans" MasterPageFile="~/Site1.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

    <asp:GridView ID="gvPlans" runat="server" DataSourceID="SqlDataSource1" ShowHeaderWhenEmpty="true" EmptyDataText="No action plans found." 
        AutoGenerateColumns="False" CssClass="table table-striped table-hover" GridLines="None" DataKeyNames="id">
        <Columns>
            <asp:BoundField datafield="gID" headertext="Goal" />
            <asp:BoundField DataField="objID" HeaderText="Objective" />
            <asp:BoundField DataField="stratID" HeaderText="Strategy" />        
            <asp:BoundField DataField="bDescTxt" HeaderText="Brief Description" />
            <asp:BoundField DataField="apTxt" HeaderText="Action Plan" />
            <asp:BoundField DataField="apStatus" HeaderText="Action Plan Status" />
            <asp:HyperLinkField DataNavigateUrlFields="id" DataNavigateUrlFormatString="editPlan.aspx?r={0}" Text="Edit" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource
        ProviderName="MySql.Data.MySqlClient"
        ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:strategic_planConnectionString %>"
        UpdateCommand="UPDATE master SET apTxt=@apTxt WHERE id=id">

    </asp:SqlDataSource>
    <asp:LinkButton ID="btnNew" runat="server" CssClass="btn btn-success" OnClick="btnNew_Click">
        <span class="glyphicon glyphicon-plus-sign"></span> Create New Action Plan
    </asp:LinkButton>
</asp:Content>