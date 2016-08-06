<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cpSuccessStoriesDetail.aspx.cs"
    Inherits="jsbestop.Web.Manager.SuccessStoriesManager.cpSuccessStoriesDetail" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE8" />
    <link href="../css/detail.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/Utility.js"></script>
    <script src="../js/jquery-1.7.2.js" type="text/javascript"></script>
    <script src="../../ueditor/ueditor.config.js" type="text/javascript"></script>
    <script src="../../ueditor/ueditor.all.min.js" type="text/javascript"></script>
    <script src="../../ueditor/lang/zh-cn/zh-cn.js" type="text/javascript"></script>
    <script type="text/javascript">
        var UEDITOR_HOME_URL = "./ueditor/"; //从项目的根目录开始
    </script>
    <script type="text/javascript">
        function checkUI() {

            return true;
        }    			
    </script>
    <script type="text/javascript">
        $(function () {
            showCont();
            $("input[name=IsPhone]").click(function () {
                showCont();
            });
        });
        function showCont() {
            switch ($("input[name=IsPhone]:checked").attr("id")) {
                case "rbthasPhone":
                    //alert("one");
                    $("#sellInfo2").show();
                    $("#sellInfo1").show();
                    break;
                case "rbtnoPhone":
                    $("#sellInfo1").hide();
                    $("#sellInfo2").hide();
                    break;
                default:
                    break;
            }
        }
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
                            <asp:Label ID="lblNav" Text="成功案例详细" runat="Server" /></div>
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
                                是否有手机站：
                            </td>
                            <td class="td_ctrl" width="80%" align="left">
                                <asp:RadioButton ID="rbthasPhone" runat="server" Text="有" GroupName="IsPhone" />
                                <asp:RadioButton ID="rbtnoPhone" runat="server" Text="无" GroupName="IsPhone" Checked="true" />
                            </td>
                        </tr>
                        <tr style="display: none" id="sellInfo1">
                            <td class="td_label" style="width: 13%; height: 25px;">
                                缩略图宽：
                            </td>
                            <td class="td_ctrl" width="80%" align="left">
                                <asp:TextBox ID="imgWidth" runat="server" CssClass="input_ctrl" Width="210px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="display: none" id="sellInfo2">
                            <td class="td_label" style="width: 13%; height: 25px;">
                                缩略图高：
                            </td>
                            <td class="td_ctrl" width="80%" align="left">
                                <asp:TextBox ID="imgHeight" runat="server" CssClass="input_ctrl" Width="210px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="td_label" style="width: 13%; height: 25px;">
                                * 成功案例类别：
                            </td>
                            <td class="td_ctrl" width="80%" align="left">
                                <asp:DropDownList ID="ddlSuccessStoriesType" CssClass="input_ctrl" runat="server"
                                    Width="210px" Height="20px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="td_label" style="width: 13%; height: 25px;">
                                * 成功案例标题：
                            </td>
                            <td class="td_ctrl" width="80%" align="left">
                                <asp:TextBox ID="txtNewsTitle" runat="server" CssClass="input_ctrl" Width="210px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="td_label" style="width: 13%; height: 25px;">
                                成功案例图片：
                            </td>
                            <td class="td_ctrl" width="80%" align="left">
                                <asp:FileUpload ID="UploadImg" runat="server" />
                                <asp:Image ID="Image1" runat="server" Width="200px" Height="135px" />
                            </td>
                        </tr>
                        <tr>
                            <td class="td_label" style="width: 13%; height: 25px;">
                                成功案例内容：
                            </td>
                            <td class="td_ctrl" width="80%" align="left">
                                <script id="editor" type="text/plain" style="width: 1024px; height: 500px;"></script>
                                <asp:HiddenField ID="txtContent" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="td_label" style="width: 13%; height: 25px;">
                                排序：
                            </td>
                            <td class="td_ctrl" width="80%" align="left">
                                <asp:TextBox ID="txtAutoSort" onKeyUp="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')"
                                    runat="server" Width="230px" Text="0" CssClass="input_ctrl"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
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
                                <input type="button" class="btn" value="返回列表" onclick="javascript:window.location.href='cpSuccessStoriesList.aspx';" />
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
