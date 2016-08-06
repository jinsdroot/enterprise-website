<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cpProductTypeList.aspx.cs"
    Inherits="jsbestop.Web.Manager.ProductManager.cpProductTypeList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/list.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/cbSel.js"></script>
    <script src="../js/jquery-1.7.2.js" type="text/javascript"></script>
    <script src="../js/common.js" type="text/javascript"></script>
    <script type="text/javascript">
        function checkSel(t, id, op) //批量操作提示
        {
            var checked = -1;
            var oGridView = document.getElementById(id);
            var Ids = '';
            for (i = 0; i < oGridView.rows.length; i++) {
                obj = oGridView.rows[i].cells[0].getElementsByTagName("INPUT")[0];
                oId = oGridView.rows[i].cells[0].getElementsByTagName("INPUT")[1];
                if (obj != null) {
                    if (obj.checked) {
                        checked++;
                        Ids = Ids + oId.value + ",";
                    }
                }
            }
            if (checked > -1) {
                var msg = '确定要' + t + '选中记录吗?';
                if (confirm(msg) == true) {
                    Ids = Ids.substring(0, Ids.length - 1);
                    PageMethods.OperateRecords(Ids, op, OnSelCompleted);
                }
                else {
                    return;
                }
            }
            else {
                alert('请先选择要' + t + '的记录！');
                return;
            }
        }
        function OnSelCompleted(data) {
            if (data.length > 0) {
                alert(data);
            }
            else {
                alert("操作成功");
            }
            __doPostBack("lnkBack", "");
        }
        function hid(id, op) {
            var msg = '确定要删除该条记录吗?该操作不能恢复';
            if (confirm(msg) == true) {
                PageMethods.OperateRecords(id, op, OnSelCompleted);
            }
            else return;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="sm" EnablePageMethods="true" runat="Server" />
    <table width="98%">
        <tr>
            <td width="98%" align="center">
                <div class="percent">
                    <div class="nav">
                        <div class="nav_left">
                            产品一级类别列表</div>
                        <div class="nav_right">
                        </div>
                    </div>
                    <div id="search">
                        <table border="0" cellspacing="0" cellpadding="0" width="100%">
                            <tr>
                                <td class="search_label" style="width: 150px;">
                                    是否为英文：
                                </td>
                                <td class="search_ctrl" style="width: 210px;">
                                    <asp:RadioButton ID="rbtnIsChinese" runat="server" Text="中文" GroupName="IsEnglishLa"
                                        Checked="true" OnCheckedChanged="IsEnglishLa_Change" />
                                    <asp:RadioButton ID="rbtnIsEnglish" runat="server" Text="英文" GroupName="IsEnglishLa"
                                        OnCheckedChanged="IsEnglishLa_Change" />
                                </td>
                                <td class="search_label" style="width: 150px;">
                                    产品类别：
                                </td>
                                <td class="search_ctrl" style="width: 210px;">
                                    <asp:TextBox ID="txtProductType" CssClass="input_ctrl" Width="230px" runat="server" />
                                </td>
                                <td style="padding: 3px;" colspan="2" align="left">
                                    <asp:ImageButton ID="btnSearch" ImageUrl="~/Manager/images/search.gif" runat="Server"
                                        OnClick="imgSearch_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="nav">
                        <div class="menu_left">
                            <a href="#" onclick="CheckAll(this,'<%=grid_friendlink.ClientID %>');">全选</a>&nbsp;‖&nbsp;
                            <a href="#" onclick="InverseSel('<%=grid_friendlink.ClientID %>');">反选</a>&nbsp;‖&nbsp;
                            <a href="cpProductTypeDetail.aspx">添加</a>&nbsp;‖&nbsp; <a href="javascript:checkSel('删除','<%=grid_friendlink.ClientID %>',7);">
                                批量删除</a>&nbsp;‖&nbsp;
                        </div>
                    </div>
                    <asp:GridView ID="grid_friendlink" AutoGenerateColumns="False" CellSpacing="1" CellPadding="0"
                        EmptyDataText="未找到相关数据" CssClass="tbl_form" Width="100%" DataKeyNames="Id" runat="Server">
                        <Columns>
                            <asp:TemplateField HeaderText="选择">
                                <HeaderStyle CssClass="header" Width="5%" />
                                <ItemStyle CssClass="cbitem" Width="5%" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="cb" runat="Server" />
                                    <asp:HiddenField ID="ohidId" runat="Server" Value='<%#Eval("ID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="产品类别名称">
                                <ItemTemplate>
                                    <%#Eval("ProductTypeName")%>
                                </ItemTemplate>
                                <HeaderStyle CssClass="header" Width="45%" />
                                <ItemStyle CssClass="cbitem" Width="45%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="排序">
                                <ItemTemplate>
                                    <%#Eval("AutoSort")%>
                                </ItemTemplate>
                                <HeaderStyle CssClass="header" Width="5%" />
                                <ItemStyle CssClass="cbitem" Width="5%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="是否有二级目录">
                                <ItemTemplate>
                                    <%#Convert.ToInt32(Eval("IsHaveSecondTpye")) == 1 ? "是" : "否"%>
                                </ItemTemplate>
                                <HeaderStyle CssClass="header" Width="5%" />
                                <ItemStyle CssClass="cbitem" Width="5%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="修改">
                                <HeaderStyle CssClass="header" Width="10%" />
                                <ItemStyle CssClass="cbitem" Width="10%" />
                                <ItemTemplate>
                                    <span class="edit">[<a href="cpProductTypeDetail.aspx?id=<%#Eval("ID") %>">修改</a>]</span>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="删除">
                                <HeaderStyle CssClass="header" Width="10%" />
                                <ItemStyle CssClass="cbitem" Width="10%" />
                                <ItemTemplate>
                                    <span class="del">[<a href="#" onclick="javascript:hid('<%#Eval("Id") %>',7);">删除</a>]</span>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <uc1:PaginationCtrl ID="pager" PageSize="15" runat="Server" />
                    <asp:LinkButton ID="lnkBack" runat="server" OnClick="lnkBack_Click"></asp:LinkButton>
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
