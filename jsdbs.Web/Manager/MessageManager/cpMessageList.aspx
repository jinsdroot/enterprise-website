<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cpMessageList.aspx.cs"
    Inherits="jsbestop.Web.Manager.MessageManager.cpMessageList" %>

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

        function Insert(id, op) {
            var msg = '确定要推荐该条记录吗?';
            if (confirm(msg) == true) {
                PageMethods.OperateRecords(id, op, OnSelCompleted);
            }
            else return;
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
    <div>
        <asp:ScriptManager ID="sm" EnablePageMethods="true" runat="Server" />
        <table width="98%">
            <tr>
                <td width="98%" align="center">
                    <div class="percent">
                        <div class="nav">
                            <div class="nav_left">
                                在线留言列表</div>
                            <div class="nav_right">
                            </div>
                        </div>
                        <div id="search">
                            <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                <tr>
                                    <td class="search_label" style="width: 150px;">
                                        留言标题：
                                    </td>
                                    <td class="search_ctrl" style="width: 210px;">
                                        <asp:TextBox ID="txtMessageName" CssClass="input_ctrl" Width="200px" runat="server" />
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
                                <a href="#" onclick="CheckAll(this,'<%=grid.ClientID %>');">全选</a>&nbsp;‖&nbsp;
                                <a href="#" onclick="InverseSel('<%=grid.ClientID %>');">反选</a>&nbsp;‖&nbsp; <a href="javascript:checkSel('删除','<%=grid.ClientID %>',7);">
                                    批量删除</a>&nbsp;‖&nbsp;
                            </div>
                        </div>
                        <asp:GridView ID="grid" AutoGenerateColumns="False" CellSpacing="1" CellPadding="0"
                            EmptyDataText="未找到相关数据" CssClass="tbl_form" Width="100%" DataKeyNames="Id" runat="Server">
                            <Columns>
                                <asp:TemplateField HeaderText="选择">
                                    <HeaderStyle CssClass="header" Width="5%" />
                                    <ItemStyle CssClass="cbitem" Width="5%" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cb" runat="Server" /><asp:HiddenField ID="ohidId" runat="Server"
                                            Value='<%#Eval("Id") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="留言类型">
                                    <ItemTemplate>
                                        <%#GetStrByByteLength(Eval("MesTitle").ToString(), 20, true)%>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="header" Width="25%" />
                                    <ItemStyle CssClass="lblitem" Width="25%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="留言人">
                                    <HeaderStyle CssClass="header" Width="10%" />
                                    <ItemStyle CssClass="cbitem" Width="10%" />
                                    <ItemTemplate>
                                        <%#Eval("MesName")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="联系方式">
                                    <HeaderStyle CssClass="header" Width="10%" />
                                    <ItemStyle CssClass="cbitem" Width="10%" />
                                    <ItemTemplate>
                                        <%#Eval("MesTelPhone")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="留言时间">
                                    <HeaderStyle CssClass="header" Width="10%" />
                                    <ItemStyle CssClass="cbitem" Width="10%" />
                                    <ItemTemplate>
                                        <%#Eval("MesDate", "{0:yyyy-MM-dd}")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="是否回复">
                                    <HeaderStyle CssClass="header" Width="8%" />
                                    <ItemStyle CssClass="cbitem" Width="8%" />
                                    <ItemTemplate>
                                        <%#Convert.ToInt32(Eval("IsReply")) == 1 ? "是" : "否"%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="操作">
                                    <HeaderStyle CssClass="header" Width="5%" />
                                    <ItemStyle CssClass="cbitem" Width="5%" />
                                    <ItemTemplate>
                                        <span class="edit">[<a href="cpMessageDetail.aspx?id=<%#Eval("Id") %>">查看</a>]</span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="删除">
                                    <HeaderStyle CssClass="header" Width="5%" />
                                    <ItemStyle CssClass="cbitem" Width="5%" />
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
    </div>
    </form>
</body>
</html>
