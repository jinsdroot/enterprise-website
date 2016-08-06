<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="case.aspx.cs" Inherits="jsbestop.Web._case" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                <div class="right">
                <div class="nyrightTop">&nbsp;<span class="rl1"><asp:Literal ID="qianzhui" runat="server"></asp:Literal></span><span class="rl2"><asp:Literal
                    ID="houzhui" runat="server"></asp:Literal></span>&nbsp;/ 
                    <asp:Literal ID="yingwen" runat="server"></asp:Literal>   <a href=""></a></div>
                <ul class="nypro">

                
            <asp:Repeater ID="rptProducttype" runat="server">
                <ItemTemplate>
                    <li><a href="caseDetail.aspx?id=<%#Eval("id")%>&type=<%#Eval("SSType") %>">
                        <img src="<%# Convert.ToString(Eval("SSPic"))%>"><p>
                            <%#GetStrByByteLength(Eval("SSName").ToString(), 30, true)%></p></a>
                    &nbsp;</li>
                </ItemTemplate>
            </asp:Repeater>
                </ul>
                <div class="clear"></div>
                 <uc1:Pager ID="pager" runat="Server" PageSize="6" />
            </div>

</asp:Content>
