<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="news.aspx.cs" Inherits="jsbestop.Web.news" %>

<%@ Register Src="UserControl/Producttype.ascx" TagName="Producttype" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


   <div class="right">
                <div class="nyrightTop">&nbsp;<span class="rl1">新闻</span><span class="rl2">中心</span>&nbsp;/ NEWS   <a href=""></a></div>
                <div class="rightText">
                    <ul class="nylistxx2">
                     <asp:Repeater ID="rptNews" runat="server">
                        <ItemTemplate>
                            <li><a href="news_detail.aspx?id=<%#Eval("Id")%>">
                                <%#GetStrByByteLength(Eval("NewsTitle").ToString(), 20, true)%><span> 
                                    <%#Convert.ToDateTime(Eval("AddTime")).ToString("yyyy-MM-dd")%></span></a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                        <div class="clear"></div>
                    </ul>
                  <uc1:PaginationCtrl ID="pager" runat="Server" PageSize="14" />
                </div>
            </div>
</asp:Content>
