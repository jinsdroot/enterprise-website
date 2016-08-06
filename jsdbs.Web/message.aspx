<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="message.aspx.cs" Inherits="jsbestop.Web.message" %>

<%@ Register Src="UserControl/Producttype.ascx" TagName="Producttype" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#m8").addClass("on");
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                <div class="right">
                <div class="nyrightTop">&nbsp;<span class="rl1">联系</span><span class="rl2">我们</span>&nbsp;/ MESSAGE   <a href=""></a></div>
            <div class="ny_text">
                <div class="feedbackform">
                    <label for="contact">
                        联系人：&nbsp;&nbsp;</label>
                    <input type="text" name="contact" id="contactor" runat="server" /><span class="required">*</span><br />
                    <label for="phonenum">
                        联系电话：</label>
                    <input type="text" name="phonenum" id="phonenumber" runat="server" /><span class="required">*</span><br />
                    <label for="email">
                        邮箱：&nbsp;&nbsp;&nbsp;&nbsp;</label>
                    <input type="text" name="email" id="email" runat="server" /><br />
                    <label for="addr">
                        联系地址：</label>
                    <input type="text" name="addr" id="lblAddress" runat="server" /><br />
                    <label for="message" class="fbfsp1">
                        留言内容：</label>
                    <textarea name="message" cols="50" rows="10" id="messageContent" runat="server"></textarea><span
                        class="required">*</span><br />
                    <label for="">
                        &nbsp;</label>
                    <asp:Button ID="Button1" type="submit" Text="确定" runat="server" class="submit" OnClick="Unnamed1_Click" />
                </div>
            </div>
        
        <div class="clear">
        </div>
    </div>
</asp:Content>
