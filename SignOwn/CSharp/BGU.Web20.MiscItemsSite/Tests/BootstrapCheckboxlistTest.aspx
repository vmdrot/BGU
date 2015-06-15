<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BootstrapCheckboxlistTest.aspx.cs" Inherits="BGU.Web20.MiscItemsSite.Tests.BootstrapCheckboxlistTest" %>
<%@ Register TagPrefix="uc" TagName="BootstrapCheckBoxList" Src="~/Controls/BootstrapCheckBoxList.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpht1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphh" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpht2" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphm" runat="server">
<uc:BootstrapCheckBoxList ID="cbl" runat="server" DataTextMember="Value" DataValueMember="EnumValue" EnableViewState="true" Width="400px" MaxHeight="200px" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphf" runat="server">
</asp:Content>
