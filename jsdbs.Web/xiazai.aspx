<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.Master" AutoEventWireup="true" CodeBehind="xiazai.aspx.cs" Inherits="jsbestop.Web.Phone.xiazai" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<%--  <div class="top">
        <div class="top_left">资料下载</div>
        
     </div>
     <div class="bottom">
        <ul class="newsul">
         <asp:Repeater ID="rptNews" runat="server">
                <ItemTemplate>
                    <li><a href="<%#Eval("DLAddress") %>">
                        <%#GetStrByByteLength(Eval("DLName").ToString(), 33, true)%><span>
                        <%#Convert.ToDateTime(Eval("DLAddTime")).ToString("yyyy-MM-dd")%></span></a> </li>
                </ItemTemplate>
            </asp:Repeater>
           <div class="clear"></div>
        </ul>
     <div style="height: 30px; line-height: 30px; text-align: center; font-size: 14px;">
            <uc1:Pager ID="pager" runat="Server" PageSize="5" />
        </div>
     </div>
     <div class="clear"></div>--%>

     <div class="right">
                <div class="nyrightTop">&nbsp;<span class="rl1">下载</span><span class="rl2">中心</span>&nbsp;/ NEWS   <a href=""></a></div>
                <div class="rightText">
                    <ul class="nylistxx2">
                     <asp:Repeater ID="rptNews" runat="server">
                       <ItemTemplate>
                            <li><a href="<%#Eval("DLAddress") %>">
                           <%#GetStrByByteLength(Eval("DLName").ToString(), 33, true)%><span>
                            <%#Convert.ToDateTime(Eval("DLAddTime")).ToString("yyyy-MM-dd")%></span></a> </li>
                         </ItemTemplate>
                     </asp:Repeater>

                      <%--  <li><a href="新闻中心 - 内页.html">我国桥式起重机发展方向    <span>2015/5/7</span></a></li>
                        <li><a href="新闻中心 - 内页.html">我国桥式起重机发展方向    <span>2015/5/7</span></a></li>
                        <li><a href="新闻中心 - 内页.html">我国桥式起重机发展方向    <span>2015/5/7</span></a></li>
                        <li><a href="新闻中心 - 内页.html">我国桥式起重机发展方向    <span>2015/5/7</span></a></li>
                        <li><a href="新闻中心 - 内页.html">我国桥式起重机发展方向    <span>2015/5/7</span></a></li>
                        <li><a href="新闻中心 - 内页.html">我国桥式起重机发展方向    <span>2015/5/7</span></a></li>
                        <li><a href="新闻中心 - 内页.html">我国桥式起重机发展方向    <span>2015/5/7</span></a></li>
                        <li><a href="新闻中心 - 内页.html">我国桥式起重机发展方向    <span>2015/5/7</span></a></li>
                        <li><a href="新闻中心 - 内页.html">我国桥式起重机发展方向    <span>2015/5/7</span></a></li>--%>
                        
                        <div class="clear"></div>
                    </ul>
                <uc1:Pager ID="pager" runat="Server" PageSize="5" />
                </div>
            </div>

</asp:Content>
