<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="ProductList.aspx.cs" Inherits="jsbestop.Web.ProductList" %>

<%@ Register Src="UserControl/Producttype.ascx" TagName="Producttype" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <script type="text/javascript">
        $(document).ready(function () {
            $("#m3").addClass("on");
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="right">
                <div class="nyrightTop">&nbsp;<span class="rl1">产品</span><span class="rl2">展示</span>&nbsp;/ PRODUCT   <a href=""></a></div>
                <ul class="nypro">
                              <asp:Repeater ID="rptProduct" runat="server">
                      <ItemTemplate>
                        <li><a href="ProductListDetail.aspx?id=<%#Eval("id")%>">
                            <img src="<%#Eval("ProductPic")%>" />
                            <p><%#GetStrByByteLength(Eval("ProductName").ToString(), 10, true)%></p>
                        </a></li>
                    </ItemTemplate>
                </asp:Repeater>
                
                </ul>
                <div class="clear"></div>
                 <uc1:PaginationCtrl ID="pager" runat="Server" PageSize="6" />
            </div>

</asp:Content>
