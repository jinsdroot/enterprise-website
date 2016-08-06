<%@ Page Title="" Language="C#" MasterPageFile="~/Phone/PhonePage.Master" AutoEventWireup="true"
    CodeBehind="case.aspx.cs" Inherits="jsbestop.Web.Phone._case" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="biaoti" runat="server">
<%=Title %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<%--    <div class="nav_top">
        <h3>
            <span>
                <asp:Literal ID="lblTitle" runat="server"></asp:Literal>
                ></span>
    </div>
    <div class="product_list">
        <ul>
            <asp:Repeater ID="rptProducttype" runat="server">
                <ItemTemplate>
                    <li><a href="caseDetail.aspx?id=<%#Eval("id")%>&type=<%#Eval("SSType") %>" target="_self">
                        <img src="<%# phoneImgUrl(Convert.ToString(Eval("SSPic")))%>"><span>
                            <%#GetStrByByteLength(Eval("SSName").ToString(), 30, true)%></span></a></li>
                </ItemTemplate>
            </asp:Repeater>
            <div class="clear">
            </div>
        </ul>
        <div style="height: 30px; line-height: 30px; text-align: center; font-size: 14px;">
            <uc1:Pager ID="pager" runat="Server" PageSize="6" />
        </div>
    </div>--%>

         <div class="content">
         <div class="in_show">
                        <ul>
                    <asp:Repeater ID="rptProducttype" runat="server">
                          <ItemTemplate>
                               <li><a href="caseDetail.aspx?id=<%#Eval("id")%>&type=<%#Eval("SSType") %>" target="_self">
                                  <img src="<%# Convert.ToString(Eval("SSPic"))%>"><p>
                                 <%#GetStrByByteLength(Eval("SSName").ToString(), 30, true)%></p></a></li>
                          </ItemTemplate>
                      </asp:Repeater>
                        <%--    <li><a href="案例展示 - 内页.html"><img src="images/1.jpg" /><p>名称名称名称名称名称名称名称名称名称名称</p></a></li>
                            <li><a href="案例展示 - 内页.html"><img src="images/1.jpg" /><p>名称</p></a></li>
                            <li><a href="案例展示 - 内页.html"><img src="images/1.jpg" /><p>名称</p></a></li>
                            <li><a href="案例展示 - 内页.html"><img src="images/1.jpg" /><p>名称</p></a></li>
                            <li><a href="案例展示 - 内页.html"><img src="images/1.jpg" /><p>名称</p></a></li>
                            <li><a href="案例展示 - 内页.html"><img src="images/1.jpg" /><p>名称</p></a></li>--%>
                        </ul>
                    <div class="clear"></div>
                      <uc1:Pager ID="pager" runat="Server" PageSize="6" />
        </div>
        <div class="bqxx">
        版权所有：江阴市敏法机械制造有限公司<br />
技术支持：<a href="http://jsbestop.com/">江苏百拓</a>
        </div>
    </div>
</asp:Content>
