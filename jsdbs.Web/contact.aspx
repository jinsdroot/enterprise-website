<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="contact.aspx.cs" Inherits="jsbestop.Web.contact" %>

<%@ Register Src="UserControl/Producttype.ascx" TagName="Producttype" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#m9").addClass("on");
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="nymain">
        <uc2:Producttype ID="Producttype1" runat="server" />
        <div class="nyright">
            <div class="nyrightTop">
                <span class="nyrightTopN">联系我们 <span>Contact</span></span><span class="wz">当前位置：网站首页》联系我们
                </span>
            </div>
            <div class="ny_text">
                <asp:Literal ID="lblConatct" runat="server"></asp:Literal>
            </div>
        </div>
        <div class="clear">
        </div>
    </div>
</asp:Content>
