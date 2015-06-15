<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RcuKruLookupControl2.ascx.cs" Inherits="BGU.Web20.MiscItemsSite.Controls.RcuKruLookupControl2" %>

<%--<%@ Register Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" Assembly="DevExpress.Web.ASPxEditors.v10.2" %>

<dx:ASPxComboBox ID="cbx" runat="server" EnableCallbackMode="true" CallbackPageSize="10"
    IncrementalFilteringMode="Contains" ValueType="System.Int32" ValueField="MFO"
    OnItemsRequestedByFilterCondition="cbx_OnItemsRequestedByFilterCondition"
    OnItemRequestedByValue="cbx_OnItemRequestedByValue" TextFormatString="{1} ({0})"
    Width="600px" Height="30px" DropDownStyle="DropDownList" SkinID="Aqua">
    <Columns>
        <dx:ListBoxColumn FieldName="MFO" Width="10%"/>
        <dx:ListBoxColumn FieldName="KNB" Width="90%"/>
    </Columns>
</dx:ASPxComboBox>
--%>

				<div class="control-group">
					<label for="<%=ddlBk.ClientID%>">Банк:</label>
                    <asp:DropDownList ID="ddlBk" runat="server" placeholder="Назва чи МФО банку...">
                    </asp:DropDownList>
				</div>

