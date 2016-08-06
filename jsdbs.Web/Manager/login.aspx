<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="jsbestop.Web.Manager.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="css/login.css" />
   <script type="text/javascript">
   function form_reset() {
   document.getElementById("form1").reset();
   }
   function checkform() 
   {
        var oAccount = document.getElementById("txtAccount");
        var oPwd = document.getElementById("txtPwd");
        var oyzm = document.getElementById("chkcode");
        if(oAccount.value.length<1)
        {
            alert("请输入用户名");
            oAccount.focus();
            return false;   
        }
        if(oPwd.value.length<1)
        {
             alert("请输入密码");
             oPwd.focus();
             return false; 
        }
       if(oyzm.value.length<1)
       {
            alert("请输入验证码");
            oyzm.focus();
            return false;  
       }
       return true;       
   }
   </script> 
</head>
<body>
    <form id="form1" runat="server">
   <div id="container">
        <div id="top">
        </div>
        <div id="center">
            <div id="center_left">
            </div>
            <div id="center_middle">
                <div class="user">
                    用户名：
                    <asp:TextBox ID="txtAccount" runat="Server"  />
                </div>
                <div class="user">
                    密&nbsp;&nbsp;码：
                    <asp:TextBox ID="txtPwd" TextMode="Password" runat="Server" />
                </div>
                <div class="chknumber">
                    <div style="float:left; width:100px;">
                        验证码：
                        <asp:TextBox ID="chkcode" CssClass="chknumber_input" MaxLength="4" runat="Server" />                        
                    </div>
                    <div style="float:left;width:55px; padding-top:1px;"><img src="../ValidateCode.aspx?w=58&h=20" onclick="this.src=this.src+'&?'" width="52" height="20" alt="看不清验证码,请单击" style="cursor: hand;" /></div>                    
                </div>
            </div>
            <div id="center_middle_right">
            </div>
            <div id="center_submit">
                <div class="button">
                    <asp:ImageButton ID="btnSubmit" ImageUrl="~/Manager/images/dl.gif" Width="57" Height="20" runat="Server" OnClick="btnSubmit_Click"/> 
                </div>
                <div class="button">
                    <img src="images/cz.gif" width="57" height="20" onclick="form_reset()">
                </div>
            </div>
            <div id="center_right">
            </div>
        </div>
        <div id="footer">
        </div>
       </div>  
    </form>
</body>
</html>
