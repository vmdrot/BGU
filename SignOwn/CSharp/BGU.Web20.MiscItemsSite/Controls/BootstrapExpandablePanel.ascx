<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BootstrapExpandablePanel.ascx.cs" Inherits="BGU.Web20.MiscItemsSite.Controls.BootstrapExpandablePanel" %>
        <div class="panel panel-default" id="pnl" runat="server">
            <div class="panel-heading">
                <h4 class="panel-title">
                    <a data-toggle="collapse" data-target="#<%=pnlBody.ClientID %>" href="#<%=pnlBody.ClientID %>"><asp:Literal ID="txt" runat="server">Caption</asp:Literal></a>
                </h4>
            </div>
            <div id="pnlBody" class="panel-collapse collapse in" runat="server">
                <div class="panel-body">
                <asp:Placeholder runat="server" ID="ph" />
                </div>
            </div>
        </div>
