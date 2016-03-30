<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="users.aspx.cs" Inherits="spip.users" MasterPageFile="~/Site1.Master" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-12 col-xs-12 col-sm-12">
    <asp:LinkButton ID="btnNew" runat="server" CssClass="btn btn-success" OnClick="btnNew_Click" >
        <span class="glyphicon glyphicon-plus-sign"></span> Create New User
    </asp:LinkButton>
    <br /><br />
    <asp:SqlDataSource
        ProviderName="MySql.Data.MySqlClient"
        ID="sql1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:strategic_planConnectionString %>"
        SelectCommand="SELECT * FROM user ORDER BY lastName ASC"
        UpdateCommand="UPDATE user SET empNo=@empNo, lastName=@lastName, firstName=@firstName, title=@title, lead=@lead, mgr=@mgr, admin=@admin WHERE id=@id"
        DeleteCommand="DELETE FROM user WHERE id=@id">
    </asp:SqlDataSource>
    <asp:GridView ID="gvGoals" runat="server" DataSourceID="sql1"  
    AutoGenerateColumns="False" CssClass="table table-striped table-hover" GridLines="None" DataKeyNames="id" RowStyle-Wrap="false" >
        <Columns>
            <asp:BoundField datafield="empNo" headertext="Employee #" />
            <asp:BoundField DataField="lastName" HeaderText="Last Name" />
            <asp:BoundField DataField="firstName" HeaderText="First Name" /> 
            <asp:BoundField DataField="title" HeaderText="Title" />
            <asp:BoundField DataField="lead" HeaderText="Project Lead" />
            <asp:BoundField DataField="mgr" HeaderText="Project Manager" />
            <asp:BoundField DataField="admin" HeaderText="Admin Access" />
            
            <asp:TemplateField ShowHeader="false">
                <ItemTemplate>
                    <asp:Button ID="EditBtn" runat="server" CommandName="Edit" Text="Edit" />
                    <asp:Button ID="DeleteBtn" runat="server" CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete?');" Text="Delete" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Button ID="btnUpdate" runat="server" CommandName="Update" Text="Update" />
                    <asp:Button ID="btnCancel" runat="server" CommandName="Cancel" Text="Cancel" />
                </EditItemTemplate>
            </asp:TemplateField>
<%--            <asp:HyperLinkField DataNavigateUrlFields="id" DataNavigateUrlFormatString="editUser.aspx?r={0}" Text="<span class='glyphicon glyphicon-pencil'></span> Edit" />--%>
        </Columns>
    </asp:GridView>
            </div>
        </div>
    <script>
        //$('table').responsiveTable();
    </script>
</asp:Content>