﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="planc.aspx.cs" Inherits="spip.planc" MasterPageFile="~/Site1.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <fieldset disabled>
            <div class="form-group">
                <asp:label for="disabledTextInput" id="lbldti" runat="server"></asp:label>
                <asp:TextBox ID="disabledTextInput" class="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:label for="disabledTextInput2" id="lbldti2" runat="server"></asp:label>
                <asp:TextBox ID="disabledTextInput2" class="form-control" TextMode="MultiLine" Rows="5" runat="server"></asp:TextBox>
            </div>
        </fieldset>
    <h4 class="text-left">Please Select a Strategy:</h4>

                <asp:GridView id="mygv" runat="server" CssClass="table table-hover table-striped" OnRowDataBound="mygv_RowDataBound" AutoGenerateColumns="False" GridLines="None">
                <Columns>
                    <asp:BoundField DataField="stratNum" HeaderText="Strategy" />
                    <asp:BoundField DataField="stratDesc" HeaderText="Description" />
                    <asp:BoundField DataField="timelines" HeaderText="Timelines" DataFormatString="{0:MM/dd/yyyy}" />
                </Columns>
                <RowStyle CssClass="click-row" />
            </asp:GridView>
    <asp:Label ID="lblInfo" runat="server" Text="Label" Visible="false"></asp:Label>
                    <script>
            $(".click-row").click(function () {
                window.document.location = $(this).data("href");
            });
        </script>

</asp:Content>
