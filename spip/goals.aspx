<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="goals.aspx.cs" Inherits="spip.goals" MasterPageFile="~/Site1.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <asp:GridView ID="gvGoals" runat="server" DataSourceID="SqlDataSource1"  
            AutoGenerateColumns="False" CssClass="table table-striped table-hover" GridLines="None" DataKeyNames="id">
            <Columns>
                <asp:BoundField datafield="id" headertext="Goal" />
                <asp:BoundField DataField="title" HeaderText="Goal Description" />
                <asp:BoundField DataField="desc" HeaderText="Other Description" />        
                <asp:HyperLinkField DataNavigateUrlFields="id" DataNavigateUrlFormatString="editGoal.aspx?r={0}" Text="<span class='glyphicon glyphicon-pencil'></span> Edit" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource
            ProviderName="MySql.Data.MySqlClient"
            ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:strategic_planConnectionString %>"
            SelectCommand="SELECT * FROM goal">

        </asp:SqlDataSource>
</asp:Content>