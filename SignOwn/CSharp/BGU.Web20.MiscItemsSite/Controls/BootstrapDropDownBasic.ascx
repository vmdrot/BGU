<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BootstrapDropDownBasic.ascx.cs" Inherits="BGU.Web20.MiscItemsSite.Controls.BootstrapDropDownBasic" %>
				<div class="control-group">
					<label runat="server" for="<%=ddlBk.ClientID%>" id="lbl">...</label>
                    <asp:DropDownList ID="ddl" runat="server" placeholder="...">
                    </asp:DropDownList>
                    <em runat="server" class="initialism" id="descr">Description</em>
				</div>
				<script>
//                    var eventHandler = function(name) {
//    return function() {
//      alert(name);
//    };
//
//                    var <%=ddl.ClientID%>_ChangeHandler = function() {
//                        alert('in here');
//                    };
                    var <%=ddl.ClientID%>Js, $<%=ddl.ClientID%>Js;
				    $<%=ddl.ClientID%>Js = $('#<%=ddl.ClientID%>').selectize({
				        create: true,
				        sortField: {
				            field: 'text',
				            direction: 'asc'
				        },
				        dropdownParent: 'body',
				    });
				    <%=ddl.ClientID%>Js = $<%=ddl.ClientID%>[0].selectize;
                    //<%=ddl.ClientID%>Js.on('change',<%=ddl.ClientID%>_ChangeHandler); 

//                    var <%=ddl.ClientID%>Js, $<%=ddl.ClientID%>Js;
//				    $<%=ddl.ClientID%>Js = $('#<%=ddl.ClientID%>').selectize({
//				        create: true,
//				        sortField: {
//				            field: 'text',
//				            direction: 'asc'
//				        },
//				        dropdownParent: 'body',
////onChange        : eventHandler('onChange'),
////    onItemAdd       : eventHandler('onItemAdd'),
////    onItemRemove    : eventHandler('onItemRemove'),
////    onOptionAdd     : eventHandler('onOptionAdd'),
////    onOptionRemove  : eventHandler('onOptionRemove'),
////    onDropdownOpen  : eventHandler('onDropdownOpen'),
////    onDropdownClose : eventHandler('onDropdownClose'),
////    onFocus         : eventHandler('onFocus'),
////    onBlur          : eventHandler('onBlur'),
////    onInitialize    : eventHandler('onInitialize'),
////    //                        onChange        : <%=ddl.ClientID%>_ChangeHandler,
////                        onItemRemove    : <%=ddl.ClientID%>_ChangeHandler,


//				    });
//				    <%=ddl.ClientID%>Js = $<%=ddl.ClientID%>[0].selectize;
//                    <%=ddl.ClientID%>Js.on('change',<%=ddl.ClientID%>_ChangeHandler); 

				</script>
