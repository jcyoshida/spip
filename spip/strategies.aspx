<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="strategies.aspx.cs" Inherits="spip.strategies" MasterPageFile="~/Site1.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:LinkButton ID="btnNew" runat="server" CssClass="btn btn-primary" OnClick="btnNew_Click">
        <span class="glyphicon glyphicon-plus-sign"></span> Create New Strategy
    </asp:LinkButton>
    <br /><br />
        <asp:SqlDataSource
            ProviderName="MySql.Data.MySqlClient"
            ID="sourceGID" runat="server" 
            ConnectionString="<%$ ConnectionStrings:strategic_planConnectionString %>"
            SelectCommand="SELECT DISTINCT gid FROM objective">
        </asp:SqlDataSource>
        <asp:SqlDataSource
            ProviderName="MySql.Data.MySqlClient"
            ID="sourceOID" runat="server" 
            ConnectionString="<%$ ConnectionStrings:strategic_planConnectionString %>"
            SelectCommand="SELECT objNum FROM objective WHERE gid = @gid">
            <SelectParameters>
                <asp:ControlParameter Name="gid" ControlID="lstObj" PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource
            ProviderName="MySql.Data.MySqlClient"
            ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:strategic_planConnectionString %>"
            SelectCommand="SELECT id,stratNum,stratDesc,timelines FROM strategy WHERE objID = @objNum ">
            <SelectParameters>
                <asp:ControlParameter Name="objNum" ControlID="lstObjs" PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>
        <div class="form-group">
            <asp:Label ID="forlstObj" runat="server"><strong>1. SELECT A GOAL:</strong></asp:Label>
           <asp:DropDownList ID="lstObj" runat="server" DataSourceID="sourceGID" DataTextField="gid" DataValueField="gid" AutoPostBack="true"></asp:DropDownList>
        </div>
        <div class="form-group">
            <asp:Label ID="Label1" runat="server"><strong>2. SELECT AN OBJECTIVE:</strong></asp:Label>
           <asp:DropDownList ID="lstObjs" runat="server" DataSourceID="sourceOID" DataTextField="objNum" DataValueField="objNum" AutoPostBack="true"></asp:DropDownList>
        </div>
        <asp:GridView ID="gvGoals" runat="server" DataSourceID="SqlDataSource1"  
            AutoGenerateColumns="False" CssClass="table table-striped table-hover" GridLines="None" DataKeyNames="id">
            <Columns>
                <asp:BoundField datafield="stratNum" headertext="Strategy" />
                <asp:BoundField DataField="stratDesc" HeaderText="Strategy Description" />
                <asp:BoundField DataField="timelines" HeaderText="Timelines" DataFormatString="{0:d}" HtmlEncode="false" />        
                <asp:HyperLinkField DataNavigateUrlFields="id" DataNavigateUrlFormatString="editStrat.aspx?r={0}" Text="<span class='glyphicon glyphicon-pencil'></span> Edit" />
            </Columns>
        </asp:GridView>
</asp:Content>