<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="caseDetail.aspx.cs" Inherits="jsbestop.Web.caseDetail" %>

<%@ Register Src="UserControl/Producttype.ascx" TagName="Producttype" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

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
                    <!--<span class="jk">让我们为您打造最好的伙食，伴您健康一生！</span>-->
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
                产品介绍（PRODUCT)
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
                <div>您现在的位置：主页 >  合作伙伴</div>
                <span class="wa">YOUR POSITION: HOME > COOPERATIVE PARTNER</span>
            </div>
           <img src="images/rightTop2.jpg" class="rightTop2"/>
            <div class="nytext">
                <div class="nyrightshow">
                            <div class="nyrightshowtie"> <asp:Literal ID="lblTitle" runat="server"></asp:Literal></div>
                             <asp:Image ID="picpro" runat="server" />
                        </div>
                    <p><asp:Literal ID="lblContent" runat="server"></asp:Literal> 
                </p>
            
            
            
            </div>
            <img src="images/rightBottom.jpg" class="rightTop2"/>
        </div>
        
        <div class="clear"></div>
    </div>--%>

         <div class="right">
                <div class="nyrightTop">&nbsp;<span class="rl1"><asp:Literal ID="qianzhui" runat="server"></asp:Literal></span><span class="rl2"><asp:Literal
                    ID="houzhui" runat="server"></asp:Literal></span>&nbsp;/ 
                    <asp:Literal ID="yingwen" runat="server"></asp:Literal> <a href=""></a></div>
                <div class="showimg"> <asp:Image ID="picpro" runat="server" /><p><asp:Literal ID="lblTitle" runat="server"></asp:Literal></p></div>
                    <asp:Literal ID="lblContent" runat="server"></asp:Literal> 
            </div>

</asp:Content>
