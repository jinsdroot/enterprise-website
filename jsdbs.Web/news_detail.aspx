<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="news_detail.aspx.cs" Inherits="jsbestop.Web.news_detail" %>

<%@ Register Src="UserControl/Producttype.ascx" TagName="Producttype" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#m6").addClass("on");
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<%--      <div class="in_pro">
        <div class="in_proAll">
            <div class="topNews">
        		<span class="topNewsLeft">最新新闻(NEW)</span>
        			<div  id="scrollDiv2">
        				<ul>
                        <asp:Repeater ID="rptNews" runat="server">
                        <ItemTemplate>
                        <li>
        						<a href="news_detail.aspx?id=<%#Eval("Id")%>"><span class="main2ScrollUlSpanL"><%#Eval("NewsTitle")%></span><span  class="main2ScrollUlSpanR"><%#Eval("AddTime")%>更新</span></a>
    					</li>
                        </ItemTemplate>
                        </asp:Repeater>

        					
        				</ul>
        			</div>
       
           </div>
            <div class="mySearch">
                <input type="text" class="inputc" name="" value="输入产品搜索" />
                <input type="submit" name="" value="" class="thesearch"/> 
            </div>
        </div>
    </div>
     <div class="nyMain">
        <div class="left">
            <div class="leftTop">
                产品介绍（PRODUCT）
            </div>
            <ul class="leftul">
            <asp:Repeater ID="rptProType" runat="server">
            <ItemTemplate>
            <li>
                <a href="ProductList.aspx?type=<%#Eval("id")%>"><%#GetStrByByteLength(Eval("ProductTypeName").ToString(), 30, true)%></a></li>
            </ItemTemplate>
            </asp:Repeater>
               
            </ul>
            <img src="images/leftbottom.jpg" class="leftbottom"/>
            <div class="xs">
                <img src="images/xs.jpg" class="xsimg"/>
                <a href="about.aspx?type=58" class="xsmore"></a>
            </div>
        </div>
        <div class="right">
            <div class="rightTop">
               <div>您现在的位置：主页 > 新闻资讯</div>
                <span class="wa">YOUR POSITION: HOME > News information</span>
            </div>
            <img src="images/rightTop2.jpg" class="rightTop2"/>
            <div class="nytext">
                  <div class="tie">
                        <p class="redtext"><asp:Literal ID="lblTitle" runat="server"></asp:Literal></p>
                        <p class="time"><asp:Literal ID="lblTime" runat="server"></asp:Literal></p>
                    </div>
       <asp:Literal ID="lblcontent" runat="server"></asp:Literal>
            </div>
            <img src="images/rightBottom.jpg" class="rightTop2"/>
        </div>
        
        <div class="clear"></div>
    </div>
</div>--%>

  <div class="right">
                <div class="nyrightTop">&nbsp;<span class="rl1">新闻</span><span class="rl2">中心</span>&nbsp;/ NEWS   <a href=""></a></div>
                <div class="rightText">
                    <div class="newstie"><p class="newsfir"><asp:Literal ID="lblTitle" runat="server"></asp:Literal></p><p class="time"> 来源：本站 &nbsp;&nbsp;<span> 时间：<asp:Literal ID="lblTime" runat="server"></asp:Literal></span></p></div>
                       <asp:Literal ID="lblcontent" runat="server"></asp:Literal>
                </div>
            </div>
</asp:Content>
