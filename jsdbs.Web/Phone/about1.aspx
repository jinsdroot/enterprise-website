<%@ Page Title="" Language="C#" MasterPageFile="~/Phone/PhonePage.Master" AutoEventWireup="true"
    CodeBehind="about1.aspx.cs" Inherits="jsbestop.Web.Phone.about1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<%--
    <div class="main">
        	<div class="title"><span><asp:Literal ID="jianjie" runat="server"></asp:Literal></span><i><asp:Literal ID="jianjie1" runat="server"></asp:Literal></i></div>
            <div class="conm">
            	 <asp:Literal ID="companyintroduce" runat="server"></asp:Literal>
            </div>
        </div>

           
     <div class="footer">
          <p>版权所有：无锡市梁溪精细化工有限公司<br>技术支持：江苏百拓信息技术有限公司</p>  	
     </div>--%>

         <div class="content">
        <div class="flexslider">
          <ul class="slides">
            <li>
              <img src="images/banner.jpg" />
            </li>
          </ul>
        </div>
        <div class="lan">
        加盟模式<span class="nyProShowMore"><div class="cpfl">加盟模式</div></span>
        
        </div>
        <ul class="nyMainProUl">
                     <li class="sel"><a href="about1.aspx?type=64">加盟条件</a></li>
                    <li><a href="about1.aspx?type=65">加盟流程</a></li>
                    <li><a href="about1.aspx?type=66">加盟支持</a></li>
                    <li><a href="about1.aspx?type=67">加盟投资标准</a></li>
                       
        </ul>
        <div class="nytext">
         <asp:Literal ID="companyintroduce" runat="server"></asp:Literal>
        
        </div>
    </div>


</asp:Content>
