<%@ Page Title="" Language="C#" MasterPageFile="~/Phone/PhonePage.Master" AutoEventWireup="true"
    CodeBehind="caseDetail.aspx.cs" Inherits="jsbestop.Web.Phone.caseDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="biaoti" runat="server">
<%=Title %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<%--    <h3 class="nav_top">
        <span>
            <asp:Literal ID="lblTitle" runat="server"></asp:Literal>
            ></span></h3>
    <div class="news_title">
        <h1>
            <asp:Literal ID="lblName" runat="server"></asp:Literal></h1>
    </div>
    <div class="text_content">
        <asp:Literal ID="lblContent" runat="server"></asp:Literal>
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
