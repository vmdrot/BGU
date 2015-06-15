<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BankInfoEditControl2.ascx.cs" Inherits="BGU.Web20.MiscItemsSite.Controls.BankInfoEditControl2" %>
<%@ Register TagPrefix="uc" TagName="BootstrapTextEditBasic" Src="~/Controls/BootstrapTextEditBasic.ascx" %>
<%@ Register TagPrefix="uc" TagName="BootstrapDropDownBasic" Src="~/Controls/BootstrapDropDownBasic.ascx" %>
<%@ Register TagPrefix="uc" TagName="RcuKruLookupControl3" Src="~/Controls/RcuKruLookupControl3.ascx" %>

<div id="content">
    <ul id="tabs" class="nav nav-tabs" data-tabs="tabs" runat="server" enableviewstate="true">
        <li class="active" id="tbOne"><a href="#tbPnlOne" data-toggle="tab">Вибрати</a></li>
        <li id="tbTwo"><a href="#tbPnlTwo" data-toggle="tab">Увести</a></li>
    </ul>
    <div id="my-tab-content" class="tab-content">
        <div class="tab-pane active" id="tbPnlOne">
          <div class="panel panel-primary">
            <div class="panel-heading">
              <h3 class="panel-title">Обрати банк з довідника</h3>
            </div>
            <div class="panel-body">
            <uc:RcuKruLookupControl3 ID="uabkcbx" runat="server" AutoPostBack="false" OnSelectedMFOChanged="uabkcbx_OnSelectedMFOChanged" />
            </div>
          </div>
        </div>
        <div class="tab-pane" id="tbPnlTwo">
          <div class="panel panel-success">
            <div class="panel-heading">
              <h3 class="panel-title">Увести банк (не існує в довіднику)</h3>
            </div>
            <div class="panel-body">
                <uc:BootstrapDropDownBasic ID="ddlCountry" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" LabelDisplayName="Країна" LabelDescription="Країна резидентності банку" />
                <uc:BootstrapTextEditBasic ID="edHeadMFO" runat="server" LabelDisplayName="МФО" LabelDescription="МФО" EditMaxLength="6" EditSize="6" EditWidth="20%" />
                <uc:BootstrapTextEditBasic ID="edRegistryNr" runat="server" LabelDisplayName="№ у реєстрі банків" LabelDescription="№ у реєстрі банків (лише для головних контор)" EditWidth="10%" />
                <uc:BootstrapTextEditBasic ID="edCode" runat="server" LabelDisplayName="Код банку" LabelDescription="Код банку (лише для головних контор)" EditWidth="10%" />
                <uc:BootstrapTextEditBasic ID="edName" runat="server" LabelDisplayName="Найменування банку" LabelDescription="Найменування банку (в оригіналі)" />
                <uc:BootstrapTextEditBasic ID="edNameUkr" runat="server" LabelDisplayName="Найменування банку (українською)" LabelDescription="Найменування банку(українською); заповнюється для банків, де оригінальна назва не українською." />
                <uc:BootstrapTextEditBasic ID="edSWIFTBIC" runat="server" LabelDisplayName="SWIFT адреса" LabelDescription="Див. http://www.swift.com/bsl/" />
            </div>
          </div>
        </div>
    </div>
    <asp:HiddenField runat="server" ID="hdATb" />
</div>


<script type="text/javascript">
    jQuery(document).ready(function ($) {
        $('#<%=tabs.ClientID%>').tab();
    });
</script>    



