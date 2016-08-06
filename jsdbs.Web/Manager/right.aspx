<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="right.aspx.cs" Inherits="jsbestop.Web.Manager.right" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="css/houtai.css" rel="stylesheet" type="text/css" />
	<style type="text/css">
	.nava
{
	color:#666;
	text-decoration:none;
	border: 0px solid;
}
	</style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="houtai_home">
	    <%-- <div class="houtai_title"> </div>--%>
		 <div class="houtai_mid">
		 
<br>
<br>
<TABLE cellSpacing=0 cellPadding=0 width=98% align=center border=0>
  <TBODY>
    <TR> 
      <TD background="images/titlebar_left.gif">&nbsp;</TD>
      <TD width="100%" background=images/windowbar_background.gif align="left"><img src="images/nofollow.gif" width="15"  height="11" >≡≡≡ <font color="#0066FF"><strong>管理员登录成功！</strong></font> ≡≡≡&nbsp;</TD>
      <TD>&nbsp;</TD>
    </TR>
  </TBODY>
</TABLE>
<table width="98%" border="0" align="center" cellpadding="0" cellspacing="1" 

bgcolor="#A0A0A0">
  <tr> 
    <td bgcolor="#FFFFFF"><table width="100%" height="30" border="0" align="center" 

cellpadding="0" cellspacing="0">
        <tr> 
          <td width="38%" align="right"><img src="images/right.jpg" width="50"  

height="50"></td>
          <td width="62%" align="left"><font color="#FF0000">&nbsp;恭喜，您已经以<b>“管理员”</b>身份成功登录

！</font></td>
        </tr>
      </table></td>
  </tr>
</table>
<TABLE height=20 cellSpacing=0 cellPadding=0 width=98% align=center border=0>
  <TBODY>
    <TR> 
      <TD>&nbsp;</TD>
      <TD width="100%" 
    background=images/windowbar_reversed_background.gif></TD>
      <TD>&nbsp;</TD>
    </TR>
  </TBODY>
</TABLE>
<br>
<TABLE cellSpacing=0 cellPadding=0 width=98% align=center border=0>
  <TBODY>
    <TR> 
      <TD background="images/titlebar_left.gif">&nbsp;</TD>
      <TD width="100%" background=images/windowbar_background.gif align="left"><img src="images/nofollow.gif" width="15" height="11">≡≡≡ 
        <font color="#0066FF"><strong>产品服务&nbsp;&nbsp;&nbsp;&amp;&nbsp;&nbsp;&nbsp;支持</strong></font> ≡≡≡&nbsp;</TD>
      <TD>&nbsp;</TD>
    </TR>
  </TBODY>
</TABLE>
<table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr> 
    <td height="19" valign="top" bgcolor="#A0A0A0"> <table width="100%" border="0" 

cellspacing="1" cellpadding="0">
        <tr bgcolor="#FFFFFF"> 
          <td width="36%" rowspan="4" align="center" bgcolor="#FFFFFF"><a 

href="#" target="_blank"><img src="images/logo.jpg" alt="零点起步" 
                  border="0" style="height: 150px; width: 300px"></a><br> 
          </td>
          <td width="64%" height="25" bgcolor="#FFFFFF" align="left">&nbsp;&nbsp;&nbsp;
          电话：&nbsp;0510-**********&nbsp;&nbsp;&nbsp;或&nbsp;&nbsp;&nbsp; *********</td>
        </tr>
        <tr bgcolor="#FFFFFF"> 
          <td width="64%" height="25" bgcolor="#F9F9F9" align="left">&nbsp;&nbsp;&nbsp;&nbsp;传真：&nbsp;0510-**********</td>
        </tr>
        <tr bgcolor="#FFFFFF"> 
          <td width="64%" height="25" bgcolor="#FFFFFF" align="left">
              　地址：无锡职院****</td>
        </tr>
        <tr bgcolor="#FFFFFF"> 
          <td height="25" bgcolor="#F9F9F9" align="left">　网址：<a href="#" target="_blank"><u>**************</u></a>

          <asp:TextBox ID="txtName" runat="server" CssClass="input_ctrl" Width="210px"></asp:TextBox>
          <asp:Button ID="btnSubmit" Text="设置外链"  runat="server" OnClick="btnSubmit_Click"/>
          
          </td>
        </tr>
      </table></td>
  </tr>
</table>
<table height=20 cellSpacing=0 cellPadding=0 width=98% align=center border=0>
  <tbody>
    <tr> 
      <td>&nbsp;</td>
    </tr>
  </tbody>
</table>
<table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td height="24"><font color="#FF0000"><strong>注意：</strong></font>为了帐户的安全起见，

如果您在登录后的20分钟内不进行任何操作，帐户将转为未登入状态，不能对管理系统进行任何操作。如需操作，请<strong>重新登入</strong>！</td>
  </tr>
</table>
    <div class="jishu" style="text-align:center;">技术支持：<a href="#" class="nava" title="零点起步"  target="_blank">零点起步 All Rights Reserved</a></div>
</div>
</form>
</body>
</html>
