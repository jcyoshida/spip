﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="objectives.aspx.cs" Inherits="spip.objectives" MasterPageFile="~/Site1.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <asp:SqlDataSource
            ProviderName="MySql.Data.MySqlClient"
            ID="sourceGID" runat="server" 
            ConnectionString="<%$ ConnectionStrings:strategic_planConnectionString %>"
            SelectCommand="SELECT DISTINCT gid FROM objective">
        </asp:SqlDataSource>
        <asp:SqlDataSource
            ProviderName="MySql.Data.MySqlClient"
            ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:strategic_planConnectionString %>"
            SelectCommand="SELECT id,objNum,objDesc,objDesc2 FROM objective WHERE gid = @gid">
            <SelectParameters>
                <asp:ControlParameter Name="gid" ControlID="lstObj" PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>
        <div class="form-group">
            <asp:Label ID="forlstObj" runat="server"><strong>SELECT OBJECTIVES FOR WHICH GOAL:</strong></asp:Label>
           <asp:DropDownList ID="lstObj" runat="server" DataSourceID="sourceGID" DataTextField="gid" DataValueField="gid" AutoPostBack="true"></asp:DropDownList>
        </div>
        <asp:GridView ID="gvGoals" runat="server" DataSourceID="SqlDataSource1"  
            AutoGenerateColumns="False" CssClass="table table-striped table-hover" GridLines="None" DataKeyNames="id">
            <Columns>
                <asp:BoundField datafield="objNum" headertext="Objective" />
                <asp:BoundField DataField="objDesc" HeaderText="Objective Description" />
                <asp:BoundField DataField="objDesc2" HeaderText="Other Description" />        
                <asp:HyperLinkField DataNavigateUrlFields="id" DataNavigateUrlFormatString="editObj.aspx?r={0}" Text="<span class='glyphicon glyphicon-pencil'></span> Edit" />
            </Columns>
        </asp:GridView>
</asp:Content>