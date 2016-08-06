<%@ Page Title="" Language="C#" MasterPageFile="~/Phone/PhonePage.Master" AutoEventWireup="true"
    CodeBehind="productDetail.aspx.cs" Inherits="jsbestop.Web.Phone.productDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="biaoti" runat="server">
产品展示
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<%--    <div class="nav_top">
        <h3>
            <span>产品中心 ></span><div class="more">
                更多分类</div>
        </h3>
        <div class="pro_sidebar">
            <ul class="sidebar">
                <asp:Repeater ID="rptProType" runat="server">
                    <ItemTemplate>
                        <li class="li">
                            <dl>
                                <a href="products.aspx?type=<%#Eval("id")%>">
                                    <%#GetStrByByteLength(Eval("ProductTypeName").ToString(), 30, true)%></a></dl>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </div>
    <div class="news_title">
        <h1>
            <asp:Literal ID="lblTitle" runat="server"></asp:Literal></h1>
    </div>
    <div class="text_content">
        <asp:Literal ID="lblContent" runat="server"></asp:Literal>
    </div>--%>
<%--
      <div class="main">
        	<div class="title"><span>产品介绍</span><i>(PRODUCTS)</i><div class="fenlei">更多&gt;&gt;</div></div>
            <ul class="fl-con">
             <asp:Repeater ID="rptProType" runat="server">
                    <ItemTemplate>
                        <li class="li">
                            <dl>
                                <a href="products.aspx?type=<%#Eval("id")%>">
                                    <%#GetStrByByteLength(Eval("ProductTypeName").ToString(), 30, true)%></a>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
               
            </ul>
           	 <div class="product-img">
                 <img src="images/1_03.jpg">
            </div>
            <div class="titlex"><asp:Literal ID="lblTitle" runat="server"></asp:Literal></div>
            <div class="conm">
                <asp:Literal ID="lblContent" runat="server"></asp:Literal>
            </div>
        </div>
    </div>
     <div class="footer">
          <p>版权所有：无锡市梁溪精细化工有限公司<br>技术支持：江苏百拓信息技术有限公司</p>  	
     </div>--%>

         <div class="content">
         <div class="nyrightshow">
                        <div class="nyrightshowtie"><asp:Literal ID="lblTitle" runat="server"></asp:Literal></div>
                        <img id="image" runat="server" />
        </div> 
        <div class="clear"></div>
            <div class="nytext">
             <p>
      <asp:Literal ID="lblContent" runat="server"></asp:Literal>
            </p>
            </div>
        <div class="bqxx">
        版权所有：江阴市敏法机械制造有限公司<br />
技术支持：<a href="http://jsbestop.com/">江苏百拓</a>
        </div>
    </div>
</asp:Content>
