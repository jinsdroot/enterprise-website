<%@ Page Title="" Language="C#" MasterPageFile="~/Phone/PhonePage.Master" AutoEventWireup="true"
    CodeBehind="news_detail.aspx.cs" Inherits="jsbestop.Web.Phone.news_detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="biaoti" runat="server">
新闻中心
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <%--  <div class="nav_top">
        <h3>
            <span>企业新闻 ></span></h3>
    </div>
    <div class="news_title">
        <h1>
            <asp:Literal ID="lblTitle" runat="server"></asp:Literal></h1>
        <p>
            时间：<asp:Literal ID="lblTime" runat="server"></asp:Literal></p>
    </div>
    <div class="text_content">
        <asp:Literal ID="lblcontent" runat="server"></asp:Literal>
    </div>
    <div class="footer">
          <p>版权所有：无锡市梁溪精细化工有限公司<br>技术支持：江苏百拓信息技术有限公司</p>  	
     </div>--%>
<%--
     <div class="main">
        	<div class="title"><span>新闻中心</span><i>(NEWS)</i></div>
             <div class="news-conx">
                <h1><asp:Literal ID="lblTitle" runat="server"></asp:Literal></h1>
                <p class="time">2015-4-10</p>
                <div class="news-c">
                     <asp:Literal ID="lblcontent" runat="server"></asp:Literal>
                </div>
            </div>
        </div>
    </div>
     <div class="footer">
          <p>版权所有：无锡市梁溪精细化工有限公司<br>技术支持：江苏百拓信息技术有限公司</p>  	
     </div>--%>
       <div class="content">
         <div class="nytext">
             <div class="tie">
                            <p class="redtext"><asp:Literal ID="lblTitle" runat="server"></asp:Literal></p>
                            <p class="time">
                                <asp:Literal ID="Time" runat="server"></asp:Literal></p>
                    </div>
                    <asp:Literal ID="lblcontent" runat="server"></asp:Literal>
        </div> 
        <div class="bqxx">
        版权所有：江阴市敏法机械制造有限公司<br />
技术支持：<a href="http://jsbestop.com/">江苏百拓</a>
        </div>
    </div>
</asp:Content>
