<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Producttype.ascx.cs"
    Inherits="jsbestop.Web.UserControl.Producttype" %>
<div class="nyleft">
    <div class="nyleftTop">
        <h1>
            产品分类</h1>
        <span>Product</span></div>
    <ul class="nyleftUL">
        <asp:Repeater ID="rptProducttype" runat="server">
            <ItemTemplate>
                <li><a href="ProductList.aspx?type=<%#Eval("id")%>"><span>
                    <%#GetStrByByteLength(Eval("ProductTypeName").ToString(),35,true)%></span></a>
                </li>
            </ItemTemplate>
        </asp:Repeater>
        <img src="../images/line.jpg" />
    </ul>
    <div class="sidebar_contact">
        <h3 class="leftcon">
            <div>
                联系我们</div>
            <span>Contact us</span></h3>
        <img src="../images/sidebar_contact_bg.jpg">
        <div class="text">
            <div class="txt">
                <h4>
                    无锡上上电缆销售有限公司</h4>
                联系人：<asp:Literal ID="lblName" runat="server"></asp:Literal>
                <br />
                电话：<asp:Literal ID="lblPhone" runat="server"></asp:Literal>
                <asp:Literal ID="lblTel" runat="server"></asp:Literal>
                <br />
                传真：<asp:Literal ID="lblFax" runat="server"></asp:Literal>
                <br />
                E-mail:<asp:Literal ID="lblEmail" runat="server"></asp:Literal><br />
                地 址：<asp:Literal ID="lblAddress" runat="server"></asp:Literal>
            </div>
        </div>
    </div>
</div>
