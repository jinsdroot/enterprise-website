<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContactUS.ascx.cs" Inherits="jsbestop.Web.UserControl.ContactUS" %>
<div class="nyleft">
    <div class="nyleftTop">
        <img src="../images/leftTop.jpg" /></div>
    <img src="../images/contact.jpg" />
    <div class="hOTLINE">
        热线电话：<img src="../images/hOTLINE.jpg" /></div>
    <div class="dt">
        联系人：<asp:Literal ID="lblName" runat="server"></asp:Literal><br />
        传真：<asp:Literal ID="lblFax" runat="server"></asp:Literal><br />
        移动电话：<asp:Literal ID="lblTel" runat="server"></asp:Literal><br />
        地址：<asp:Literal ID="lblAddress" runat="server"></asp:Literal>
    </div>
</div>
