<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GenericFinInstSearchCriteriaControl.ascx.cs" Inherits="BGU.Web20.MiscItemsSite.Controls.GenericFinInstSearchCriteriaControl" %>
<%@ Register TagPrefix="uc" TagName="BootstrapTextEditBasic" Src="~/Controls/BootstrapTextEditBasic.ascx" %>
<%@ Register TagPrefix="uc" TagName="RcuKruLookupControl3" Src="~/Controls/RcuKruLookupControl3.ascx" %>
<%@ Register TagPrefix="uc" TagName="BootstrapDropDownBasic" Src="~/Controls/BootstrapDropDownBasic.ascx" %>
<%@ Register TagPrefix="uc" TagName="BootstrapCheckBoxBasic" Src="~/Controls/BootstrapCheckBoxBasic.ascx" %>
<%@ Register TagPrefix="uc" TagName="BootstrapExpandablePanel" Src="~/Controls/BootstrapExpandablePanel.ascx" %>
<div class="panel-group" id="accordion">
<uc:BootstrapExpandablePanel ID="bep1" runat="server" Caption="Загальні критерії пошуку">
<Template>
 <uc:RcuKruLookupControl3 ID="uabkcbx" runat="server" AutoPostBack="false" OnSelectedMFOChanged="uabkcbx_OnSelectedMFOChanged" HeadOfficesOnly="true" SkipCategories="1,2,5,6" />
 <uc:BootstrapTextEditBasic ID="edName" runat="server" LabelDisplayName="Найменування банку" LabelDescription="Найменування банку (в оригіналі)" />
 </Template>
 </uc:BootstrapExpandablePanel>
<uc:BootstrapExpandablePanel ID="BootstrapExpandablePanel1" runat="server" Caption="Види,типи та статуси установ">
<Template>
        <asp:CheckBox ID="lcid_chkAll" runat="server" Text="(all)" />
            <webctrl:CheckBoxListEx ID="lcid" runat="server" EnableViewState="true" RepeatColumns="1"
                RepeatDirection="Vertical" RepeatLayout="Table" DataValueField="LCID" DataTextField="NativeName" ClientScriptUrl="/js/CheckBoxListEx.js">
            </webctrl:CheckBoxListEx>
            <%--<asp:CheckBoxList ID="lcid" runat="server" EnableViewState="true" RepeatColumns="5" RepeatDirection="Horizontal" RepeatLayout="Table" DataValueField="LCID" DataTextField="NativeName"></asp:CheckBoxList>--%>
            <%--<input type="button" value="Toggle 'Check all'" onclick="javascript:ToggleCheckAll();" />--%>
            <script language="javascript" type="text/javascript">
                function ToggleCheckAll() {
                    var clientId = '<%=CheckAllClientID %>';
                    var objChkAll = document.getElementById(clientId);
                    objChkAll.checked = !objChkAll.checked;
                }
            </script>

 </Template>
 </uc:BootstrapExpandablePanel>
<uc:BootstrapExpandablePanel ID="BootstrapExpandablePanel2" runat="server" Caption="Мізцезнаходження">
<Template>
 </Template>
 </uc:BootstrapExpandablePanel>
</div>
