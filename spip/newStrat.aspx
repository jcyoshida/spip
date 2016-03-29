<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="newStrat.aspx.cs" Inherits="spip.newStrat" MasterPageFile="~/Site1.Master" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-8">
            <div class="form-group">
                <asp:Label ID="goalLbl" runat="server"><strong>GOAL #:</strong></asp:Label>
                <asp:TextBox ID="goalTxt" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="objLbl" runat="server"><strong>OBJECTIVE #:</strong></asp:Label>
                <asp:TextBox ID="objTxt" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="stratLbl" runat="server"><strong>STRATEGY #:</strong></asp:Label>
                <asp:TextBox ID="stratTxt" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="descLbl" runat="server"><strong>STRATEGY DESCRIPTION:</strong></asp:Label>
                <asp:TextBox ID="descTxt" CssClass="form-control" runat="server" TextMode="MultiLine" Rows="5"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="timeLbl" runat="server"><strong>TIMELINE:</strong></asp:Label>
                <div class="input-group">
                    <span class="input-group-addon"><img id="cal" src="Content/images/Calendar-icon.png" height="20" width="20" /></span>
                    <asp:TextBox ID="timeTxt" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-md-2">
            <h4>Instructions:</h4>
            <ol>
                <li>Enter the Goal for which the Strategy will belong.</li>
                <li>Enter the Objective for which the Strategy will belong.</li>
                <li>Enter the Strategy Number.</li>
                <li>Enter the Strategy Description.</li>
                <li>Enter the Strategy's Timeline.</li>
            </ol>
        </div>
    </div>

    <asp:LinkButton ID="btn_save" runat="server" CssClass="btn btn-primary" OnClick="btn_save_Click">
        <span class="glyphicon glyphicon-floppy-disk"></span> Save Strategy
    </asp:LinkButton>
    <asp:Label ID="lblInfo" runat="server" Text="Label" Visible="false"></asp:Label>
    <script>
        $("[id$=timeTxt").datepicker();
        $("[id$=cal]").click(function () {
            $("[id$=timeTxt]").datepicker('show');
        });
    </script>
</asp:Content>