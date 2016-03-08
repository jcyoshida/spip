<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="planb.aspx.cs" Inherits="spip.planb" MasterPageFile="~/Site1.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <form runat="server">
        <fieldset disabled>
            <div class="form-group">
                <asp:label for="disabledTextInput" id="lbldti" runat="server"></asp:label>
                <asp:TextBox ID="disabledTextInput" class="form-control" runat="server"></asp:TextBox>
            </div>
        </fieldset>
    <h4 class="text-left">Please Select an Objective</h4>

                <asp:GridView id="mygv" runat="server" CssClass="table table-hover table-striped" OnRowDataBound="mygv_RowDataBound" AutoGenerateColumns="False" GridLines="None">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="Objective" />
                    <asp:BoundField DataField="objDesc" HeaderText="Description" />
                </Columns>
                <RowStyle CssClass="click-row" />
            </asp:GridView>
        </form>
    <asp:Label ID="lblInfo" runat="server" Text="Label" Visible="false"></asp:Label>
                    <script>
            $(".click-row").click(function () {
                window.document.location = $(this).data("href");
            });
        </script>

</asp:Content>
