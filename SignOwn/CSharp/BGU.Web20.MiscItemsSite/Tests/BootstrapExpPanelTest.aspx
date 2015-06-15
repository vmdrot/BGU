<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BootstrapExpPanelTest.aspx.cs" Inherits="BGU.Web20.MiscItemsSite.Tests.BootstrapExpPanelTest" %>
<%@ Register TagPrefix="uc" TagName="BootstrapExpandablePanel" Src="~/Controls/BootstrapExpandablePanel.ascx" %>
<%@ Register TagPrefix="uc" TagName="BootstrapTextEditBasic" Src="~/Controls/BootstrapTextEditBasic.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpht1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphh" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpht2" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphm" runat="server">
<table width="40%">
<tr>
<td>
<%--<div class="panel-group" id="accordion">--%>
<uc:BootstrapExpandablePanel ID="bep1" runat="server" Caption="Загальні критерії пошуку">
<Template>
    <uc:BootstrapTextEditBasic ID="edOne" runat="server" LabelDisplayName="№ у реєстрі банків" LabelDescription="№ у реєстрі банків (лише для головних контор)" EditWidth="10%" />
    <uc:BootstrapTextEditBasic ID="ed2" runat="server" LabelDisplayName="№ у реєстрі банків" LabelDescription="№ у реєстрі банків (лише для головних контор)" EditWidth="10%" />
    <uc:BootstrapTextEditBasic ID="ed3" runat="server" LabelDisplayName="№ у реєстрі банків" LabelDescription="№ у реєстрі банків (лише для головних контор)" EditWidth="10%" />
    <uc:BootstrapTextEditBasic ID="ed4" runat="server" LabelDisplayName="№ у реєстрі банків" LabelDescription="№ у реєстрі банків (лише для головних контор)" EditWidth="10%" />
    <uc:BootstrapTextEditBasic ID="ed5" runat="server" LabelDisplayName="№ у реєстрі банків" LabelDescription="№ у реєстрі банків (лише для головних контор)" EditWidth="10%" />
    <uc:BootstrapTextEditBasic ID="ed6" runat="server" LabelDisplayName="№ у реєстрі банків" LabelDescription="№ у реєстрі банків (лише для головних контор)" EditWidth="10%" />
</Template>
</uc:BootstrapExpandablePanel>
<%--</div>--%>
</td>
</tr>
</table>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphf" runat="server">
</asp:Content>
