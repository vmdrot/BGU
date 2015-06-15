<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BootstrapCheckBoxList.ascx.cs" Inherits="BGU.Web20.MiscItemsSite.Controls.BootstrapCheckBoxList" EnableViewState="true" %>
        <div class="col-xs-6">
            <h3 class="text-center"><asp:Literal runat="server" ID="h3">Checkbox list</asp:Literal></h3>
            <div class="well" style="max-height: 200px; overflow: auto; width: 500px;" runat="server" id="well">
        		<ul class="list-group checked-list-box" runat="server" id="ul">
<%--                  <li class="list-group-item">Cras justo odio</li>
                  <li class="list-group-item" data-checked="true">Dapibus ac facilisis in</li>
--%>            </ul>
            </div>
        </div>
        <script language="javascript" type="text/javascript">refreshAllBSCBLs();</script>
