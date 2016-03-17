<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editPlan.aspx.cs" Inherits="spip.editPlan" MasterPageFile="~/Site1.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <fieldset disabled>
            <div class="form-group">
                <asp:label for="disabledTextInput" id="lbldti" runat="server"></asp:label>
                <asp:TextBox ID="disabledTextInput" class="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:label for="disabledTextInput2" id="lbldti2" runat="server"></asp:label>
                <asp:TextBox ID="disabledTextInput2" class="form-control" TextMode="MultiLine" Rows="5" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:label for="disabledTextInput3" id="lbldti3" runat="server"></asp:label>
                <asp:TextBox ID="disabledTextInput3" class="form-control" TextMode="MultiLine" Rows="5" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:label for="disabledTextInput4" id="lbldti4" runat="server" Font-Bold="True" ForeColor="Red" Text="Timeline:"></asp:label>
                <asp:TextBox ID="disabledTextInput4" class="form-control" runat="server"></asp:TextBox>
            </div>
        </fieldset>
        <div class="form-group">
            <asp:Label for="lstLeads" ID="lblLeads" runat="server">LEAD</asp:Label>
            <asp:DropDownList ID="lstLeads" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
        <div class="form-group">
            <asp:label for="brief_desc" runat="server">BRIEF DESCRIPTION</asp:label>
            <asp:textbox cssclass="form-control" TextMode="MultiLine" rows="5" id="brief_desc" runat="server"></asp:textbox>
        </div>
        <div class="form-group">
            <asp:label for="actionPlan" runat="server">ACTION PLAN (MAJOR TASKS)</asp:label>
            <asp:textbox cssclass="form-control" TextMode="multiline" rows="5" id="actionPlan" runat="server"></asp:textbox>
        </div>
        <div class="form-group has-feedback">
            <asp:label for="imp_date" runat="server">IMPLEMENTATION DATE</asp:label>
            <asp:textbox cssclass="form-control" id="imp_date" runat="server"></asp:textbox>
            <img class="form-control-feedback" src="Content/images/Calendar-icon.png" style="width:25px; height: 25px;" />
        </div>
        <div class="form-group has-feedback">
            <asp:label for="ant_date" runat="server">ANTICIPATED COMPLETION DATE</asp:label>
            <asp:textbox cssclass="form-control" id="ant_date" runat="server"></asp:textbox>
            <img class="form-control-feedback" src="Content/images/Calendar-icon.png" style="width:25px; height: 25px;" />
        </div>
        
        <div class="form-group">
            <asp:label for="ap_status" runat="server">ACTION PLAN STATUS</asp:label>
            <asp:dropdownlist cssclass="form-control" id="ap_status" runat="server">
                <asp:listitem value="0" Text="0% - Task Initiated"></asp:listitem>
                <asp:listitem value="25" Text="25%"></asp:listitem>
                <asp:listitem value="50" Text="50%"></asp:listitem>
                <asp:listitem value="75" Text="75%"></asp:listitem>
                <asp:listitem value="100" Text="Completed - 100%"></asp:listitem>
            </asp:dropdownlist>
        </div>
        <div class="form-group">
            <asp:label for="op" runat="server">OVERALL PROGRESS</asp:label>
            <asp:textbox cssclass="form-control" textmode="MultiLine" rows="5" id="op" runat="server"></asp:textbox>
        </div>
        <div class="form-group">
            <asp:label for="challenges" runat="server">CHALLENGES TO IMPLEMENTING ACTION PLAN AND POSSIBLE SOLUTIONS</asp:label>
            <asp:textbox cssclass="form-control" TextMode="MultiLine" rows="5" id="challenges" runat="server"></asp:textbox>
        </div>
        <div class="form-group">
            <asp:label for="method" runat="server">METHOD OF EVALUATING/MONITORING THE OUTCOME OF THE STRATEGY</asp:label>
            <asp:textbox cssclass="form-control" TextMode="MultiLine" rows="5" id="method" runat="server"></asp:textbox>
        </div>
        <asp:LinkButton ID="btn_save" runat="server" CssClass="btn btn-primary" OnClick="btn_save_Click">
            <span class="glyphicon glyphicon-floppy-disk"></span> Save
        </asp:LinkButton>
        <br /><br />



    <asp:Label ID="lblInfo" runat="server" Text="Label" Visible="false"></asp:Label>
<script>
    $(".click-row").click(function () {
        window.document.location = $(this).data("href");
    });
    $("[id$=imp_date], [id$=ant_date]").datepicker();
</script>

</asp:Content>
