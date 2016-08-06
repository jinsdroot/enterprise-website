<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cpAddress.aspx.cs" Inherits="jsbestop.Web.Manager.AddressManager.cpAddress" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/detail.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/Utility.js"></script>
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
                            <asp:Label ID="lblNav" Text="公司地址详细信息" runat="Server" /></div>
                        <div class="nav_right">
                        </div>
                    </div>
                    <%--  <asp:Label ID="lblChina" runat="server">--%>
                    <table border="0" cellpadding="0" cellspacing="1" class="tbl_form">
                        <tr>
                            <td class="td_label" style="width: 13%; height: 25px;">
                                是否为英文：
                            </td>
                            <td class="td_ctrl" width="80%" align="left">
                                <asp:RadioButton ID="rbtnIsChinese" runat="server" Text="中文" GroupName="IsEnglishLa"
                                    Checked="true" AutoPostBack="true" OnCheckedChanged="rbtnIsChinese_CheckedChanged" />
                                <asp:RadioButton ID="rbtnIsEnglish" runat="server" Text="英文" GroupName="IsEnglishLa"
                                    AutoPostBack="true" OnCheckedChanged="rbtnIsChinese_CheckedChanged" />
                            </td>
                        </tr>
                        <tr>
                            <td class="td_label" style="width: 13%; height: 25px;">
                                公司名称：
                            </td>
                            <td class="td_ctrl" width="80%" align="left">
                                <asp:TextBox ID="txtConCompany" runat="server" CssClass="input_ctrl" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="td_label" style="width: 13%; height: 25px;">
                                办公地址：
                            </td>
                            <td class="td_ctrl" width="80%" align="left">
                                <asp:TextBox ID="txtConAddress" runat="server" CssClass="input_ctrl" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="td_label" style="width: 13%; height: 25px;">
                                电话：
                            </td>
                            <td class="td_ctrl" width="80%" style="height: 25px" align="left">
                                <asp:TextBox ID="txtConPhone" runat="server" CssClass="input_ctrl" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="td_label" style="width: 13%; height: 25px;">
                                手机：
                            </td>
                            <td class="td_ctrl" width="80%" style="height: 25px" align="left">
                                <asp:TextBox ID="txtConTel" runat="server" CssClass="input_ctrl" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="td_label" style="width: 13%; height: 25px;">
                                QQ：
                            </td>
                            <td class="td_ctrl" width="80%" style="height: 25px" align="left">
                                <asp:TextBox ID="txtConFax" runat="server" CssClass="input_ctrl" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="td_label" style="width: 13%; height: 25px;">
                                邮件Email：
                            </td>
                            <td class="td_ctrl" width="80%" style="height: 25px" align="left">
                                <asp:TextBox ID="txtConEmail" runat="server" CssClass="input_ctrl" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="td_label" style="width: 13%; height: 25px;">
                                网址：
                            </td>
                            <td class="td_ctrl" width="80%" style="height: 25px" align="left">
                                <asp:TextBox ID="txtConWebsite" runat="server" CssClass="input_ctrl" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="td_label" style="width: 13%; height: 25px;">
                                联系人：
                            </td>
                            <td class="td_ctrl" width="80%" style="height: 25px" align="left">
                                <asp:TextBox ID="txtConName" runat="server" CssClass="input_ctrl" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="td_label" style="width: 13%; height: 25px;">
                                热线：
                            </td>
                            <td class="td_ctrl" width="80%" style="height: 25px" align="left">
                                <asp:TextBox ID="txtHotPhone" runat="server" CssClass="input_ctrl" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="td_label" style="width: 13%; height: 25px;">
                                手机站电话联系号码：
                            </td>
                            <td class="td_ctrl" width="80%" style="height: 25px" align="left">
                                <asp:TextBox ID="phoneTxtTel" runat="server" CssClass="input_ctrl" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="td_label" style="width: 13%; height: 25px;">
                                手机站发送短信号码：
                            </td>
                            <td class="td_ctrl" width="80%" style="height: 25px" align="left">
                                <asp:TextBox ID="phoneTxtSms" runat="server" CssClass="input_ctrl" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="td_label" style="width: 13%; height: 25px;">
                                百度统计：
                            </td>
                            <td class="td_ctrl" width="80%" style="height: 25px" align="left">
                                <asp:TextBox ID="txtBaiDuCount" runat="server" CssClass="input_ctrl" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="td_label" style="width: 13%; height: 25px;">
                                备注：
                            </td>
                            <td class="td_ctrl" width="80%" style="height: 25px" align="left">
                                <asp:TextBox ID="txtRemarks" runat="server" CssClass="input_ctrl" TextMode="MultiLine"
                                    Width="390px" Height="150px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <%--</asp:Label>--%>
                    <asp:Label ID="lblEnglish" runat="server" Visible="false">
                        <table border="0" cellpadding="0" cellspacing="1" class="tbl_form">
                            <tr>
                                <td class="td_label" style="width: 13%; height: 25px;">
                                    公司名称：
                                </td>
                                <td class="td_ctrl" width="80%" align="left">
                                    <asp:TextBox ID="txtConCompanyen" runat="server" CssClass="input_ctrl" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="td_label" style="width: 13%; height: 25px;">
                                    办公地址：
                                </td>
                                <td class="td_ctrl" width="80%" align="left">
                                    <asp:TextBox ID="txtConAddressen" runat="server" CssClass="input_ctrl" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="td_label" style="width: 13%; height: 25px;">
                                    电话：
                                </td>
                                <td class="td_ctrl" width="80%" style="height: 25px" align="left">
                                    <asp:TextBox ID="txtConPhoneen" runat="server" CssClass="input_ctrl" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="td_label" style="width: 13%; height: 25px;">
                                    手机：
                                </td>
                                <td class="td_ctrl" width="80%" style="height: 25px" align="left">
                                    <asp:TextBox ID="txtConTelen" runat="server" CssClass="input_ctrl" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="td_label" style="width: 13%; height: 25px;">
                                    QQ：
                                </td>
                                <td class="td_ctrl" width="80%" style="height: 25px" align="left">
                                    <asp:TextBox ID="txtConFaxen" runat="server" CssClass="input_ctrl" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="td_label" style="width: 13%; height: 25px;">
                                    邮件Email：
                                </td>
                                <td class="td_ctrl" width="80%" style="height: 25px" align="left">
                                    <asp:TextBox ID="txtConEmailen" runat="server" CssClass="input_ctrl" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="td_label" style="width: 13%; height: 25px;">
                                    网址：
                                </td>
                                <td class="td_ctrl" width="80%" style="height: 25px" align="left">
                                    <asp:TextBox ID="txtConWebsiteen" runat="server" CssClass="input_ctrl" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="td_label" style="width: 13%; height: 25px;">
                                    联系人：
                                </td>
                                <td class="td_ctrl" width="80%" style="height: 25px" align="left">
                                    <asp:TextBox ID="txtConNameen" runat="server" CssClass="input_ctrl" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="td_label" style="width: 13%; height: 25px;">
                                    热线：
                                </td>
                                <td class="td_ctrl" width="80%" style="height: 25px" align="left">
                                    <asp:TextBox ID="txtHotPhoneen" runat="server" CssClass="input_ctrl" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="td_label" style="width: 13%; height: 25px;">
                                    备注：
                                </td>
                                <td class="td_ctrl" width="80%" style="height: 25px" align="left">
                                    <asp:TextBox ID="txtRemarksen" runat="server" CssClass="input_ctrl" TextMode="MultiLine"
                                        Width="390px" Height="150px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </asp:Label>
                    <table border="0" cellpadding="0" cellspacing="0" class="tbl_form" width="90%">
                        <tr>
                            <td style="background: #fff; text-align: left; padding-left: 150px; padding-top: 10px;
                                padding-bottom: 10px;" colspan="2">
                                <asp:Button ID="btnSubmit" runat="Server" CssClass="btn" Text="保存信息" OnClick="btnSubmit_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
