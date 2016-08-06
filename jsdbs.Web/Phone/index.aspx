<%@ Page Title="" Language="C#" MasterPageFile="~/Phone/PhonePage.Master" AutoEventWireup="true"
    CodeBehind="index.aspx.cs" Inherits="jsbestop.Web.Phone.index1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="biaoti" runat="server">
<div class="logo"  style="">
        	<img src="images/logo.png"/>
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


  <div class="content">
        <img src="images/bg.jpg" style="width: 100%; position: absolute;top: 40px;left: 0;z-index: -10;"/>
        <img src="images/banner.png" style="width: 100%;"/>
        <div class="in_nav">
            <img src="images/in_nav.png" style="width: 100%;"/>
            <ul>
                <li><a href="about.aspx?type=5"></a></li>
                <li><a href="products.aspx"></a></li>
                <li><a href="news.aspx"></a></li>
                <li><a href="case.aspx?type=14"></a></li>
                <li><a href="case.aspx?type=15"></a></li>
                <li><a href="message.aspx"></a></li>
            
            </ul>
        </div>
    </div>

</asp:Content>
