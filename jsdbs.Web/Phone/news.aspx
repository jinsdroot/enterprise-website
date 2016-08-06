<%@ Page Title="" Language="C#" MasterPageFile="~/Phone/PhonePage.Master" AutoEventWireup="true"
    CodeBehind="news.aspx.cs" Inherits="jsbestop.Web.Phone.news" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="biaoti" runat="server">
新闻中心
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <%--   <div class="nav_top">
        <h3>
            <span>企业新闻 ></span></h3>
    </div>
    <div class="news_list bottom_10">
        <ul>
            <asp:Repeater ID="rptNews" runat="server">
                <ItemTemplate>
                    <li><a href="news_detail.aspx?id=<%#Eval("Id")%>" target="_self"><span>
                        <%#GetStrByByteLength(Eval("NewsTitle").ToString(), 33, true)%></span>[
                        <%#Convert.ToDateTime(Eval("AddTime")).ToString("yyyy-MM-dd")%>]</a> </li>
                </ItemTemplate>
            </asp:Repeater>
            <div class="clear">
            </div>
        </ul>
        <div style="height: 30px; line-height: 30px; text-align: center; font-size: 14px;">
            <uc1:Pager ID="pager" runat="Server" PageSize="11" />
        </div>
    </div>--%>

<%--     <div class="main">
        	<div class="title"><span>新闻中心</span><i>(NEWS)</i></div>
             <ul class="news">
             <asp:Repeater ID="rptNews" runat="server">
                <ItemTemplate>
                    <li><a href="news_detail.aspx?id=<%#Eval("Id")%>" target="_self">
                        <%#GetStrByByteLength(Eval("NewsTitle").ToString(), 33, true)%></a>
                        <span><%#Convert.ToDateTime(Eval("AddTime")).ToString("yyyy-MM-dd")%> </li>
                </ItemTemplate>
            </asp:Repeater>
                <!-- 新闻限制字数-->
                   
             </ul>
             <uc1:Pager ID="pager" runat="Server" PageSize="11" />
        </div>
        <div class="footer">
          <p>版权所有：无锡市梁溪精细化工有限公司<br>技术支持：江苏百拓信息技术有限公司</p>  	
     </div>--%>

         <div class="content">
         <div class="nytext">
             <ul class="nynewslist">

             
                     <asp:Repeater ID="rptNews" runat="server">
                        <ItemTemplate>
                            <li><a href="news_detail.aspx?id=<%#Eval("Id")%>">
                                <%#GetStrByByteLength(Eval("NewsTitle").ToString(), 20, true)%><span> 
                                    <%#Convert.ToDateTime(Eval("AddTime")).ToString("yyyy-MM-dd")%></span></a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                        <%--    <li><a href="新闻中心 - 内页.html">新闻新闻新闻新闻新闻11<span>2014-07-29</span></a></li><!--限字数-->
                            <li><a href="#">新闻新闻新闻新闻新闻11<span>2014-07-29</span></a></li>
                            <li><a href="#">新闻新闻新闻新闻新111<span>2014-07-29</span></a></li>
                            <li><a href="#">新闻新闻新闻新111<span>2014-07-29</span></a></li>
                            <li><a href="#">新闻新闻111<span>2014-07-29</span></a></li>
                            <li><a href="#">新闻新闻新闻1111<span>2014-07-29</span></a></li>   --%>
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
