<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BootstrapTextEditBasic.ascx.cs" Inherits="BGU.Web20.MiscItemsSite.Controls.BootstrapTextEditBasic" %>
<div class="form-group has-success">
  <label runat="server" class="control-label" for="<%=ed.ClientID%>" id="lbl">Display name</label>
  <input runat="server" type="text" class="form-control" id="ed">
  <em runat="server" class="initialism" id="descr">Description</em>
</div>
