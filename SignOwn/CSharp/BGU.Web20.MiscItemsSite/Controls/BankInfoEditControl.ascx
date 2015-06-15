<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BankInfoEditControl.ascx.cs" Inherits="BGU.Web20.MiscItemsSite.Controls.BankInfoEditControl" %>
<%@ Register TagPrefix="uc" TagName="BootstrapTextEditBasic" Src="~/Controls/BootstrapTextEditBasic.ascx" %>
<%@ Register TagPrefix="uc" TagName="RcuKruLookupControl2" Src="~/Controls/RcuKruLookupControl2.ascx" %>
<%@ Register TagPrefix="uc" TagName="RcuKruLookupControl3" Src="~/Controls/RcuKruLookupControl3.ascx" %>
<%@ Register TagPrefix="uc" TagName="BootstrapDropDownBasic" Src="~/Controls/BootstrapDropDownBasic.ascx" %>

<div id="content">
    <ul id="tabs" class="nav nav-tabs" data-tabs="tabs" runat="server" enableviewstate="true">
        <li class="active" runat="server" id="tbOne"><a href="#<%=tbPnlOne.ClientID %>" data-toggle="tab">Вибрати</a></li>
        <li runat="server" id="tbTwo"><a href="#<%=tbPnlTwo.ClientID %>" data-toggle="tab">Увести</a></li>
    </ul>
    <div id="my-tab-content" class="tab-content">
        <div class="tab-pane active" id="tbPnlOne" runat="server">
          <div class="panel panel-primary">
            <div class="panel-heading">
              <h3 class="panel-title">Обрати банк з довідника</h3>
            </div>
            <div class="panel-body">
            <uc:RcuKruLookupControl3 ID="uabkcbx" runat="server" AutoPostBack="false" OnSelectedMFOChanged="uabkcbx_OnSelectedMFOChanged" HeadOfficesOnly="true" SkipCategories="1,2,5,6" />
            </div>
          </div>
        </div>
        <div class="tab-pane" id="tbPnlTwo" runat="server">
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


        $('a[data-toggle="tab"]').on('shown.bs.tab', function (e) {
            //alert('onshown');
            //alert(e.target);
            //alert($('#<%=hdATb.ClientID%>').outerHtml);
            $('#<%=hdATb.ClientID%>').val(e.target);

        })

    });

//    $(function () {
//        //for bootstrap 3 use 'shown.bs.tab' instead of 'shown' in the next line
//        $('a[data-toggle="tab"]').on('shown', function (e) {
//            //save the latest tab; use cookies if you like 'em better:
//            localStorage.setItem('lastTab', $(e.target).attr('id'));
//        });

//        //go to the latest tab, if it exists:
//        var lastTab = localStorage.getItem('lastTab');
//        if (lastTab) {
//            $('#' + lastTab).tab('show');
//        }
//    });
//</script>    



