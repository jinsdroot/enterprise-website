<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wfAdminUserDetails.aspx.cs" Inherits="jsbestop.Web.Manager.SysManager.wfAdminUserDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="head1" runat="server">
    <title></title>
    <link href="../css/detail.css" rel="stylesheet" type="text/css" /> 
	<script type="text/javascript" src="../js/Utility.js"></script>
	
    <script type="text/javascript">
    	function checkUI() {
    		var sm = document.getElementById("<%=txtAccount.ClientID %>");
    		if (sm != null) {
    			if (sm.value.trim() == "") {
    				alert("请输入登录帐号");
    				return false;
    			}

    		}

    		var pwd = document.getElementById("<%=txtPwd.ClientID %>");
    		var pwdAgain = document.getElementById("<%=txtPwdAgain.ClientID %>");
    		if (pwd != null && pwdAgain != null) {
    			if (pwd.value.trim() != pwdAgain.value.trim()) {
    				alert("两次输入密码不一致");
    				return false;
    			}
			}
			
    		return true;
    	}


    			
	</script>
    
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="sm1" runat="Server" EnablePageMethods="true" /> 

	<table width="98%"><tr><td width="98%" align="center">
	<div class="percent">
        <div id="nav">
            <div class="nav_left">
                <asp:Label ID="lblNav" Text="管理员详细信息" runat="Server" /></div>
            <div class="nav_right">
            </div>
        </div>
        <table border="0" cellpadding="0" cellspacing="1" class="tbl_form">
            
            <tr>
                <td class="td_label" style="width: 13%; height: 25px;">
                  *  登&nbsp;&nbsp;录&nbsp;&nbsp;帐&nbsp;&nbsp;号：
                </td>
                <td class="td_ctrl" width="80%"  align="left">
                    <asp:TextBox ID="txtAccount" runat="server" CssClass="input_ctrl" Width="300px"></asp:TextBox>
					
                </td>
            </tr>
            
            <tr>
                <td class="td_label" style="width: 13%; height: 25px;">
                    姓&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;名：
                </td>
                <td class="td_ctrl" width="80%" style="height: 25px" align="left">
                    <asp:TextBox ID="txtTrueName" runat="server" CssClass="input_ctrl" Width="300px"></asp:TextBox>
                    
                </td>
            </tr>
            
             <tr>
                <td class="td_label" style="width: 13%; height: 25px;">
                    密&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;码：
                </td>
                <td class="td_ctrl" width="80%" style="height: 25px" align="left">
                    <asp:TextBox ID="txtPwd" runat="server" CssClass="input_ctrl" Width="300px" TextMode="Password"></asp:TextBox>
                    &nbsp;&nbsp;<asp:Label ID="lblPwd" runat="server"></asp:Label>
                </td>
            </tr>
			 <tr>
                <td class="td_label" style="width: 13%; height: 25px;">
                    确&nbsp;&nbsp;认&nbsp;&nbsp;密&nbsp;&nbsp;码：
                </td>
                <td class="td_ctrl" width="80%" style="height: 25px" align="left">
                    <asp:TextBox ID="txtPwdAgain" runat="server" CssClass="input_ctrl" TextMode="Password" Width="300px"></asp:TextBox>
                    &nbsp;&nbsp;<asp:Label ID="lblAgin" runat="server"></asp:Label>
                </td>
            </tr>
                     
        </table>
        
        
        
        <table border="0" cellpadding="0" cellspacing="0" class="tbl_form"  width="90%">
        <tr><td style="background: #fff; text-align: left; padding-left:150px; padding-top:10px; padding-bottom:10px; " colspan="2">
        <asp:Button ID="btnSubmit" runat="Server" CssClass="btn" Text="保存信息" 
				OnClientClick="return checkUI();" onclick="btnSubmit_Click" />&nbsp;&nbsp;
        <input type="button" class="btn" value="返回列表" onclick="javascript:window.location.href='wfAdminUser.aspx';" />
                </td></tr>
        </table>

				</div>
	</td></tr></table>
    </form>
</body>
</html>
