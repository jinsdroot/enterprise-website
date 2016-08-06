<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyInformationDetail.aspx.cs"
    Inherits="jsbestop.Web.Manager.CpInformationManager.CompanyInformationDetail" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/detail.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/Utility.js"></script>
    <script src="../js/jquery-1.7.2.js" type="text/javascript"></script>
    <script src="../../ueditor/ueditor.config.js" type="text/javascript"></script>
    <script src="../../ueditor/ueditor.all.min.js" type="text/javascript"></script>
    <script src="../../ueditor/lang/zh-cn/zh-cn.js" type="text/javascript"></script>
    <script type="text/javascript">
        var UEDITOR_HOME_URL = "./ueditor/"; //从项目的根目录开始
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="sm1" runat="Server" EnablePageMethods="true" />
    <table width="98%">
        <tr>
            <td width="98%" align="center">
                <div class="percent">
                    <div id="nav">
                        <div class="nav_left">
                            <asp:Label ID="lblNav" Text="公司信息详细" runat="Server" /></div>
                        <div class="nav_right">
                        </div>
                    </div>
                    <table border="0" cellpadding="0" cellspacing="1" class="tbl_form">
                        <tr>
                            <td class="td_label" style="width: 13%; height: 25px;">
                                是否为英文：
                            </td>
                            <td class="td_ctrl" width="80%" align="left">
                                <asp:RadioButton ID="rbtnIsChinese" runat="server" Text="中文" GroupName="IsEnglishLa"
                                    Checked="true" />
                                <asp:RadioButton ID="rbtnIsEnglish" runat="server" Text="英文" GroupName="IsEnglishLa" />
                            </td>
                        </tr>
                        <tr>
                            <td class="td_label" style="width: 13%; height: 25px;">
                                * 公司信息类别：
                            </td>
                            <td class="td_ctrl" width="80%" align="left">
                                <asp:DropDownList ID="ddlCompanyInforType" CssClass="input_ctrl" runat="server" Width="210px"
                                    Height="20px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="td_label" style="width: 13%; height: 25px;">
                                公司信息内容：
                            </td>
                            <td class="td_ctrl" width="80%" align="left">
                                <script id="editor" type="text/plain" style="width: 1024px; height: 500px;"></script>
                            </td>
                        </tr>
                        <tr>
                            <asp:HiddenField ID="txtContent" runat="server" />
                            <td class="td_label" style="width: 13%; height: 25px;">
                                备注：
                            </td>
                            <td class="td_ctrl" width="80%" align="left">
                                <asp:TextBox ID="txtRemarks" runat="server" CssClass="input_ctrl" TextMode="MultiLine"
                                    Width="60%" Height="150px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="td_label" style="height: 25px;">
                                <asp:Label ID="lblAddName" runat="server" Text=""></asp:Label>
                                <asp:Label ID="lblAddTime" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table border="0" cellpadding="0" cellspacing="0" class="tbl_form" width="90%">
                        <tr>
                            <td style="background: #fff; text-align: left; padding-left: 150px; padding-top: 10px;
                                padding-bottom: 10px;" colspan="2">
                                <asp:Button ID="btnSubmit" runat="Server" CssClass="btn" Text="保存信息" OnClientClick="return checkUI();"
                                    OnClick="btnSubmit_Click" />&nbsp;&nbsp;
                                <input type="button" class="btn" value="返回列表" onclick="javascript:window.location.href='CompanyInformationList.aspx';" />
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        //实例化编辑器
        var ue = baidu.editor.ui.Editor();
        ue.render('editor');
        function getContent() {
            document.getElementById("txtContent").value = ue.getContent();
        }
        function setContent() {
            var val = document.getElementById("txtContent").value;
            ue.setContent(val);
        }
        $(document).ready(function () {
            $("#btnSubmit").click(function () {
                getContent();
            });
            ue.ready(function () {
                setContent();
            })
        });
    </script>
    </form>
</body>
</html>
