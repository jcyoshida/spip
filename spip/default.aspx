<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="spip._default" MasterPageFile="~/Site1.Master" %>


    <asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <p class="text-justify">Entering the following page is restricted and can only be accessed
        								by authorized personnel. If you need access, you'll need to request a username
                                        and password from ISB's Web Development Unit. If the given username and password 
                                        is not working, please contact ISB's Web Development Unit.</p>
        <form class="form-horizontal" runat="server">
            <div class="form-group">
                <label for="txtUsername" class="col-sm-2 control-label">Username:</label>
                    <div class="col-sm-2">
                        <asp:TextBox class="form-control" id="txtUsername" name="txtUsername" placeholder="eXXXXXX" runat="server" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtPassword" class="col-sm-2 control-label">Password:</label>
                    <div class="col-sm-2">
                        <asp:TextBox TextMode="password" class="form-control" id="txtPassword" name="txtPassword" placeholder="Hosted Password" runat="server" />
                    </div>
                </div>
                <div class="col-sm-4">
                <asp:Button ID="login" class="btn btn-primary pull-right" runat="server" Text="Login" OnClick="login_Click" />
                </div>
            <asp:Label runat="server" ID="lblPgStatus"></asp:Label>
            </form>  
    </asp:Content>

