<%@ Page Title="" Language="C#" MasterPageFile="~/Phone/PhonePage.Master" AutoEventWireup="true"
    CodeBehind="about.aspx.cs" Inherits="jsbestop.Web.Phone.about" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="biaoti" runat="server">
<%=Title %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<div class="page_content">
        <h3 class="nav_top">
            <span>
                <asp:Literal ID="lblName" runat="server"></asp:Literal>
                ></span></h3>
        <div class="text_content">
            <asp:Literal ID="companyintroduce" runat="server"></asp:Literal>
        </div>
    </div>--%>
<%--    <div class="main">
        	<div class="title"><span><asp:Literal ID="jianjie" runat="server"></asp:Literal></span><i><asp:Literal ID="jianjie1" runat="server"></asp:Literal></i></div>
            <div class="conm">
            	 <asp:Literal ID="companyintroduce" runat="server"></asp:Literal>
            </div>
        </div>

           
     <div class="footer">
          <p>版权所有：无锡市梁溪精细化工有限公司<br>技术支持：江苏百拓信息技术有限公司</p>  	
     </div>--%>

        <div class="content">

            <div class="nytext">
          <asp:Literal ID="companyintroduce" runat="server"></asp:Literal>
            </div>
        <div class="bqxx">
        版权所有：江阴市敏法机械制造有限公司<br />
技术支持：<a href="http://jsbestop.com/">江苏百拓</a>
        </div>
    </div>
</asp:Content>
