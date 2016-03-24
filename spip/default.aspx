<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="spip._default"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LA County Probation Department - Strategic Plan 2015-2018</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/themes/base/all.css" rel="stylesheet" />
</head>
<script src="scripts/jquery-2.2.1.min.js"></script>
<script src="scripts/bootstrap.min.js"></script>
<script src="scripts/jquery-ui-1.11.4.min.js"></script>
<body>
        <div class="container">
        <div class="well">
            <img src="Content/images/ProbBadgeSmall.png" class="img-responsive pull-left" alt="Probation Logo" />
            <h1 class="text-center">PROBATION'S STRATEGIC PLAN 2015-2018</h1>
        </div>
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
            </body>
</html>
