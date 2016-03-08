<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="plan.aspx.cs" Inherits="spip.plan" MasterPageFile="~/Site1.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h4 class="text-left">Please Select a Goal</h4>
        <form id="form1" runat="server">
            <asp:GridView id="mygv" runat="server" CssClass="table table-hover table-striped" OnRowDataBound="mygv_RowDataBound" AutoGenerateColumns="False" GridLines="None">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="Goal" />
                    <asp:BoundField DataField="title" HeaderText="Description" />
                </Columns>
                <RowStyle CssClass="click-row" />
            </asp:GridView>
            
            <asp:Label ID="lblInfo" runat="server" Text="Label" Visible="false"></asp:Label>
           

        </form>
        <script>
            $(".click-row").click(function () {
                window.document.location = $(this).data("href");
            });
        </script>

</asp:Content>
