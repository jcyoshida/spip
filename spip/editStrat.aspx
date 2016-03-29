<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editStrat.aspx.cs" Inherits="spip.editStrat" MasterPageFile="~/Site1.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-group">
        <asp:Label ID="gidLbl" runat="server"><strong>GOAL #:</strong></asp:Label>
        <asp:TextBox ID="gidTxt" CssClass="form-control" runat="server"></asp:TextBox>
        <br /><br />
        <asp:Label ID="objLbl" runat="server"><strong>OBJECTIVE #:</strong></asp:Label>
        <asp:TextBox ID="objTxt" CssClass="form-control" runat="server"></asp:TextBox>
        <br /><br />
        <asp:Label ID="sNumLbl" runat="server"><strong>STRATEGY #:</strong></asp:Label>
        <asp:TextBox ID="sNumTxt" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
        <br /><br />
        <asp:Label ID="sDesc" runat="server"><strong>STRATEGY DESCRIPTION:</strong></asp:Label>
        <asp:TextBox ID="sDescTxt" CssClass="form-control" runat="server" TextMode="MultiLine" Rows="5"></asp:TextBox>
        <br /><br />
        <asp:Label ID="tLbl" runat="server"><strong>TIMELINE:</strong></asp:Label>
        <div class="input-group">
            <span class="input-group-addon"><img id="cal" src="Content/images/Calendar-icon.png" height="20" width="20" /></span>
            <asp:TextBox ID="tTxt" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        
    </div>
    <asp:LinkButton ID="btn_save" runat="server" CssClass="btn btn-primary" OnClick="btn_save_Click">
        <span class="glyphicon glyphicon-floppy-disk"></span> Save Changes
    </asp:LinkButton>
    <asp:Label ID="lblInfo" runat="server" Text="Label" Visible="false"></asp:Label>
    <script>
        $("[id$=tTxt]").datepicker();
        $("[id$=cal]").click(function () {
            $("[id$=tTxt]").datepicker('show');
        });
    </script>
</asp:Content>