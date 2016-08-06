<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cpMessageDetail.aspx.cs"
    Inherits="jsbestop.Web.Manager.MessageManager.cpMessageDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/detail.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/Utility.js"></script>
    <script type="text/javascript">
        function checkUI() {
            var txtTitle = document.getElementById("<%=txtMesReplayDetail.ClientID %>");
            if (txtTitle != null) {
                if (txtTitle.value.trim() == "") {
                    alert("请输入回复内容");
                    txtTitle.focus();
                    return false;
                }
            }

            return true;
        }		
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="sm1" runat="Server" EnablePageMethods="true" />
        <table width="98%">
            <tr>
                <td width="98%" align="center">
                    <div class="percent">
                        <div id="nav">
                            <div class="nav_left">
                                <asp:Label ID="lblNav" Text="在线留言详细信息" runat="Server" /></div>
                            <div class="nav_right">
                            </div>
                        </div>
                        
                        <table border="0" cellpadding="0" cellspacing="1" class="tbl_form">
                            <tr>
                                <td class="td_label" style="width: 13%; height: 25px;">
                                    留言内容：
                                </td>
                                <td class="td_ctrl" width="80%" align="left">
                                    <asp:Label ID="lblMesDetail" runat="Server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="td_label" style="width: 13%; height: 25px;">
                                    留言人：
                                </td>
                                <td class="td_ctrl" width="80%" align="left">
                                    <asp:Label ID="lblMesName" runat="Server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="td_label" style="width: 13%; height: 25px;">
                                    联系电话：
                                </td>
                                <td class="td_ctrl" width="80%" align="left">
                                    <asp:Label ID="lblMesPhone" runat="Server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="td_label" style="width: 13%; height: 25px;">
                                    联系手机：
                                </td>
                                <td class="td_ctrl" width="80%" align="left">
                                    <asp:Label ID="lblMesTel" runat="Server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="td_label" style="width: 13%; height: 25px;">
                                    邮箱：
                                </td>
                                <td class="td_ctrl" width="80%" align="left">
                                    <asp:Label ID="lblMesEmail" runat="Server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="td_label" style="width: 13%; height: 25px;">
                                    联系地址：
                                </td>
                                <td class="td_ctrl" width="80%" align="left">
                                    <asp:Label ID="lblMesAdd" runat="Server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="td_label" style="width: 13%; height: 25px;">
                                    回访时间：
                                </td>
                                <td class="td_ctrl" width="80%" align="left">
                                    <asp:Label ID="lblMesReTime" runat="Server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="td_label" style="width: 13%; height: 25px;">
                                    留言时间：
                                </td>
                                <td class="td_ctrl" width="80%" align="left">
                                    <asp:Label ID="lblMessageDate" runat="Server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="td_label" style="width: 13%; height: 25px;">
                                    是否回复：
                                </td>
                                <td class="td_ctrl" width="80%" align="left">
                                    <asp:Label ID="lblIsRead" runat="Server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="td_label" style="width: 13%; height: 25px;">
                                </td>
                                <td class="td_ctrl" width="80%" align="left">
                                </td>
                            </tr>
                            <tr>
                                <td class="td_label" style="width: 13%; height: 25px;">
                                    回复内容：
                                </td>
                                <td class="td_ctrl" width="80%" align="left">
                                    <asp:TextBox ID="txtMesReplayDetail" runat="server" Width="530" Height="180" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <table border="0" cellpadding="0" cellspacing="0" class="tbl_form" width="90%">
                            <tr>
                                <td style="background: #fff; text-align: left; padding-left: 150px; padding-top: 10px;
                                    padding-bottom: 10px;" colspan="2">
                                    <asp:Button ID="btnSubmit" runat="Server" CssClass="btn" Text="保存信息" OnClientClick="return checkUI();"
                                        OnClick="btnSubmit_Click" />&nbsp;&nbsp;
                                    <input type="button" class="btn" value="返回列表" onclick="javascript:window.location.href='cpMessageList.aspx';" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
